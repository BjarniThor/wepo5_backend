using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebMatrix.WebData;

namespace verk5
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Added for returning JSON code instead of XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config = GlobalConfiguration.Configuration;
            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: false);
        }
    }
}
