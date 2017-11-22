using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public sealed class UrlRouteHandler : IRouteHandler
    {
        ApplicationContext db = new ApplicationContext();
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var url = requestContext.HttpContext.Request.Url.ToString();
            var routeData = requestContext.RouteData.Values;

            // manage your rules here!

            routeData["controller"] = "Root";
            routeData["action"] = "Index";

            return new MvcHandler(requestContext);
        }
    }
}