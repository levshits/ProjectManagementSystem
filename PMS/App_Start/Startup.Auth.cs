using Owin;
using PMS.Web.Security;

namespace PMS.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new PmsOAuthOptions());
            app.UseJwtBearerAuthentication(new PmsJwtOptions());
        }
    }
}