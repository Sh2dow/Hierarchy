﻿using Apriorit_Test_MVC_IerarchySystemApp.DataUtility;
using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Apriorit_Test_MVC_IerarchySystemApp
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            var menuItems = new List<FolderItem> {
                new FolderItem{Id=1, VirtualPath = "Creating Digital Images", Order = 1},
                new FolderItem{Id=2, VirtualPath = "Resources", Order = 2, ParentId = 1},
                new FolderItem{Id=3, VirtualPath = "Evidence", Order = 2, ParentId = 1},
                new FolderItem{Id=4, VirtualPath = "Graphic Products", Order = 2, ParentId = 1},
                new FolderItem{Id=5, VirtualPath = "Primary Resources", Order = 3, ParentId = 2},
                new FolderItem{Id=5, VirtualPath = "Secondary Resources", Order = 3, ParentId = 2},
                new FolderItem{Id=8, VirtualPath = "Process", Order = 3, ParentId = 4},
                new FolderItem{Id=9, VirtualPath = "Final Poducts", Order = 3, ParentId = 4},
                new FolderItem{Id=10, VirtualPath = "Graphic Products", Order = 4, ParentId = 9},
            };

            db.MenuItems.AddRange(menuItems);
            db.SaveChanges();
        }
    }
}