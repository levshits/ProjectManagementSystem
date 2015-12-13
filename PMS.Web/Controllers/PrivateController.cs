using System.Web.Mvc;
using Levshits.Web.Common.Controllers;

namespace PMS.Web.Controllers
{
    [Authorize]
    public abstract class PrivateController: BaseController
    {
         
    }
}