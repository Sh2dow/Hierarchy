using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System.Collections.Generic;
using System.Linq;
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
            List<MenuItem> menuItems = db.MenuItems.
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

            List<MenuItem> menuItems = db.MenuItems.
                Where(x => x.ParentId == Id).
                ToList();

            ViewBag.Name = db.MenuItems.FirstOrDefault(x => x.Id == Id).VirtualPath;

            return PartialView(menuItems);
        }

    }
}