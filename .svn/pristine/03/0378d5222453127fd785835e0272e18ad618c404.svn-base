using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public  class TaxCode
    {
        [Key()]
        public int TaxCodeId { get; set; }
        
        public string Name { get; set; }
        public decimal Tax1Rate { get; set; }
        public decimal Tax2Rate { get; set; }
        public bool IsActive { get; set; }
        public int?  LastModUserId { get; set; }
        [ForeignKey("LastModUserId")]
        public virtual User UserId { get; set; }
        public DateTime LastModDttm { get; set; }
        public Byte[] TimeStamp { get; set; }
       
    }
}
