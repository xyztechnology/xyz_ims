﻿using Inventory.Models.StoreProcedure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Inventory.Models
{
    public class Product
    {
        [Key()]
        public int ProdId { get; set; }
        public int? Version { get; set; }
        public int? ItemTypeId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; }
        public int? DefaultLocationId { get; set; }
        [ForeignKey("DefaultLocationId")]
        public virtual Location Location { get; set; }
        public string DefaultSublocation { get; set; }

        //public int? LastVendorId { get; set; }
        //[ForeignKey("LastVendorId")]
        //public virtual Vendor VendorId { get; set; }

        public DateTime? DateUpdated { get; set; }
        public int? LastModUserId { get; set; }
        [ForeignKey("LastModUserId")]
        public virtual User UserId { get; set; }
        public DateTime? LastModDttm { get; set; }
        public Byte[] TimeStamp { get; set; }
        public bool IsActive { get; set; }

        public int? PictureFileAttachmentId { get; set; }
        [ForeignKey("PictureFileAttachmentId")]
        public virtual FileAttachment FileAttachment { get; set; }


        //ForUnitOfMeasurement
        [Display(Name="Standard UoM")]
        public int? Uom { get; set; }
        [ForeignKey("Uom")]
        public virtual UnitMeasure UnitMeasure_Uom
        {
            get;
            set;
        }

         [Display(Name = "Issue UoM")]
        public int? soUomName { get; set; }

         public decimal soUomRatioStd { get; set; }
         public decimal soUomRatio { get; set; }

         public int? PoUomName { get; set; }
         public decimal? PoUomRatioStd { get; set; }
         public decimal? PoUomRatio { get; set; }
         public decimal? InnerPackQty { get; set; }





        //to display
        [NotMapped()]
        public string ItemType { get; set; }
        [NotMapped()]
        public string ProdCategory { get; set; }
        [NotMapped()]
        public double UnitPrice { get; set; }
        [NotMapped()]
        public string Vendor { get; set; }

        [NotMapped()]
        public List<Product> ProductList { get; set; }
        [NotMapped()]
        public ProductService ProductService { get; set; }

        [NotMapped()]
        public HttpPostedFileBase file { get; set; }
        [NotMapped]
        public Inventorystore inventoryStore { get; set; }

    }
}
