using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicCreator.MVC.Startup))]
namespace MagicCreator.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
