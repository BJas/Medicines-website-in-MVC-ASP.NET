using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(emde.kz.Startup))]
namespace emde.kz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
