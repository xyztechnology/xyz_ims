using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class TaxingScheme
    {
        [Key()]
        public int TaxingSchemeId { get; set; }
        public string Name { get; set; }
        public string  Tax1Name { get; set; }
        public string  Tax2Name { get; set; }
        public bool CalculateTax2OnTax1 { get; set; }
        public int LastModUserId { get; set; }
        public DateTime LastModDttm { get; set; }
        public Byte[] TimeStamp { get; set; }
        public bool IsActive { get; set; }
        public bool Tax1OnShipping { get; set; }
        public int? DefaultTaxCodeId { get; set; }
        [ForeignKey("DefaultTaxCodeId")]
        public virtual TaxCode TaxCodeId { get; set; }
        public bool Tax2OnShipping { get; set; }
    }
}
