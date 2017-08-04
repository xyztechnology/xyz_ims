using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PurchaseOrderAttachment
    {
        [Key()]
        public int PurchaseOrderAttachmentId { get; set; }
        public int? PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public int? FileAttachmentId { get; set; }
        [ForeignKey("FileAttachmentId")]
        public virtual FileAttachment FileAttachment { get; set; }
        public Byte[] TimeStamp { get; set; }  
    }
}
