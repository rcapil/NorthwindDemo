using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindProducts.Web.Startup))]
namespace NorthwindProducts.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
