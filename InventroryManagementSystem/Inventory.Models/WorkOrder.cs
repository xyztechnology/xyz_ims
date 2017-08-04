using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class WorkOrder
    {[Key()]
        public int WorkOrderId { get; set; }
        public string WorkOrderNumber { get; set; }
        public int? LastModUserId { get; set; }
        [ForeignKey("LastModUserId")]
        public virtual User UserId { get; set; }
        public DateTime? LastModDttm { get; set; }

        public int? CreatedUserId { get; set; }
        [ForeignKey("CreatedUserId")]
        public virtual User CreUserId { get; set; }
        public DateTime? CreatedDttm { get; set; }
        public string AssembledBy { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
       
        public decimal? ExtraCost { get; set; }
        [NotMapped()]
        public List<WorkOrder> WorkOrderList { get; set; }
       
        [NotMapped]
        public WorkOrderLine workOrderLine { get; set; }

    }
}
