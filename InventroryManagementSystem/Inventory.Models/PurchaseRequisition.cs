using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
  public class PurchaseRequisition
    {

        [Key()]
        public int PurchaseRequisitionId { get; set; }

        public string RequisitionNo { get; set; }

        public DateTime? RequisitionDate { get; set; }

        public int? VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
        [NotMapped]
        public string ContactName { get; set; }
        [NotMapped]
        public string Phone { get; set; }
        [NotMapped]
        public string VendorAddress1 { get; set; }
        [NotMapped()]
        public string VendorName { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        public string AdditionalRequirements { get; set; }
        public string Remarks { get; set; }
        [NotMapped()]
        public List<PurchaseRequisition> PurchaseRequisitionList { get; set; }
        [NotMapped()]
        public PurchaseRequisitionLine PurchaseRequisitionLine { get; set; }
        [NotMapped()]
        public Product Product { get; set; }


    }
}
