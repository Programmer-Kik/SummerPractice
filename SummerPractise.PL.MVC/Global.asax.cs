using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using SummerPractise.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SummerPractise.PL.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = new StandardKernel();
            kernel.Bind<IUserLogic>().To<UserLogic>();
            kernel.Bind<IBookLogic>().To<BookLogic>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
