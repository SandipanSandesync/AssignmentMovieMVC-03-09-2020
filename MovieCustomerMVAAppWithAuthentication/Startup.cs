using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCustomerMVAAppWithAuthentication.Startup))]
namespace MovieCustomerMVAAppWithAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
