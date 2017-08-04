using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class ProductCategory
    {
        [Key()]
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        
        public string Name { get; set; }
        public bool TimeStamp { get; set; }
        [NotMapped]
        public int Idtosave{get;set;}
    }
}
