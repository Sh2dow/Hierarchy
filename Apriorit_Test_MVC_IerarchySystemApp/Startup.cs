using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apriorit_Test_MVC_IerarchySystemApp.Startup))]
namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
