using Inventory.Models.Report;
using InventroryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventroryManagementSystem.Controllers.Report
{
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: /Report/
        public ActionResult VendorList()
        {
            Vendor vendor = new Vendor();
            vendor.VendorList = new List<Vendor>();
            string vendorlist = "SP_GetVendorListReport" + " " + "null" + "," + "null" + "," + "null";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var list = db.Database.SqlQuery<Vendor>(vendorlist).ToList();

            vendor.VendorList = list.ToList();
            return View(vendor);
           
        }
        [HttpPost]
        public ActionResult VendorList(Vendor model)
        {

            var vendorid = model.VendorId.ToString();
            if (string.IsNullOrEmpty(vendorid))
            {
                vendorid = "null";
            }

            var phone = model.Phone.ToString();
            if (string.IsNullOrEmpty(phone))
            {
                phone = "null";
            }

            if (string.IsNullOrEmpty(model.City))
            {
                model.City = "null";
            }

            string s = "SP_GetVendorListReport" + " " + vendorid + "," + phone + "," + model.City;


            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 180;

            var list = db.Database.SqlQuery<Vendor>(s).ToList();
            //model.ExpensesOfficeWiseList = list.ToList();

            model.VendorList = list.ToList();

            return PartialView("_VendorListPartial",model);

        }
        public ActionResult VendorProductList()
        {
            Vendor vendor = new Vendor();
            vendor.VendorList = new List<Vendor>();
            string vendorprodlist = "SP_GetVendorProductListReport" + " " + "null" + "," + "null" + "," + "null";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var list = db.Database.SqlQuery<Vendor>(vendorprodlist).ToList();

            vendor.VendorList = list.ToList();
            return View(vendor);

        }
        [HttpPost]
        public ActionResult VendorProductList(Vendor model)
        {

            var vendorid = model.VendorId.ToString();
            if (string.IsNullOrEmpty(vendorid))
            {
                vendorid = "null";
            }

            var category = model.CategoryId.ToString();
            if (string.IsNullOrEmpty(category))
            {
                category = "null";
            }
            var product = model.ProductId.ToString();
            if (string.IsNullOrEmpty(product))
            {
                product = "null";
            }

            string s = "SP_GetVendorProductListReport" + " " + vendorid + "," + category + "," + product;


            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 180;

            var list = db.Database.SqlQuery<Vendor>(s).ToList();
            //model.ExpensesOfficeWiseList = list.ToList();

            model.VendorList = list.ToList();

            return PartialView("_VendorProductListPartial", model);

        }
        public ActionResult PurchaseOrderSummary()
        {
            PurchaseOrderSummary purchaseordersummary = new PurchaseOrderSummary();
            purchaseordersummary.PurchaseOrderSummaryList = new List<PurchaseOrderSummary>();
            string purchaseordersummarylist = "SP_GetPurchaseOrderSummaryReport" + " " + "null" + "," + "null" + "," + "null";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var list = db.Database.SqlQuery<PurchaseOrderSummary>(purchaseordersummarylist).ToList();

            purchaseordersummary.PurchaseOrderSummaryList = list.ToList();
            return View(purchaseordersummary);

        }

        [HttpPost]
        public ActionResult PurchaseOrderSummary(PurchaseOrderSummary model)
        {

            var vendorid = model.VendorId.ToString();
            if (string.IsNullOrEmpty(vendorid))
            {
                vendorid = "null";
            }

            var orderdate = model.OrderDate.ToString();
            if (string.IsNullOrEmpty(orderdate))
            {
                orderdate = "null";
            }
            else
            {
                orderdate = "'" + Convert.ToDateTime(model.OrderDate).ToString("yyyy/MM/dd") + "'";
            }

            
            if (string.IsNullOrEmpty(model.Status))
            {
                model.Status = "null";
            }

            string s = "SP_GetPurchaseOrderSummaryReport" + " " + vendorid + "," + orderdate + "," + model.Status;


            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 180;

            var list = db.Database.SqlQuery<PurchaseOrderSummary>(s).ToList();
           

            model.PurchaseOrderSummaryList = list.ToList();
            return PartialView("_PurchaseOrderSummaryPartial", model);

        }

        public ActionResult CurrentStock()
        {
            CurrentStock currentstock = new CurrentStock();
            currentstock.CurrentStockList = new List<CurrentStock>();
            string currentstocklist = "SP_GetCurrentStock" + " " + "null" + "," + "null" + "," + "null" + "," + "null" + "," + "null";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var list = db.Database.SqlQuery<CurrentStock>(currentstocklist).ToList();

            currentstock.CurrentStockList = list.ToList();
            return View(currentstock);

        }

        [HttpPost]
        public ActionResult CurrentStock(CurrentStock model)
        {
            var stockdate= model.Date.ToString();
            if (string.IsNullOrEmpty(stockdate))
            {
                stockdate = "null";
            }
            else
            {
                stockdate = "'" + Convert.ToDateTime(model.Date).ToString("yyyy/MM/dd") + "'";
            }
            var prodid = model.Itemid.ToString();
            if (string.IsNullOrEmpty(prodid))
            {
                prodid = "null";
            }
            var locationid = model.LocationId.ToString();
            if (string.IsNullOrEmpty(locationid))
            {
                locationid = "null";
            }
            var category = model.CategoryId.ToString();
            if (string.IsNullOrEmpty(category))
            {
                category = "null";
            }
            var producttype = model.ItemTypeId.ToString();
            if (string.IsNullOrEmpty(producttype))
            {
                producttype = "null";
            }

            string currentstocklist = "SP_GetCurrentStock" + " " + stockdate + "," + prodid + "," + locationid + "," + category + "," + producttype;


            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 180;

            var list = db.Database.SqlQuery<CurrentStock>(currentstocklist).ToList();
            //model.ExpensesOfficeWiseList = list.ToList();

            model.CurrentStockList = list.ToList();

            return PartialView("_CurrentStockPartial", model);

        }


	}
}