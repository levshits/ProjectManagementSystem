using System.Web.Http;

namespace PMS.Web.Controllers
{
    [Authorize]
    public class PrincipalController: ApiController
    {
        public string Name()
        {
            return "lion";
        }
    }
}