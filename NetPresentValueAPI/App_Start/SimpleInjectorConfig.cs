namespace NetPresentValueAPI.App_Start
{
    using System.Web.Http;
    using Data.Interfaces;
    using Data.Models;
    using Service.Services;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;

    public class SimpleInjectorConfig
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IContext<NetPresentValue>, ContextService<NetPresentValue>>(Lifestyle.Scoped);
            container.Register<INetPresentValueService, NetPresentValueService>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}