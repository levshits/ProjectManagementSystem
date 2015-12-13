using Levshits.Web.Common.Controllers;
using PMS.Common.Immutable;
using PMS.Web.Attributes;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewProject)]
    public class ProjectController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Project";
    }
}