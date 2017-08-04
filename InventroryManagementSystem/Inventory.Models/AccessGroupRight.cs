using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
   public class AccessGroupRight
    {
       public int AccessGroupId { get; set; }
       public virtual AccessGroup AccessGroup { get; set; }
       [Key()]
       public int RightNumber { get; set; }
    }
}
