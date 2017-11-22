using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apriorit_Test_MVC_IerarchySystemApp.Controllers
{
    public class RootController : Controller
    {

        ApplicationContext db = new ApplicationContext();

        public ActionResult Index()
        {
            List<MenuItem> menuItems = db.MenuItems.ToList();

            return PartialView(menuItems);
        }

    }
}