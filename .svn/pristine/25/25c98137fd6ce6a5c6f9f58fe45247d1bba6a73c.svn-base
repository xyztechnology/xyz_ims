using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Report
{
    public class PurchaseOrderSummary
    {
        public int? VendorId { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string PurchaseOrderStatus { get; set; }

        //for Purchase Order Summary Report

        public string OrderNo { get; set; }
        public string Status { get; set; }
        public string VendorName { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }

        [NotMapped()]
        public List<PurchaseOrderSummary> PurchaseOrderSummaryList { get; set; }

    }
}
