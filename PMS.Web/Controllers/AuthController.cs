using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Levshits.Web.Common.Controllers;
using PMS.Common;
using PMS.Web.Models;
using PMS.Web.Storages;

namespace PMS.Web.Controllers
{
    public class AuthController : BaseController
    {
        public SelfCleanableStorage SelfCleanableStorage { get; set; }
        public const string IndexAction = "Index";

        public override ActionResult Index()
        {
            var model = new UserLoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                
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