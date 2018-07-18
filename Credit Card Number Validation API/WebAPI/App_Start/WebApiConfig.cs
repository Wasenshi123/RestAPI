using Castle.Windsor;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Wasenshi.CreditCard.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Replace(typeof(IHttpControllerActivator), new WindsorConfig());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
