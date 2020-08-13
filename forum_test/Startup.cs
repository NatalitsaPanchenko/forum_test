using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(forum_test.Startup))]
namespace forum_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
