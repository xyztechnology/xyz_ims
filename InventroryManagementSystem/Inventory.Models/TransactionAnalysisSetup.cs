﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class TransactionAnalysisSetup
    {
        [Key()]
        public int TransactionAnalysisId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        [NotMapped()]
        public int Idtosave { get; set; }
          [NotMapped()]
        public List<TransactionAnalysisSetup> TransactionAnalysisSetupList { get; set; }
    }

    public class TransactionAnalysisSubSetup
    {
        [Key()]
        public int TransactionAnalysisSubSetupId { get; set; }
        public int TransactionAnalysisId { get; set; }
        public virtual TransactionAnalysisSetup TransactionAnalysisSetup { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
         [NotMapped()]
        public List<TransactionAnalysisSubSetup> TransactionAnalysisSubSetupList { get; set; }
    }
}
