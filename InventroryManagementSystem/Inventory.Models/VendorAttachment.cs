using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public class VendorAttachment
    {
       [Key()]
       public int VendorAttachmentId { get; set; }
       public int VendorId { get; set; }
       public virtual Vendor Vendor { get; set; }
       public int FileAttachmentId { get; set; }
       public virtual FileAttachment FileAttachment { get; set; }
    }
}
