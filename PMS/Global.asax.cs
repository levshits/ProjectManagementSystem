using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Common.Logging;
using Spring.Web.Mvc;

namespace PMS.Web
{
    public class PMS : SpringMvcApplication
    {
        private readonly ILog _log = LogManager.GetLogger<PMS>();
        void Application_Start(object sender, EventArgs e)
        {
            _log.Debug("App started");
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}