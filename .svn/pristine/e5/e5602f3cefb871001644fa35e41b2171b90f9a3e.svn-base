using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Inventory
    {
         [Key()]
         public int? LocationId { get; set; }
         public string Sublocation { get; set; }
         public decimal Quantity { get; set; }
         public Byte[] TimeStamp { get; set; }
         public int? ProdId { get; set; }
         [ForeignKey("ProdId")]
         public virtual Product Product { get; set; }

    }
}
