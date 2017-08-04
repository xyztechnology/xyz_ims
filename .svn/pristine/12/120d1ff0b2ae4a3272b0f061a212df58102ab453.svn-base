using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Report
{
   public class Vendor
    {
       //filter parameter for vendorlist
       public int? VendorId { get; set; }
       public string City { get; set; }
       
       //filter parameter for vendor productlist
       public int? CategoryId { get; set; }
       public int? ProductId { get; set; }


       //for vendorlist report

       public string Name { get; set; }
       public string Contact { get; set; }
       public Int64? Phone { get; set; }
       public string Email { get; set; }
       public string Address { get; set; }

       //for vendor product list report

       public string Item { get; set; }
       public string Category { get; set; }
       public string VendorName { get; set; }
       public string VendorProductCode { get; set; }
       public decimal? UnitPrice { get; set; }


       [NotMapped()]
       public List<Vendor> VendorList { get; set; }


    }
}
