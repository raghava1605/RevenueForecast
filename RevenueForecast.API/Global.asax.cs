using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using RevenueForecast.Common.Business;
using RevenueForecast.Common.Models.Interfaces;
using RevenueForecast.Common.Data;
using RevenueForecast.API.App_Start;

namespace RevenueForecast.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IContainer container;

        protected void Application_Start()
        {
            container = RegisterContainer();
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            // Register your Web API controllers.
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterType<CustomerRepository>().As<ICustomer>().SingleInstance();
            builder.RegisterType<OperationalPortalDBEntities>().SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            return container;
        }
    }
}
