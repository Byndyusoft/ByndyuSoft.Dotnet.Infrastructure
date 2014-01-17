namespace Web
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using AutoMapper;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Mvc4Sample.Web.Application.Account.Profiles;
    using EnumerableExtensions = MvcExtensions.EnumerableExtensions;

    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterProfiles();

            BootstrapContainer();
        }

        private static void RegisterProfiles()
        {
            EnumerableExtensions.Each(typeof (UserProfile)
                                          .Assembly
                                          .GetTypes()
                                          .Where(x => typeof (Profile).IsAssignableFrom(x)), x => Mapper.AddProfile((Profile) Activator.CreateInstance(x)));
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}