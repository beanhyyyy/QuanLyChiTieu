using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLCT.Startup))]
namespace QLCT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
