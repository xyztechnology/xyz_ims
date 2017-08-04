using Inventory.Models.StoreProcedure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PurchaseOrder
    {
        [Key()]
        public int PurchaseOrderId { get; set; }

        public string OrderNo { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
        [NotMapped]
        public string ContactName { get; set; }
        [NotMapped]
        public string Phone { get; set; }
        [NotMapped]
        public string VendorAddress1 { get; set; }


        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        public string OrderRemarks { get; set; }

        public decimal? AmountPaid { get; set; }
       
        public decimal? SubTotal { get; set; }

        public decimal? Total { get; set; }
        public decimal? Balance { get; set; }
        [NotMapped]
        public string VendorName { get; set; }
        [NotMapped()]
        public List<PurchaseOrder> PurchaseOrderList { get; set; }
        [NotMapped()]
        public Product Product { get; set; }

        [NotMapped()]
        public PurchaseOrderAnalayis PurchaseOrderAnalayis { get; set; }
        [NotMapped()]
        public TransactionAnalysisSetup TransactionAnalysisSetup { get; set; }
        [NotMapped()]
        public TransactionAnalysisSubSetup TransactionAnalysisSubSetup { get; set; }
      

        [NotMapped()]
        public PurchaseOrderDetail PurchaseOrderDetail { get; set; }
    }
}