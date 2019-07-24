using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemberPoint.Startup))]
namespace MemberPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
