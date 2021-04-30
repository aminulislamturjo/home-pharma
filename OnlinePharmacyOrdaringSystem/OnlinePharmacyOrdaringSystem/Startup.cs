using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlinePharmacyOrdaringSystem.Startup))]
namespace OnlinePharmacyOrdaringSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
