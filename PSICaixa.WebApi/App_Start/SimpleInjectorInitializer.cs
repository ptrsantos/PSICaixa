

using PSICaixa.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web.Http;

namespace PSICaixa.WebApi.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.AllowOverridingRegistrations = true;

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration, Assembly.GetExecutingAssembly());

            //container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapperPSICaixa.Register(container, Lifestyle.Scoped);
        }
    }
}