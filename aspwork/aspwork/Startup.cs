using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspwork.Startup))]
namespace aspwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
