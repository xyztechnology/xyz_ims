using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public  class PurchaseRequisitionLine
    {
        [Key()]
        public int PurchaseRequisitionLineId { get; set; }
        public int? PurchaseRequisitionId { get; set; }
        [ForeignKey("PurchaseRequisitionId")]
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        public int? ProdId { get; set; }
        [ForeignKey("ProdId")]
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public string VendorItemCode { get; set; }
        public decimal? Quantity { get; set; }
        [NotMapped]
        public List<PurchaseRequisitionLine> PurchaseRequisitionLineList { get; set; }

    }
}
