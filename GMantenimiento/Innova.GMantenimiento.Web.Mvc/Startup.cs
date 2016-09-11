using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMSTp2.WebSite.Startup))]
namespace GMSTp2.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
