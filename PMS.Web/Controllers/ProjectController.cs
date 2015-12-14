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
using PMS.Logic.Blo;
using PMS.Web.Attributes;
using PMS.Web.Models;
using WebGrease.Css.Extensions;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewProject)]
    public class ProjectController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Project";

        public ActionResult Index(int page = 0)
        {
            ProjectListModel model = new ProjectListModel();
            ExecutionResult<ListResultDto<ProjectListItem>> result =
                CommandBus.ExecuteCommand(new ProjectListRequest() { Page = (page - 1) }) as
                    ExecutionResult<ListResultDto<ProjectListItem>>;
            if (result != null && result.TypedResult != null)
            {
                model.Items = Mapper.Map<List<ProjectListItemModel>>(result.TypedResult.Items);
                model.Items.ForEach(x => { x.AllowEdit = true; });
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
            var model = new CreateProjectModel();
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            ExecutionResult<ProjectDto> result = CommandBus.ExecuteCommand(new GetProjectEntitybyIdRequest() { EntityId = id }) as ExecutionResult<ProjectDto>;
            if (result != null && result.Success)
            {
                CreateProjectModel model = Mapper.Map<CreateProjectModel>(result.TypedResult);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Save(CreateProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectDto dto = Mapper.Map<ProjectDto>(model);
                dto.CreateTime = DateTime.Now;
                dto.CreatorId = UserPrincipal.CurrentUser.Id;
                var result = CommandBus.ExecuteCommand(new ProjectSaveRequest() {Dto = dto});
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(String.Empty, "Error during executing request. Try again");
            }
            if (model.Id == Guid.Empty)
            {
                return View("Create", model);
            }
            return View("Edit", model);
        }
    }
}