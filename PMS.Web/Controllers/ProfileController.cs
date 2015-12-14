using System;
using System.Web.Mvc;
using AutoMapper;
using Levshits.Data.Common;
using PMS.Common;
using PMS.Common.Dto;
using PMS.Common.Request;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    public class ProfileController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Profile";


        [HttpGet]
        public ActionResult Index()
        {
            UserPrincipal principal = UserPrincipal.CurrentUser;
            ExecutionResult<PrincipalDto> result =
                CommandBus.ExecuteCommand(new GetEntityDtoByIdRequest<PrincipalDto>() {EntityId = principal.Id}) as ExecutionResult<PrincipalDto>;
            if (result != null && result.Success && result.TypedResult != null)
            {
                var model = Mapper.Map<UserDetailsModel>(result.TypedResult);
                return View(model);
            }
            ModelState.AddModelError(String.Empty, "Error during processing request");
            return RedirectToAction(DashboardController.IndexAction, DashboardController.Name);
        }
    }
}