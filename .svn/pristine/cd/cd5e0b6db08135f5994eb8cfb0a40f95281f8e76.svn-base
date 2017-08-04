using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PurchaseOrderAnalayis
    {
        [Key()]
        public int PurchaseOrderAnalysisId { get; set; }
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public int TransactionAnalysisId { get; set; }
        public virtual TransactionAnalysisSetup TransactionAnalysisSetup { get; set; }
        public int TransactionAnalysisSubSetupId { get; set; }
        public virtual TransactionAnalysisSubSetup TransactionAnalysisSubSetup { get; set; }
        [NotMapped()]
        public List<PurchaseOrderAnalayis> PurchaseOrderAnalayisList { get; set; }
    }
}
