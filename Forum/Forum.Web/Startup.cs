using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Forum.Web.Startup))]
namespace Forum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
