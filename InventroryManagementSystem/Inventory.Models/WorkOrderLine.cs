﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class WorkOrderLine
    {
        [Key()]
        public int WorkOrderLineId { get; set; }
        public int WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public int ParentWorkOrderLineId { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUom { get; set; }
        public decimal QuantityDisplay { get; set; }
        public decimal PartsCost { get; set; }
        public int ProdId { get; set; }
        public virtual Product Product { get; set; }
        public decimal TotalAverageCost { get; set; }
        public int LineNum { get; set; }
        [NotMapped()]
        public List<WorkOrderLine> WorkOrderLineList { get; set; }
        [NotMapped()]
        public List<WorkOrderLine> DestiProductLineList { get; set; }

    }
     
}
