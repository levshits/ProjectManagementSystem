using System.Web.Mvc;
using Levshits.Web.Common.Controllers;
using PMS.Common.Immutable;
using PMS.Web.Attributes;
using PMS.Web.Models;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewRole)]
    public class RoleController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Role";
        public override ActionResult Index()
        {
            var model = new RoleListModel();
            return View(model);
        }
    }
}