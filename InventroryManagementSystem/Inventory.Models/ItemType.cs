﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class ItemType
    {
        [Key()]
        public int ItemTypeId { get; set; }
        public string ItemName { get; set; }
    }
}
