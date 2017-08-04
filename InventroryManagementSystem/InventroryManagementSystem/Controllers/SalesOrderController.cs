using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using InventroryManagementSystem.Models;
using System.Data.Entity.Infrastructure;
using Inventory.Models.StoreProcedure;

namespace InventroryManagementSystem.Controllers
{
    public class SalesOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /SalesOrder/
        public ActionResult Index()
        {

            SalesOrderViewModel model = new SalesOrderViewModel();
            model.SalesOrderService = new SalesOrderService();
            model.SalesOrderService.SalesOrderSearchList = new List<SalesOrderService>();


            string salesorderlist = "SP_GetSalesOrderIndexSearch" + " " + "null" + "," + "null" + "," + "null";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var list = db.Database.SqlQuery<SalesOrderService>(salesorderlist).ToList();

            model.SalesOrderService.SalesOrderSearchList = list.ToList();




            SalesOrder salesorder = new SalesOrder();
            salesorder.SaleOrderList = new List<SalesOrder>();
            salesorder.SaleOrderList = db.SalesOrder.Include(v => v.Customer).Include(v=>v.Location).ToList();
           // model.SaleOrderList = db.SalesOrder.Include(p => p.Location).Include(p => p.sa).ToList();
            return View("Index",model);
        }

        // GET: /SalesOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesorder = db.SalesOrder.Find(id);
            if (salesorder == null)
            {
                return HttpNotFound();
            }
            return View(salesorder);
        }

        // GET: /SalesOrder/Create

        public ActionResult Create()
        {
            SalesOrder so  = new SalesOrder();
            so.SalesOrderDetail = new SalesOrderDetail();
            so.SalesOrderDetail.SalesOrderDetailList = new List<SalesOrderDetail>();
            so.SalesOrderDetail.SalesOrderDetailList.Add(so.SalesOrderDetail) ;
            so.TransactionAnalysisSetup = new TransactionAnalysisSetup();
            so.TransactionAnalysisSetup.TransactionAnalysisSetupList = new List<TransactionAnalysisSetup>();
            so.TransactionAnalysisSetup.TransactionAnalysisSetupList = db.TransactionAnalysisSetup.ToList();
            so.TransactionAnalysisSubSetup = new TransactionAnalysisSubSetup();
            so.TransactionAnalysisSubSetup.TransactionAnalysisSubSetupList = new List<TransactionAnalysisSubSetup>();
            so.TransactionAnalysisSubSetup.TransactionAnalysisSubSetupList = db.TransactionAnalysisSubSetup.ToList();
          
           

            string salesorderno = "Sp_SO_SalesOrder_GetOrderNo";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var OrderNumber = db.Database.SqlQuery<string>(salesorderno).FirstOrDefault();
            so.OrderNumber = OrderNumber;

            so.SaleOrderList = db.SalesOrder.Include(v => v.Customer).ToList();
            return View(so);
        }

        public ActionResult _SalesOrderList()
        {
            SalesOrderDetail pr = new SalesOrderDetail();
            return PartialView(pr);
        }
        public ActionResult _IssueAnalysis()
        {
            TransactionAnalysisSubSetup issue = new TransactionAnalysisSubSetup();
            return PartialView(issue);
        }

        // POST: /SalesOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SalesOrder salesorder)
        {
            if (ModelState.IsValid)
            {

                using (ApplicationDbContext dbnew = new ApplicationDbContext())
                {
                    SalesOrder salesordernew = new SalesOrder();
                    salesordernew.CustomerId = salesorder.CustomerId;
                    salesordernew.LocationId = salesorder.LocationId;
                    salesordernew.OrderNumber = salesorder.OrderNumber;
                    salesordernew.OrderDate = salesorder.OrderDate;
                    salesordernew.OrderRemarks = salesorder.OrderRemarks;
                    salesordernew.AmountPaid = salesorder.AmountPaid;
                    salesordernew.Status = salesorder.Status;
                    salesordernew.OrderSubTotal = salesorder.OrderSubTotal;
                    salesordernew.Total = salesorder.Total;
                    salesordernew.Balance = salesorder.Balance;

                    dbnew.SalesOrder.Add(salesordernew);

                    //salesorder.SalesOrderDetail.SalesOrderId = salesorder.SalesOrderId;
                    if (salesorder.SalesOrderDetail != null && salesorder.SalesOrderDetail.SalesOrderDetailList != null)
                    {
                        foreach (var item in salesorder.SalesOrderDetail.SalesOrderDetailList)
                        {

                            item.SalesOrderId = salesordernew.SalesOrderId;

                            dbnew.SalesOrderDetail.Add(item);
                        }


                    }

                    dbnew.SaveChanges();
                    salesorder.SaleOrderList = new List<SalesOrder>();
                    salesorder.SaleOrderList = db.SalesOrder.Include(v => v.Customer).Include(v => v.Location).ToList();
                    return RedirectToAction("Create");
                }
            }
            //ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "Code", salesorder.CurrencyId);
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", salesorder.CustomerId);
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", salesorder.LocationId);
            //ViewBag.PaymentTermsId = new SelectList(db.ItemType, "PaymentTermsId", "Name", salesorder.PaymentTermsId);
            //ViewBag.ParentSalesOrderIdId = new SelectList(db.SalesOrder, "SalesOrderId", "OrderNumber", salesorder.ParentSalesOrderIdId);
            //ViewBag.LastModUserId = new SelectList(db.User, "UserId", "Name", salesorder.LastModUserId);
            return View(salesorder);
           
        }
        // GET: /SalesOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesorder = db.SalesOrder.Find(id);
            if (salesorder == null)
            {
                return HttpNotFound();
            }

            
            salesorder.Customer = new Customer();
            salesorder.Customer = db.Customer.Where(x => x.CustomerId == salesorder.CustomerId).FirstOrDefault();


            salesorder.Location = new Location();
            salesorder.Location = db.Location.Where(x => x.LocationId == salesorder.LocationId).FirstOrDefault();
            
            

            salesorder.SalesOrderDetail = new SalesOrderDetail();
            salesorder.SalesOrderDetail.SalesOrderDetailList = db.SalesOrderDetail.Where(x => x.SalesOrderId == salesorder.SalesOrderId).ToList();

            salesorder.SalesOrderDetail.Product = new Product();
            salesorder.SalesOrderDetail.Product = db.Product.Where(x => x.ProdId == salesorder.SalesOrderDetail.ProdId).FirstOrDefault();
            //ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", salesorder.CustomerId);
            //ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", salesorder.LocationId);
             return PartialView("_Common", salesorder);
        }

        // POST: /SalesOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SalesOrderId,Version,OrderNumber,OrderDate,CustomerId,SalesRep,PONumber,RequestShipDate,PaymentTermsId,DueDate,OrderRemarks,OrderSubTotal,OrderExtra,OrderTotal,Email,PickedDate,PickingRemarks,PackedDate,PackingRemarks,ShippingRemarks,InvoicedDate,AmountPaid,Balance,ReturnRemarks,ReturnSubTotal,ReturnExtra,ReturnTotal,ReturnFee,RestockRemarks,ContactName,Phone,BillingAddress1,BillingAddress2,BillingCity,BillingState,BillingCountry,BillingPostalCode,BillingAddressRemarks,BillingAddressType,ShippingAddress1,ShippingAddress2,ShippingCity,ShippingState,ShippingCountry,ShippingPostalCode,ShippingAddressRemarks,ShippingAddressType,Custom1,Custom2,Custom3,Custom4,Custom5,LastModUserId,LastModDttm,TimeStamp,ParentSalesOrderIdId,SplitPartNumber,LocationId,ShowShipping,ShipToCompanyName,CurrencyId,ExchangeRate,Total,PaymentStatus,InventoryStatus,IsCancelled,SummaryLinePermutation,NonCustomerCost,NonCustomerCostIsPercemt,IsQuote,IsInvoiced,IsCompleted,SameBillingAndShipping,IsTaxInclusive")] SalesOrder salesorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "Code", salesorder.CurrencyId);
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", salesorder.CustomerId);
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", salesorder.LocationId);
            //ViewBag.PaymentTermsId = new SelectList(db.ItemType, "PaymentTermsId", "Name", salesorder.PaymentTermsId);
            //ViewBag.ParentSalesOrderIdId = new SelectList(db.SalesOrder, "SalesOrderId", "OrderNumber", salesorder.ParentSalesOrderIdId);
            //ViewBag.LastModUserId = new SelectList(db.User, "UserId", "Name", salesorder.LastModUserId);
            return View(salesorder);
        }

        public ActionResult Search(SalesOrder model, string IssueNo)
        {
            IEnumerable<SalesOrder> list = db.SalesOrder;
            //if (!string.IsNullOrEmpty(model.OrderNumber))
            //{

            //    list = list.Where(x => x.OrderNumber.Contains(model.OrderNumber));

            //}
            if (!string.IsNullOrEmpty(IssueNo))
            {

                list = list.Where(x => x.OrderNumber.Contains(IssueNo));

            }
            if (!string.IsNullOrEmpty(model.Status))
            {
                list = list.Where(x => x.Status.Contains(model.Status));


            }
            int? customerid = model.CustomerId;
            if (!string.IsNullOrEmpty(customerid.ToString()))
            {
                list = list.Where(x => x.CustomerId == customerid);


            }
            model.SaleOrderList = list.ToList();
            return PartialView("_CreateSearchlist", model);
        }
       public ActionResult SearchIssueOrderList(SalesOrderViewModel model)
       {
           model.SalesOrderService = new SalesOrderService();
           model.SalesOrderService.SalesOrderSearchList = new List<SalesOrderService>();

           string orderno = model.SalesOrderObj.OrderNumber;
           if (string.IsNullOrEmpty(orderno))
           {
               orderno = "null";
           }
           else
           {

               orderno = "'" + orderno + "'";
           }
           var orderdt = model.SalesOrderObj.OrderDate.ToString();
           if (string.IsNullOrEmpty(orderdt))
           {
               orderdt = "null";
           }
           else
           {
               orderdt = "'" + Convert.ToDateTime(model.SalesOrderObj.OrderDate).ToString("yyyy/MM/dd") + "'";

           }
           var customerid = model.SalesOrderObj.CustomerId.ToString();
           if (string.IsNullOrEmpty(customerid))
           {
               customerid = "null";
           }

           string salesorderlist = "SP_GetSalesOrderIndexSearch" + " " + orderno + "," + orderdt + "," + customerid;

           ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

           var list = db.Database.SqlQuery<SalesOrderService>(salesorderlist).ToList();

           model.SalesOrderService.SalesOrderSearchList = list.ToList();

           return View("Index", model);


       }

        //GET: /SalesOrder/_Unpaid Issue
       public ActionResult _UnpaidIssue ()
       {

           SalesOrderViewModel model = new SalesOrderViewModel();
           model.SalesOrderService = new SalesOrderService();
           model.SalesOrderService.SalesOrderSearchList = new List<SalesOrderService>();


           string unpaidissuelist = "SP_GetSalesorder_Unpaidissue";

           ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

           var list = db.Database.SqlQuery<SalesOrderService>(unpaidissuelist).ToList();

           model.SalesOrderService.SalesOrderSearchList = list.ToList();

           return View("_UnpaidIssue", model);



       }

       //GET: /SalesOrder/_Recent Issue
       public ActionResult _RecentIssues()
       {

           SalesOrderViewModel model = new SalesOrderViewModel();
           model.SalesOrderService = new SalesOrderService();
           model.SalesOrderService.SalesOrderSearchList = new List<SalesOrderService>();


           string recentissuelist = "SP_GetSalesorder_Recentissues";

           ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

           var list = db.Database.SqlQuery<SalesOrderService>(recentissuelist).ToList();

           model.SalesOrderService.SalesOrderSearchList = list.ToList();

           return View("_RecentIssues", model);



       }


        // GET: /SalesOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesorder = db.SalesOrder.Find(id);
            if (salesorder == null)
            {
                return HttpNotFound();
            }
            return View(salesorder);
        }

        // POST: /SalesOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrder salesorder = db.SalesOrder.Find(id);
            db.SalesOrder.Remove(salesorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
