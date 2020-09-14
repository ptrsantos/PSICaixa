//using PSICaixa.IoC;
//using SimpleInjector;
//using SimpleInjector.Integration.WebApi;
//using SimpleInjector.Lifestyles;
//using System.Reflection;
//using System.Web.Http;

using PSICaixa.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web.Mvc;

namespace PSICaixa.Site.Mvc
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.AllowOverridingRegistrations = true; // Options.AllowOverridingRegistrations = true;

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            //DomainEvent.Container = new DomainEventsContainer(DependencyResolver.Current);

        }

        private static void InitializeContainer(Container container)
        {
            BootStrapperPSICaixa.Register(container, Lifestyle.Scoped);
        }
    }
}