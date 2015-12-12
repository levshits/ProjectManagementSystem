using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace PMS.Web.Security
{
    public class PmsOAuthOptions: OAuthAuthorizationServerOptions
    {
        public PmsOAuthOptions()
        {
            TokenEndpointPath = new PathString("/token");
            AccessTokenExpireTimeSpan = TimeSpan.FromHours(24);
            AccessTokenFormat = new PmsJwtFormat();
            Provider = new PmsOAuthProvider();
            AllowInsecureHttp = true;
        }
    }
}