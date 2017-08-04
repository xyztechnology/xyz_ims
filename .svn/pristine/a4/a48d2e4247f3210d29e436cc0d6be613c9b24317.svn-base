using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ReceivedOrderDetail
    {
        [Key()]
        public int ReceivedOrderDetailId { get; set; }
        public int? ReceivedOrderId { get; set; }
        [ForeignKey("ReceivedOrderId")]
        public virtual ReceivedOrder ReceivedOrder { get; set; }
        public int? ProdId { get; set; }
        [ForeignKey("ProdId")]
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public string VendorItemCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SubTotal { get; set; }
        public bool IsReceived { get; set; }
        [NotMapped()]
        public List<ReceivedOrderDetail> ReceivedOrderDetailList { get; set; }
    }
}
