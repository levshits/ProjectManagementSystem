using System.Web.Mvc;
using Levshits.Web.Common.Controllers;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class DashboardController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Dashboard";

        public ActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }
    }
}