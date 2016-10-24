using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLSACH.Startup))]
namespace QLSACH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
