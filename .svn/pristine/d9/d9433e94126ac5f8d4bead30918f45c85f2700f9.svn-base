using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class FolderTreeModel
    {
        public class JsTreeModel
        {
            public JsTreeModel()
            {
                attr = new JsTreeAttribute();
                children = new HashSet<JsTreeModel>();
            }

            public string data;
            public JsTreeAttribute attr;
            public string state = "close";
            public ICollection<JsTreeModel> children;
            public int? ParentId { get; set; }
        }

        public class JsTreeAttribute
        {
            public int? id;
        }
        public class FolderData
        {
            public int? FolderId { get; set; }

            public int? ParentFolderId { get; set; }

            public string FolderName { get; set; }


            public string Type { get; set; }
        }
    }
}
