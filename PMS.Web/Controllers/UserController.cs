using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Levshits.Data.Common;
using PMS.Common;
using PMS.Common.Dto;
using PMS.Common.Immutable;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Logic.Blo;
using PMS.Web.Attributes;
using PMS.Web.Models;
using WebGrease.Css.Extensions;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewPrincipal)]
    public class UserController : PrivateController
    {
        public const string DetailsAction = "Details";
        public const string IndexAction = "Index";
        public const string Name = "User";

        public ActionResult Index(int page = 0)
        {
            UserListModel model = new UserListModel();
            ExecutionResult<ListResultDto<PrincipalListItem>> result =
                CommandBus.ExecuteCommand(new PrincipalListRequest() {Page = (page - 1)}) as
                    ExecutionResult<ListResultDto<PrincipalListItem>>;
            if (result != null && result.TypedResult != null)
            {
                model.Items = Mapper.Map<List<UserListItemModel>>(result.TypedResult.Items);
                model.Items.Where(x => x.Id != PrincipalBlo.SU_ID).ForEach(x => { x.AllowEdit = true; });
                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = result.TypedResult.Page,
                    TotalItems = result.TypedResult.ItemsCount
                };
            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            ExecutionResult<PrincipalDto> result =
                CommandBus.ExecuteCommand(new GetPrincipalEntitybyIdRequest() { EntityId = id }) as ExecutionResult<PrincipalDto>;
            if (result != null && result.Success)
            {
                UserDetailsModel model = Mapper.Map<UserDetailsModel>(result.TypedResult);
                model.SelectedRolesIds = model.RolesEntities.Select(x => x.Id).ToArray();
                model.SelectedProjectsIds = model.ProjectEntities.Select(x => x.Id).ToArray();
                InitialiseModel(model);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            var model = new CreateUserModel();
            InitialiseModel(model);
            return View(model);
        }

        private void InitialiseModel(CreateUserModel model)
        {
            ExecutionResult<List<LookupItem>> resultRoles =
                CommandBus.ExecuteCommand(new RoleLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultRoles != null && resultRoles.Success)
            {
                model.AvailableRoles = resultRoles.TypedResult;
            }
            model.SelectedRoles = model.AvailableRoles.Where(x => model.SelectedRolesIds.Contains(x.Id)).ToList();

            ExecutionResult<List<LookupItem>> resultProjects =
                CommandBus.ExecuteCommand(new ProjectLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultProjects != null && resultProjects.Success)
            {
                model.AvailableProjects = resultProjects.TypedResult;
            }
            model.SelectedProjects = model.AvailableProjects.Where(x => model.SelectedProjectsIds.Contains(x.Id)).ToList();
        }

        private void InitialiseModel(UserDetailsModel model)
        {
            ExecutionResult<List<LookupItem>> resultRoles =
                CommandBus.ExecuteCommand(new RoleLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultRoles != null && resultRoles.Success)
            {
                model.AvailableRoles = resultRoles.TypedResult;
            }
            model.SelectedRoles = model.AvailableRoles.Where(x => model.SelectedRolesIds.Contains(x.Id)).ToList();

            ExecutionResult<List<LookupItem>> resultProjects =
                CommandBus.ExecuteCommand(new ProjectLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultProjects != null && resultProjects.Success)
            {
                model.AvailableProjects = resultProjects.TypedResult;
            }
            model.SelectedProjects = model.AvailableProjects.Where(x => model.SelectedProjectsIds.Contains(x.Id)).ToList();
        }

        [HttpPost]
        public ActionResult Save(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SelectedRolesIds.Any())
                {
                    PrincipalDto dto = Mapper.Map<PrincipalDto>(model);
                    dto.CreateTime = DateTime.Now;
                    dto.RoleEntities = model.SelectedRolesIds.Select(x => new RoleDto() { Id = x }).ToList();
                    dto.ProjectEntities = model.SelectedProjectsIds.Select(x => new ProjectDto() { Id = x }).ToList();
                    var result = CommandBus.ExecuteCommand(new PrincipalSaveRequest() { Dto = dto });
                    if (result.Success)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    ModelState.AddModelError(string.Empty, "Saving item error. Try one more time.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, 
                        "You need select at least one role");
                }
            }
            InitialiseModel(model);

           return View("Create", model);
        }
    
    [HttpPost]
    public ActionResult SaveAfterEdit(UserDetailsModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.SelectedRolesIds.Any())
            {
                PrincipalDto dto = Mapper.Map<PrincipalDto>(model);
                dto.CreateTime = DateTime.Now;
                dto.RoleEntities = model.SelectedRolesIds.Select(x => new RoleDto() { Id = x }).ToList();
                dto.ProjectEntities = model.SelectedProjectsIds.Select(x => new ProjectDto() { Id = x }).ToList();
                var result = CommandBus.ExecuteCommand(new PrincipalSaveRequest() { Dto = dto });
                if (result.Success)
                {
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError(string.Empty, "Saving item error. Try one more time.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, 
                    "You need select at least one role");
            }
        }
        InitialiseModel(model);
        return View("Edit", model);
    }
}
}
