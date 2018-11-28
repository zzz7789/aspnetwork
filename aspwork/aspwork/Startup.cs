using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPwork.Startup))]
namespace ASPwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
