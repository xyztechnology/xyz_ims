using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public class UnitMeasure
    {
       [Key()]
       public int UnitMeasureId { get; set; }
       public string UnitName { get; set; }

       [NotMapped()]
       public List<UnitMeasure> UnitMeasureList { get; set; }
    }
}
