using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class IssuseAnalysis
    {
        [Key()]
        public int IssuseAnalysisId { get; set; }
        public int SalesOrderId { get; set; }
        public virtual SalesOrder SalesOrder { get; set; } 
        public int TransactionAnalysisId { get; set; }
        public virtual TransactionAnalysisSetup TransactionAnalysisSetup { get; set; }
        public int TransactionAnalysisSubSetupId { get; set; }
        public virtual TransactionAnalysisSubSetup TransactionAnalysisSubSetup { get; set; }
 

    }
}
