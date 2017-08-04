using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class SalesOrderDetail
    {
        [Key()]
        public int SalesOrderDetailId { get; set; }
        public int? SalesOrderId { get; set; }
        [ForeignKey("SalesOrderId")]
        public virtual SalesOrder SalesOrder { get; set; }
        public int? ProdId { get; set; }
        [ForeignKey("ProdId")]
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }
        [NotMapped()]
        public List<SalesOrderDetail> SalesOrderDetailList { get; set; }
    }
}
