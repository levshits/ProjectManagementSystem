using System.Web.Mvc;
using System.Web.Routing;
using PMS.Web.Controllers;

namespace PMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = DashboardController.Name, action = DashboardController.IndexAction, id = UrlParameter.Optional }
            );
        }
    }
}
