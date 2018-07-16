using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Forum.MVC.Startup))]
namespace Forum.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
