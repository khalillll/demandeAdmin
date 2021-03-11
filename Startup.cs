using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demandeAdmin.Startup))]
namespace demandeAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
