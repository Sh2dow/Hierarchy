using System.Collections.Generic;

namespace Apriorit_Test_MVC_IerarchySystemApp.Models
{
    public class FolderItem
    {
        public int Id { get; set; }
        public string VirtualPath { get; set; }
        public int? Order { get; set; }  
        public int? ParentId { get; set; }  
        public FolderItem Parent { get; set; }

        public ICollection<FolderItem> Children { get; set; }
        public FolderItem()
        {
            Children = new List<FolderItem>();
        }
    }

}