using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebInstruments.Startup))]
namespace WebInstruments
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
