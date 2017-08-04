using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class CompanySetup
    {
        [Key()]
        public int CompanyId { get; set; }
        [NotMapped()]
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string TaxNumber { get; set; }
        public Byte[] TimeStamp { get; set; }
        public int? PictureFileAttachmentId { get; set; }
        [ForeignKey("PictureFileAttachmentId")]
        public virtual FileAttachment FileAttachment { get; set; }


        [NotMapped()]
        public byte[] Data { get; set; }
    }
}
