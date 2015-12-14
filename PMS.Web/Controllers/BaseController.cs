using System.Web.Mvc;
using Levshits.Data.Interfaces;

namespace PMS.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public ICommandBus CommandBus { get; set; }
    }
}