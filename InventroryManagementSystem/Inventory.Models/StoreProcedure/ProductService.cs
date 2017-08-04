using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.StoreProcedure
{
   public class ProductService
    {
       public List<ProductService> ProductSearchList { get; set; }
       public string Name { get; set; }
       public string ItemType { get; set; }
       public string ProdCategory { get; set; }
       public decimal? UnitPrice  { get; set;}
       public string Vendor { get; set; }
       public string ProductCode { get; set; }
       public string ItemName { get; set; }
       public string OrderNo { get; set; }
       public DateTime? OrderDate { get; set; }
       public string Status { get; set; }
       public decimal?  Total { get; set; }
       public decimal?  Quantity { get; set; }
       public decimal? SubTotal { get; set; }
       public string VendorName { get; set; }
           

    }
}
