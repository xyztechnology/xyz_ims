using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Inventorystore
    {
         [Key()]
         public int InventorystoreId { get; set; }
         public int? LocationId { get; set; }
         public virtual Location Location { get; set; }
         public int? SublocationId { get; set; }
         public virtual SubLocation SubLocation { get; set; }
         public decimal Quantity { get; set; }
         public decimal Rate { get; set; }
         public decimal Amount { get; set; }
         public Byte[] TimeStamp { get; set; }
         public int? ProdId { get; set; }
         [ForeignKey("ProdId")]
         public virtual Product Product { get; set; }
         [NotMapped()]
         public List<Inventorystore> InventoryStorList { get; set; }

    }
}
