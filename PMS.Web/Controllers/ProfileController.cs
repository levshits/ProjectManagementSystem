using System;
using System.Web.Mvc;
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
            var model = new UserDetailsModel();
            return View(model);
        }
    }
}