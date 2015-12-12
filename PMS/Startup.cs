using Microsoft.Owin;
using Owin;
using PMS.Web;

[assembly:OwinStartup(typeof(Startup))]
namespace PMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}