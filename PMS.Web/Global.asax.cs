using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Common.Logging;
using PMS.Common;
using PMS.Web.Storages;
using Spring.Context;
using Spring.Context.Support;
using Spring.Web.Mvc;

namespace PMS.Web
{
    public class PMSApplication : SpringMvcApplication
    {
        private readonly ILog _log = LogManager.GetLogger<PMSApplication>();
        void Application_Start(object sender, EventArgs e)
        {
            _log.Debug("App started");
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                UserPrincipal user = UserPrincipal.Empty;
                HttpCookie httpCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (httpCookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(httpCookie.Value);

                    Guid sessionId = new Guid(ticket.UserData);
                    string sessionIdStr = sessionId.ToString();

                    IApplicationContext context = ContextRegistry.GetContext();
                    var selfCleanableStorage = context.GetObject<SelfCleanableStorage>();

                    user = selfCleanableStorage[sessionIdStr] as UserPrincipal;

                    if (ticket.Expired || (user != null))
                    {
                        user = UserPrincipal.Empty;
                    }
                }
                UserPrincipal.CurrentUser = user;
                HttpContext.Current.User = user;
            }
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception is HttpException && ((HttpException)exception).GetHttpCode() == (int)HttpStatusCode.NotFound)
            {
                _log.Warn(String.Format(
                    "Warning has been occured in the application during execution the following url: {0} {1} {2}",
                    HttpContext.Current.Request.RawUrl, Environment.NewLine, exception.ToString()), exception);
            }
            else
            {
                _log.Error(
                    String.Format(
                        "Error has been occured in the application during execution the following url: {0} {1} {2}",
                        HttpContext.Current.Request.RawUrl, Environment.NewLine, exception.ToString()), exception);
            }
        }
    }
}
