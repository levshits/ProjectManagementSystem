using System;
using System.Collections.Generic;
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

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewSprint)]
    public class SprintController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Sprint";

        public ActionResult Create()
        {
            var model = new CreateSprintModel();
            InitialiseModel(model);
            return View(model);
        }

        private void InitialiseModel(CreateSprintModel model)
        {
            ExecutionResult<List<LookupItem>> resultProj =
                CommandBus.ExecuteCommand(new ProjectLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultProj != null && resultProj.Success)
            {
                model.ProjectLookupItems = resultProj.TypedResult;
            }
        }

        public ActionResult Edit(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index(int page = 0)
        {
            SprintListModel model = new SprintListModel();
            ExecutionResult<ListResultDto<SprintListItem>> result =
                CommandBus.ExecuteCommand(new SprintListRequest() { Page = (page - 1) }) as
                    ExecutionResult<ListResultDto<SprintListItem>>;
            if (result != null && result.TypedResult != null)
            {
                model.Items = Mapper.Map<List<SprintListItemModel>>(result.TypedResult.Items);
                model.Items.ForEach(x => { x.AllowEdit = true; });
                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = result.TypedResult.Page,
                    TotalItems = result.TypedResult.ItemsCount
                };
            }
            return View(model);
        }

        public ActionResult Save(CreateSprintModel model)
        {
            if (ModelState.IsValid)
            {
                SprintDto dto = Mapper.Map<SprintDto>(model);
                var result = CommandBus.ExecuteCommand(new SaveSprintRequest() { Dto = dto });
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(String.Empty, "Error during executing request. Try again");
            }
            InitialiseModel(model);
            if (model.Id == Guid.Empty)
            {
                return View("Create", model);
            }
            return View("Edit", model);
        }
    }
}