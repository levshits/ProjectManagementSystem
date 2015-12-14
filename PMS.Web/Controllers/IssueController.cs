using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Levshits.Data.Common;
using Levshits.Web.Common.Controllers;
using PMS.Common;
using PMS.Common.Dto;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    public class IssueController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Issue";
        public ActionResult Index(int page = 0)
        {
            IssueListModel model = new IssueListModel();
            ExecutionResult<ListResultDto<IssueListItem>> result =
                CommandBus.ExecuteCommand(new IssueListRequest() { Page = (page - 1) }) as
                    ExecutionResult<ListResultDto<IssueListItem>>;
            if (result != null && result.TypedResult != null)
            {
                model.Items = Mapper.Map<List<IssueListItemModel>>(result.TypedResult.Items);
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
            var model = new CreateIssueModel();
            InitialiseModel(model);
            return View(model);
        }

        private void InitialiseModel(CreateIssueModel model)
        {
            ExecutionResult<List<LookupItem>> resultProj =
                CommandBus.ExecuteCommand(new ProjectLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultProj != null && resultProj.Success)
            {
                model.ProjectLookupItems = resultProj.TypedResult;
            }
            
            ExecutionResult<List<LookupItem>> resultPrincpals =
                CommandBus.ExecuteCommand(new PrincipalLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultPrincpals != null && resultPrincpals.Success)
            {
                model.PrincipalLookupItems = resultPrincpals.TypedResult;
            }

            ExecutionResult<List<LookupItem>> resultSprints =
    CommandBus.ExecuteCommand(new SprintLookupListRequest()) as ExecutionResult<List<LookupItem>>;
            if (resultSprints != null && resultSprints.Success)
            {
                model.SprintLookupItems = resultSprints.TypedResult;
            }
        }

        public ActionResult Details(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Save(CreateIssueModel model)
        {
            if (ModelState.IsValid)
            {
                IssueDto dto = Mapper.Map<IssueDto>(model);
                dto.CreateTime = DateTime.Now;
                var result = CommandBus.ExecuteCommand(new SaveIssueRequest() { Dto = dto });
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