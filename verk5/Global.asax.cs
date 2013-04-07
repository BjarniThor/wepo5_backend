using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcApp.Helpers;

namespace verk5
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<verk5.Models.verk5Context>());
        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    //This is to allow cross domain ajax requests. 
        //    //http://www.cypressnorth.com/blog/programming/cross-domain-ajax-request-with-json-response-for-iefirefoxchrome-safari-jquery/
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT");
        //}
    }
}