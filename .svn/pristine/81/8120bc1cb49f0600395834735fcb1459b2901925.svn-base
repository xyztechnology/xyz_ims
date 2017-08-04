using Inventory.Models.StoreProcedure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Vendor
    {

        [Key()]
        public int VendorId { get; set; }
        public int? Version { get; set; }
        [Required]
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string DefaultCarrier { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AddressRemarks { get; set; }
        public int? AddressType { get; set; }
        public string ContactName { get; set; }
        public long? Phone { get; set; }
        public long? Fax { get; set; }
        public string Email { get; set; }
        public string PanNo { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public int? LastModUserId { get; set; }
        [ForeignKey("LastModUserId")]
        public virtual User UserId { get; set; }
        public DateTime? LastModDttm { get; set; }
        public Byte[] TimeStamp { get; set; }
        public bool? IsActive { get; set; }
        public string Custom6 { get; set; }
        public string Custom7 { get; set; }
        public string Custom8 { get; set; }
        public string Custom9 { get; set; }
        public string Custom10 { get; set; }
        public string WebSite { get; set; }
        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsTaxInclusivePricing { get; set; }
        public string DefaultPaymentMethod { get; set; }
        [NotMapped]
        public List<Vendor> VendorList { get; set; }
        [NotMapped]
        public VendorService VendorService { get; set; }
        [NotMapped]
        public FileAttachment FileAttachmentData { get; set; }





        [NotMapped]
        public int FileCount { get; set; }
    }
}
