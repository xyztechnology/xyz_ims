using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class DoCumentNoFormat
    {
        [Key()]
        public int DoCumentNoFormatId { get; set; }
        public int NextNumber { get; set; }
        public int MinDigits { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
       
        public string Preview { get; set; }
        [NotMapped()]
        public List<DoCumentNoFormat> DoCumentNoFormatList { get; set; }
    }
}
