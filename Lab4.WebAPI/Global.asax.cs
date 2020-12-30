using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Modules;
using Lab3.BLL.Infrastructure;
using Ninject;
using Ninject.Web.WebApi;
using Lab4.WebAPI.DI;
using Lab4.WebAPI.App_Start;

namespace Lab4.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(NinjectWebCommon.Kernel);
        }
    }
}
