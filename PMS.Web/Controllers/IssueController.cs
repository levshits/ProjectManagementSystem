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
            ExecutionResult<IssueDto> result = CommandBus.ExecuteCommand(new GetIssueEntitybyIdRequest() { EntityId = id }) as ExecutionResult<IssueDto>;
            if (result != null && result.Success)
            {
                IssueDetailsModel model = Mapper.Map<IssueDetailsModel>(result.TypedResult);
                model.Comments =
                    result.TypedResult.CommentEntities.Select(
                        x => new CommentModel {CreateTime = x.CreateTime, Text = x.Text, Creator = x.CreatorIdObject.Username}).ToList();
                
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult CloseIssue(Guid id)
        {
            return Details(id);
        }
        public ActionResult ResolveIssue(Guid id)
        {
            return Details(id);
        }
        public ActionResult ReopenIssue(Guid id)
        {
            return Details(id);
        }

        public ActionResult Edit(Guid id)
        {
            ExecutionResult<IssueDto> result = CommandBus.ExecuteCommand(new GetIssueEntitybyIdRequest() { EntityId = id }) as ExecutionResult<IssueDto>;
            if (result != null && result.Success)
            {
                CreateIssueModel model = Mapper.Map<CreateIssueModel>(result.TypedResult);
                InitialiseModel(model);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Save(CreateIssueModel model)
        {
            if (ModelState.IsValid)
            {
                IssueDto dto = Mapper.Map<IssueDto>(model);
                dto.CreateTime = DateTime.Now;
                var result = CommandBus.ExecuteCommand(new SaveIssueRequest() { Dto = dto, ActivityType = dto.Id==Guid.Empty? ActivityType.CreateItem: ActivityType.ChangeItem});
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

        [HttpPost]
        public ActionResult SaveComment(CreateCommentModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CommandBus.ExecuteCommand(new SaveCommentRequest() {IssueId = model.IssueId, Text = model.Text});

            }
            return RedirectToAction("Details", new { id = model.IssueId});
        }
    }
}