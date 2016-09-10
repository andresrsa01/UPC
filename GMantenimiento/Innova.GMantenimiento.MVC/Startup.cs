using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Innova.GMantenimiento.MVC.Startup))]
namespace Innova.GMantenimiento.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
