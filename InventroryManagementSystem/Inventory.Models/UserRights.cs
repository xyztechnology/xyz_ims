using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class UserRights
    { [Key()]
        public int UserRightsId { get; set; }
        public int UserId { get; set; }
        public int RightNumber { get; set; }
    }
}
