using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperHerosProject.Startup))]
namespace SuperHerosProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
