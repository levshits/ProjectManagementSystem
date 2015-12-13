using System.Security.Claims;
using System.Threading.Tasks;
using Levshits.Data.Common;
using Microsoft.Owin.Security.OAuth;
using Spring.Context;
using Spring.Context.Support;
using Spring.Web.Mvc;

namespace PMS.Web.Security
{
    public class PmsOAuthProvider: OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            IApplicationContext springContext = ContextRegistry.GetContext();
            CommandBus commandBus = springContext.GetObject<CommandBus>("CommandBus");
            var identity = new ClaimsIdentity("otc");
            var username = context.OwinContext.Get<string>("otc:username");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user"));
            context.Validated(identity);
            return Task.FromResult(0);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];

                IApplicationContext springContext = ContextRegistry.GetContext();
                CommandBus commandBus = springContext.GetObject<CommandBus>("CommandBus");

                if (username == password)
                {
                    context.OwinContext.Set("otc:username", username);
                    context.Validated();
                }
                else
                {
                    context.SetError("Invalid credentials");
                    context.Rejected();
                }
            }
            catch
            {
                context.SetError("Server error");
                context.Rejected();
            }
            return Task.FromResult(0);
        }
    }
}