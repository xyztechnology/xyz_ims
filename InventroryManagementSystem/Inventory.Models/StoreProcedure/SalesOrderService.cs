using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.StoreProcedure
{
   public  class SalesOrderService
    {
       public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public decimal? Total { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public string @DocNo { get; set; }
        public int Phone { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public List<SalesOrderService> SalesOrderSearchList { get; set; }

    }
}
