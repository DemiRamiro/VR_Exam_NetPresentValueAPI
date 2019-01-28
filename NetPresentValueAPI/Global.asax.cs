namespace NetPresentValueAPI
{
    using NetPresentValueAPI.App_Start;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MapperConfig.Initialize();
            SimpleInjectorConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}