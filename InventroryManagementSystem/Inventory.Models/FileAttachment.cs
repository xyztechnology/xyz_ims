﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Inventory.Models
{
    public  class FileAttachment
    {
        [Key()]
        public int FileAttachmentId { get; set; }
        public int? FileAttachmentType { get; set; }
        public string FileDescription { get; set; }
        public string FileName { get; set; }
        public Byte[] Data { get; set; }
        public int? LastModUserId { get; set; }
        [ForeignKey("LastModUserId")]
        public virtual User UserId { get; set; }
        public DateTime? LAstModDttm { get; set; }
        public Byte[] TimeStamp { get; set; }
        public Guid?  RandomGuid {get;set;}
        [NotMapped()]
        public List<FileAttachment> FileList { get; set; }

        [NotMapped()]
        public List<FileAttachment> NewFileList { get; set; }
          [NotMapped()]
        public HttpPostedFileBase file { get; set; }
    }
}
