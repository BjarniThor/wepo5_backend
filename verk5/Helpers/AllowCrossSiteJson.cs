using System;
using System.Web.Http.Filters;

namespace Verkvaki.Helpers
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS");
            }                

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}

