using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public  class PricingScheme
    {
        [Key()]
        public int PricingSchemeId { get; set; }
        public string Name { get; set; }
        public int? LastModUserId { get; set; }
        [ForeignKey("LastModUserId")]
        public virtual User UserId { get; set; }
        public DateTime LastModDttm { get; set; }
        public Byte[] Timestamp { get; set; }
        public bool IsActive { get; set; }
        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        public bool IsTaxInclusive { get; set; }
        

    }
}
