using System.Web.Http;
using System.Web.Mvc;
using Wasenshi.CreditCard.WebAPI;
using Castle.Windsor;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
        }
    }
}
