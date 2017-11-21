using Apriorit_Test_MVC_IerarchySystemApp.Models;
using System.Data.Entity;

namespace Apriorit_Test_MVC_IerarchySystemApp.DataUtility
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }
        public DbSet<MenuItem> MenuItems { get; set; }
    }

}