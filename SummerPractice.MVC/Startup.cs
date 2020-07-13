using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SummerPractice.MVC.Startup))]
namespace SummerPractice.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
