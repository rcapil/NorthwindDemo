using Autofac;
using Autofac.Integration.Mvc;
using NorthwindProducts.Web.DI;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NorthwindProducts.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapAutofac();
        }

        private void BootstrapAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
