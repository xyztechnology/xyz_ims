using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.StoreProcedure
{
   public class ProductViewModel
    {
       public ProductService ProductService { get; set; }
       public Product Productobj { get; set; }
      
    }
}
