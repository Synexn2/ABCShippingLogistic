using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABC.Startup))]
namespace ABC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
