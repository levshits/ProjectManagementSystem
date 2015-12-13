using Levshits.Web.Common.Controllers;
using PMS.Common.Immutable;
using PMS.Web.Attributes;

namespace PMS.Web.Controllers
{
    [HasPermission(Actions.ViewSprint)]
    public class SprintController: PrivateController
    {
        public const string IndexAction = "Index";
        public const string Name = "Sprint";
    }
}