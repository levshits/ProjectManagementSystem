using System.Web.Mvc;
using Levshits.Web.Common.Controllers;

namespace PMS.Web.Controllers
{
    public class HomeController: BaseController
    {
        public override ActionResult Index()
        {
            return View();
        }
    }
}