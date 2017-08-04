using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public class ReceivedOrder
    {
       [Key()]
       public int ReceivedOrderId { get; set; }
       public string ReceivedNumber { get; set; }

       public DateTime? ReceivedDate { get; set; }


       public int? PurchaseOrderId { get; set; }
       [ForeignKey("PurchaseOrderId")]
       public virtual PurchaseOrder PurchaseOrder { get; set; }

       public int? VendorId { get; set; }
       [ForeignKey("VendorId")]
       public virtual Vendor Vendor { get; set; }
       
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
       public List<ReceivedOrder> ReceivedOrderList { get; set; }
       [NotMapped()]
       public Product Product { get; set; }


       [NotMapped()]
       public ReceivedOrderDetail ReceivedOrderDetail { get; set; }
       [NotMapped()]
       public PurchaseOrderDetail PurchaseOrderDetail { get; set; }
    }
}