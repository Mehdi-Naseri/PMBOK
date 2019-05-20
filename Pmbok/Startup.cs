using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pmbok.Startup))]
namespace Pmbok
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
