using System;
using System.Web.Mvc;
using Levshits.Web.Common.Controllers;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    public class UserController: PrivateController
    {
        public const string DetailsAction = "Details";
        public const string IndexAction = "Index";
        public const string Name = "User";

        [HttpGet]
        public ActionResult Details(Guid userId)
        {
            var model = new UserDetailsModel();
            return View(model);
        }
    }
}