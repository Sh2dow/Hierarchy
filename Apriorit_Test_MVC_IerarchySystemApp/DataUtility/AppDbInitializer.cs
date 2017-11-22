using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            var menuItems = new List<MenuItem> {
                new MenuItem{Id=1, Header = "Creating Digital Images", Order = 1},
                new MenuItem{Id=2, Header = "Resources", Order = 2, ParentId = 1},
                new MenuItem{Id=3, Header = "Evidence", Order = 2, ParentId = 1},
                new MenuItem{Id=4, Header = "Graphice Products", Order = 2, ParentId = 1},
                new MenuItem{Id=5, Header = "Primary Resources", Order = 3, ParentId = 2},
                new MenuItem{Id=5, Header = "Secondary Resources", Order = 3, ParentId = 2},
                new MenuItem{Id=8, Header = "Process", Order = 3, ParentId = 4},
                new MenuItem{Id=9, Header = "Final Poducts", Order = 3, ParentId = 4}
            };

            db.MenuItems.AddRange(menuItems);
            db.SaveChanges();
        }
    }
}