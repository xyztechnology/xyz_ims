using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PurchaseOrderReturnDetail
    {
        [Key()]
        public int PurchaseOrderReturnDetailId { get; set; }
        public int? PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public int? ProdId { get; set; }
        [ForeignKey("ProdId")]
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public string VendorItemCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SubTotal { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
