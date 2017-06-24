using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogicAuthorizeFilter.Startup))]
namespace LogicAuthorizeFilter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
