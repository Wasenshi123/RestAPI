using System.Web.Mvc;
using System.Web.Routing;

namespace WebAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}/{id}",
                defaults: new { controller = "CreditCardValidation", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
