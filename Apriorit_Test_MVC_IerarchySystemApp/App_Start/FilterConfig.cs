using System.Web;
using System.Web.Mvc;

namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
