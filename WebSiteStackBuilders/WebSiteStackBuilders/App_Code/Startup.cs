using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteStackBuilders.Startup))]
namespace WebSiteStackBuilders
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
