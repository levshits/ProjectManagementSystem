using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Levshits.Data.Common;
using Levshits.Web.Common.Controllers;
using PMS.Common.Dto;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class DashboardController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Dashboard";

        public ActionResult Index(int page = 0)
        {
            DashboardModel model = new DashboardModel();
            ExecutionResult<ListResultDto<ActivityListItem>> result =
                CommandBus.ExecuteCommand(new ActivityListRequest() { Page = (page - 1) }) as
                    ExecutionResult<ListResultDto<ActivityListItem>>;
            if (result != null && result.TypedResult != null)
            {
                model.Items = Mapper.Map<List<ActivityListItemModel>>(result.TypedResult.Items);
                model.Items.ForEach(x => { x.AllowEdit = true; });
                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = result.TypedResult.Page,
                    TotalItems = result.TypedResult.ItemsCount
                };
            }
            return View(model);
        }
    }
}