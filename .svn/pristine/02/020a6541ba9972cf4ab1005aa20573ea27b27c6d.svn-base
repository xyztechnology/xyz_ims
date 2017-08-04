using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Report
{
   public  class CurrentStock
    {

       //Filter Parameter
       public DateTime? Date { get; set; }
       public int? Itemid { get; set; }
       public int? LocationId { get; set; }
       public int? CategoryId { get; set; }
       public int? ItemTypeId { get; set; } 

       //display parameter
       [NotMapped()]
       public string ItemName { get; set; }
       [NotMapped()]
       public string CategoryName { get; set; }
       [NotMapped()]
       public string LastVendor { get; set; }
       [NotMapped()]
       public string LocationName { get; set; }
       [NotMapped()]
       public decimal? Quantity { get; set; }
       [NotMapped()]
       public List<CurrentStock> CurrentStockList { get; set; }





    }
}
