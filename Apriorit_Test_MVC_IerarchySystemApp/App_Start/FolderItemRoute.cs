using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public class FolderItemRoute : RouteBase
    {
        private object synclock = new object();
        ApplicationContext db = new ApplicationContext();

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData result = null;

            // Get params count to compare with order
            var slashesCount = httpContext.Request.RawUrl.Count(c => c == '/');
            var path = httpContext.Request.Path.Split('/').Last();

            // Get the page that matches.
            var page = GetPageList(httpContext)
                .Where(x => x.VirtualPath.Equals(path) && x.Order == slashesCount)
                .FirstOrDefault();

            if (page != null)
            {
                result = new RouteData(this, new MvcRouteHandler());

                // Optional - make query string values into route values.
                AddQueryStringParametersToRouteData(result, httpContext);

                // TODO: You might want to use the page object (from the database) to
                // get both the controller and action, and possibly even an area.
                // Alternatively, you could create a route for each table and hard-code
                // this information.
                result.Values["controller"] = "Root";
                result.Values["action"] = "Details";

                // This will be the primary key of the database row.
                // It might be an integer or a GUID.
                result.Values["id"] = page.Id;
            }

            // IMPORTANT: Always return null if there is no match.
            // This tells .NET routing to check the next route that is registered.
            return result;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;

            FolderItem page = null;

            // Get all of the pages from the cache.
            var pages = GetPageList(requestContext.HttpContext);

            if (TryFindMatch(pages, values, out page))
            {
                if (!string.IsNullOrEmpty(page.VirtualPath))
                {
                    result = new VirtualPathData(this, page.VirtualPath);
                }
            }

            // IMPORTANT: Always return null if there is no match.
            // This tells .NET routing to check the next route that is registered.
            return result;
        }

        private bool TryFindMatch(IEnumerable<FolderItem> pages, RouteValueDictionary values, out FolderItem page)
        {
            page = null;
            int id;

            // This example uses a int for an id. If it cannot be parsed,
            // we just skip it.
            if (!int.TryParse(Convert.ToString(values["id"]), out id))
            {
                return false;
            }

            var controller = Convert.ToString(values["controller"]);
            var action = Convert.ToString(values["action"]);

            // The logic here should be the inverse of the logic in 
            // GetRouteData(). So, we match the same controller, action, and id.
            // If we had additional route values there, we would take them all 
            // into consideration during this step.
            if (action == "Details" && controller == "Root")
            {
                page = pages
                    .Where(x => x.Id.Equals(id))
                    .FirstOrDefault();
                if (page != null)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddQueryStringParametersToRouteData(RouteData routeData, HttpContextBase httpContext)
        {
            var queryString = httpContext.Request.QueryString;
            if (queryString.Keys.Count > 0)
            {
                foreach (var key in queryString.AllKeys)
                {
                    routeData.Values[key] = queryString[key];
                }
            }
        }

        private IEnumerable<FolderItem> GetPageList(HttpContextBase httpContext)
        {
            string key = "__CustomPageList";
            var pages = httpContext.Cache[key];
            if (pages == null)
            {
                lock (synclock)
                {
                    pages = httpContext.Cache[key];
                    if (pages == null)
                    {
                        // TODO: Retrieve the list of FolderItem objects from the database here.
                        pages = db.MenuItems;

                        httpContext.Cache.Insert(
                            key: key,
                            value: pages,
                            dependencies: null,
                            absoluteExpiration: System.Web.Caching.Cache.NoAbsoluteExpiration,
                            slidingExpiration: TimeSpan.FromMinutes(15),
                            priority: System.Web.Caching.CacheItemPriority.NotRemovable,
                            onRemoveCallback: null);
                    }
                }
            }

            return (IEnumerable<FolderItem>)pages;
        }
    }
}