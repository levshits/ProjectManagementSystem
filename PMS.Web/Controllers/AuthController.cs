using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Levshits.Data.Common;
using Levshits.Web.Common.Controllers;
using PMS.Common;
using PMS.Common.Dto;
using PMS.Common.Request;
using PMS.Web.Models;
using PMS.Web.Storages;

namespace PMS.Web.Controllers
{
    public class AuthController : BaseController
    {
        public const string LogoutAction = "Logout";
        public SelfCleanableStorage SelfCleanableStorage { get; set; }
        public const string IndexAction = "Index";
        public const string LoginAction = "Login";
        public const string Name = "Auth";

        public ActionResult Index()
        {
            var model = new UserLoginModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                ExecutionResult<PrincipalDto> result = CommandBus.ExecuteCommand(new LoginRequest()
                {
                    Username = model.Username, Password = model.Password
                }) as ExecutionResult<PrincipalDto>;
                if (result != null && (result.Success && result.TypedResult!=null))
                {
                    UserPrincipal.CurrentUser = new UserPrincipal(result.TypedResult);
                    PrepareCookieForCurrentPrincipal(HttpContext);
                    return RedirectToAction(DashboardController.IndexAction, DashboardController.Name);
                }
                ModelState.AddModelError(string.Empty, "Please check entered login and username");
            }
            return View(IndexAction, model);
        }

        public ActionResult Logout()
        {
            UserPrincipal.CurrentUser = UserPrincipal.Empty;
            FormsAuthentication.SignOut();
            return RedirectToAction(IndexAction);
        }

        public void PrepareCookieForCurrentPrincipal(HttpContextBase httpContext)
        {
            FormsAuthenticationTicket tempTicket =
                    FormsAuthentication.Decrypt(
                        FormsAuthentication.GetAuthCookie(UserPrincipal.CurrentUser.Identity.Name, false).Value);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, // version
                                                                                 UserPrincipal.CurrentUser.Identity.
                                                                                     Name, // Username
                                                                                 tempTicket.IssueDate, // issue date
                                                                                 tempTicket.Expiration, // expiration
                                                                                 false, // persistance
                                                                                 UserPrincipal.CurrentUser.SessionId
                                                                                     .ToString(), // session id
                                                                                 FormsAuthentication.FormsCookiePath);
            // cookie path
            // Encrypt the ticket
            string encrAuthTicket = FormsAuthentication.Encrypt(authTicket);
            // Build auth cookie
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrAuthTicket);

            SelfCleanableStorage[UserPrincipal.CurrentUser.SessionId.ToString()] = UserPrincipal.CurrentUser;

            httpContext.User = UserPrincipal.CurrentUser;
            httpContext.Response.Cookies.Add(authCookie);
        }
    }
}