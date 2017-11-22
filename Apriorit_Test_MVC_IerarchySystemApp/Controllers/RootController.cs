using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Apriorit_Test_MVC_IerarchySystemApp.Controllers
{
    public class RootController : Controller
    {

        ApplicationContext db = new ApplicationContext();

        public ActionResult Index(int? Id)
        {
            if (Id == null)
            {
                Id = 1;
            }
            List<FolderItem> menuItems = db.MenuItems.
                Where(x => x.Order == Id).
                ToList();


            return PartialView(menuItems);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                Id = 0;
            }

            List<FolderItem> menuItems = db.MenuItems.
                Where(x => x.ParentId == Id).
                ToList();

            ViewBag.Folder = db.MenuItems.FirstOrDefault(x => x.Id == Id).VirtualPath;

            return PartialView(menuItems);
        }



        public ActionResult myAction(string url)
        {
            string[] hierarchy = url.Split('/');

            string firstPart = hierarchy.Count() > 0 ? hierarchy[0] : string.Empty;
            StringBuilder urlBuilder = new StringBuilder(firstPart);
            for (int index = 1; index < hierarchy.Count(); index++)
            {
                urlBuilder.Append("/");
                urlBuilder.Append(hierarchy[index]);
            }

            return PartialView(urlBuilder.ToString());
        }

    }
}