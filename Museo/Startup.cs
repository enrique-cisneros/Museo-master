using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Museo.Startup))]
namespace Museo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
