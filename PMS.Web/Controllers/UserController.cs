using System.Web.Mvc;
using PMS.Common.Immutable;
using PMS.Web.Attributes;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewPrincipal)]
    public class UserController: PrivateController
    {
        public const string DetailsAction = "Details";
        public const string IndexAction = "Index";
        public const string Name = "User";
        public ActionResult Index(int page = 0)
        {
            var model = new UserListModel();
            return View(model);
        }
    }
}