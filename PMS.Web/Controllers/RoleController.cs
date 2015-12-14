using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Levshits.Data.Common;
using Levshits.Web.Common.Controllers;
using PMS.Common;
using PMS.Common.Dto;
using PMS.Common.Immutable;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Web.Attributes;
using PMS.Web.Models;
using WebGrease.Css.Extensions;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewRole)]
    public class RoleController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Role";
        public ActionResult Index(int page = 0)
        {
            RoleListModel model = new RoleListModel();
            ExecutionResult<ListResultDto<RoleListItem>> result =
                CommandBus.ExecuteCommand(new RoleListRequest() {Page = (page-1)}) as ExecutionResult<ListResultDto<RoleListItem>>;
            if (result != null && result.TypedResult != null)
            {
                model.Items = Mapper.Map<List<RoleListItemModel>>(result.TypedResult.Items);
                model.Items.Where(x=>x.Id!=RoleTypes.SUPERUSER_ROLE).ForEach(x=> { x.AllowEdit = true; });
                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = result.TypedResult.Page,
                    TotalItems = result.TypedResult.ItemsCount
                };

            }
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateRoleFirstStepModel();
            InitialiseModel(model);
            return View("CreateFirstStep", model);
        }

        [HttpPost]
        public ActionResult CreateFirstStep(CreateRoleFirstStepModel model)
        {
            if (ModelState.IsValid)
            {
                CreateRoleSecondStepModel modelSecondStep = Mapper.Map<CreateRoleSecondStepModel>(model);
                InitialiseModel(modelSecondStep);
                return View("CreateSecondStep", modelSecondStep);
            }
            InitialiseModel(model);
            return View("CreateFirstStep", model);
        }

        [HttpPost]
        public ActionResult Save(CreateRoleSecondStepModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SelectedActionIds.Any())
                {
                    RoleDto dto = Mapper.Map<RoleDto>(model);
                    dto.CreatorId = UserPrincipal.CurrentUser.Id;
                    dto.CreateTime = DateTime.Now;
                    dto.ActionEntities = model.SelectedActionIds.Select(x => new ActionDto() {Id = x}).ToList();
                    var result = CommandBus.ExecuteCommand(new RoleSaveRequest() {Dto = dto});
                    if (result.Success)
                    {
                        return RedirectToAction("Index", "Role");
                    }
                    ModelState.AddModelError(string.Empty, "Saving item error. Try one more time.");
                }
                else
                {
                    ModelState.AddModelError(nameof(CreateRoleSecondStepModel.SelectedActions),
                        "You need select at least one action");
                }
            }
            InitialiseModel(model);
            if (model.Id == Guid.Empty)
            {
                return View("CreateSecondStep", model);
            }
            return RedirectToAction("Edit", model);
        }

        private void InitialiseModel(CreateRoleFirstStepModel model)
        {
            ExecutionResult<List<LookupItem>> result = CommandBus.ExecuteCommand(new RoleTypeLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (result != null && result.Success)
            {
                model.RoleTypeLookupItems = result.TypedResult;
            }
        }

        private void InitialiseModel(CreateRoleSecondStepModel model)
        {
            ExecutionResult<List<LookupItem>> result = 
                CommandBus.ExecuteCommand(new ActionsLookupListRequest() {RoleTypeId = model.RoleTypeId}) as ExecutionResult<List<LookupItem>>;
            if (result != null && result.Success)
            {
                model.AvailableActions = result.TypedResult;
            }
            model.SelectedActions = model.AvailableActions.Where(x => model.SelectedActionIds.Contains(x.Id)).ToList();
        }

        public ActionResult Edit(Guid id)
        {
            ExecutionResult<RoleDto> result =
                CommandBus.ExecuteCommand(new GetRoleEntityRequest { EntityId = id }) as ExecutionResult<RoleDto>;
            if (result != null && result.Success)
            {
                RoleDetailsModel model = Mapper.Map<RoleDetailsModel>(result.TypedResult);
                model.SelectedActionIds = model.ActionEntities.Select(x => x.Id).ToArray();
                InitialiseModel(model);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}