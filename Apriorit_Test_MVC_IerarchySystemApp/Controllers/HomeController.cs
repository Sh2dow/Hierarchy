using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apriorit_Test_MVC_IerarchySystemApp.Controllers
{
    public class HomeController : Controller
    {

        ApplicationContext db = new ApplicationContext();

        public ActionResult Menu()
        {
            List<MenuItem> menuItems = db.MenuItems.ToList();

            return PartialView(menuItems);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}