using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoSmart.Startup))]
namespace DoSmart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
