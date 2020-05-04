using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CycletexBikesMvc.Startup))]
namespace CycletexBikesMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
