using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PurchaseRequisitionAnalysis
    {
        [Key()]
        public int PurchaseRequisitionAnalysisId { get; set; }
        public int PurchaseRequisitionId { get; set; }
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        public int TransactionAnalysisId { get; set; }
        public virtual TransactionAnalysisSetup TransactionAnalysisSetup { get; set; }
        public int TransactionAnalysisSubSetupId { get; set; }
        public virtual TransactionAnalysisSubSetup TransactionAnalysisSubSetup { get; set; }
    }
}
