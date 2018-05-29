using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HSBOD.Startup))]
namespace HSBOD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
