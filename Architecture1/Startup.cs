using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Architecture1.Startup))]
namespace Architecture1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
