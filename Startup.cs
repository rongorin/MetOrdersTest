using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetopeOrdersTest.Startup))]
namespace MetopeOrdersTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
