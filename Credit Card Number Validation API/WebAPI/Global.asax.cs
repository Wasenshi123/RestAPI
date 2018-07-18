using System.Web.Http;
using System.Web.Mvc;
using Wasenshi.CreditCard.WebAPI;
using Castle.Windsor;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                WebApiConfig.Register(config);
                FilterConfig.Register(config.Filters);
                //Serialize Enum as String in JSON
                config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                    new StringEnumConverter {CamelCaseText = false});
                JsonConvert.DefaultSettings = () =>
                {
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
                    return settings;
                };
                
            });
        }
    }
}
