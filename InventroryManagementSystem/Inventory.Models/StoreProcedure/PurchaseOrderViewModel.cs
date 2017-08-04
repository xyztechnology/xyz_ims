using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.StoreProcedure
{
    public class PurchaseOrderViewModel
    {
        public PurchaseOrderService PurchaseOrderService { get; set; }
        public PurchaseOrder PurchaseOrderObj { get; set; }
    }
}
