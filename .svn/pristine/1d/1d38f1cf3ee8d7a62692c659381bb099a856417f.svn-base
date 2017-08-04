using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class SubLocation
    {
        [Key()]
        public int SubLocationId { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        public string SubLocationName { get; set; }
        [NotMapped]
        public List<SubLocation> SubLocationList { get; set; }
    }
}
