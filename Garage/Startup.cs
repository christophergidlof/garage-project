using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Garage.Startup))]
namespace Garage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
