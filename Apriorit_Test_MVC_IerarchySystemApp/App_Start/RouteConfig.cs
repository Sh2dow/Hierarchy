﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(
            name: "CustomPage",
            item: new FolderItemRoute());

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Root", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
