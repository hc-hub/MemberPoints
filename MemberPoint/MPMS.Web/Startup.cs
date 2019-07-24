using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MPMS.Web.Startup))]
namespace MPMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
