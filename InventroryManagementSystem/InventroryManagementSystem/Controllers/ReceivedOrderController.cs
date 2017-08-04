using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using InventroryManagementSystem.Models;

namespace InventroryManagementSystem.Controllers
{
    public class ReceivedOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ReceivedOrder/
        public async Task<ActionResult> Index()
        {
            var receivedorder = db.ReceivedOrder.Include(r => r.Location).Include(r => r.PurchaseOrder);
            return View(await receivedorder.ToListAsync());
        }

        // GET: /ReceivedOrder/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceivedOrder receivedorder = await db.ReceivedOrder.FindAsync(id);
            if (receivedorder == null)
            {
                return HttpNotFound();
            }
            return View(receivedorder);
        }

        // GET: /ReceivedOrder/Create
        public ActionResult Create()
        {
            ReceivedOrder ro = new ReceivedOrder();
            ro.PurchaseOrderDetail = new PurchaseOrderDetail();
            ro.PurchaseOrderDetail.PurchaseOrderDetailList = new List<PurchaseOrderDetail>();
            ro.PurchaseOrderDetail.PurchaseOrderDetailList.Add(ro.PurchaseOrderDetail);
            ro.PurchaseOrder = new PurchaseOrder();
            ro.PurchaseOrder.PurchaseOrderList = new List<PurchaseOrder>();
            ro.PurchaseOrder.PurchaseOrderList= db.PurchaseOrder.Include(v => v.Vendor).ToList();
            return View(ro);
        }


        public ActionResult __ReceivedOrderList()
        {
            ReceivedOrderDetail pr = new ReceivedOrderDetail();
            return PartialView(pr);
        }

        // POST: /ReceivedOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceivedOrder receivedorder)
        {
            using (ApplicationDbContext dbnew = new ApplicationDbContext())
            {

                dbnew.ReceivedOrder.Add(receivedorder);
               
                if (receivedorder.ReceivedOrderDetail != null && receivedorder.ReceivedOrderDetail.ReceivedOrderDetailList != null)
                    {

                        foreach (var item in receivedorder.ReceivedOrderDetail.ReceivedOrderDetailList)
                        {

                            if (item.IsReceived == true)
                            {

                                ReceivedOrderDetail rod = new ReceivedOrderDetail();
                                rod.ReceivedOrderId = receivedorder.ReceivedOrderId;
                                rod.ProdId = item.ProdId;
                                rod.VendorItemCode = item.VendorItemCode;
                                rod.Quantity = item.Quantity;
                                rod.UnitPrice = item.UnitPrice;
                                rod.Discount = item.Discount;
                                rod.SubTotal = item.SubTotal;
                                rod.IsReceived = item.IsReceived;
                                dbnew.ReceivedOrderDetail.Add(rod);
                                dbnew.SaveChanges();
                            }
                            dbnew.SaveChanges();
                        }
                    }

                dbnew.SaveChanges();
              
                    return RedirectToAction("Create");
              
            }
            //return View(receivedorder);
        }


        public ActionResult Search(PurchaseOrder model, string Purchaseorderno)
        {
            IEnumerable<PurchaseOrder> list = db.PurchaseOrder;
            if (!string.IsNullOrEmpty(Purchaseorderno))
            {

                list = list.Where(x => x.OrderNo == Purchaseorderno);

            }


            int? vendorid = model.VendorId;
            if (!string.IsNullOrEmpty(vendorid.ToString()))
            {
                list = list.Where(x => x.VendorId == vendorid);


            }
            model.PurchaseOrderList = list.ToList();
            return PartialView("_ReceivedSearchlist", model);
        }



        // GET: /ReceivedOrder/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseorder = await db.PurchaseOrder.FindAsync(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }

            purchaseorder.Location = new Location();
            //purchaseorder.Location = db.Location.Where(x => x.LocationId == purchaseorder.LocationId).FirstOrDefault();


            purchaseorder.PurchaseOrderDetail = new PurchaseOrderDetail();
            ReceivedOrder reveicedorder = new ReceivedOrder();
            reveicedorder.PurchaseOrderDetail = new PurchaseOrderDetail();
            reveicedorder.PurchaseOrderDetail.PurchaseOrderDetailList = db.PurchaseOrderDetail.Where(x => x.PurchaseOrderId == purchaseorder.PurchaseOrderId).Where(x => x.IsReceived == false).ToList();
            reveicedorder.Location = db.Location.Where(x => x.LocationId == purchaseorder.LocationId).FirstOrDefault();
           
           // purchaseorder.PurchaseOrderDetail.PurchaseOrderDetailList = db.PurchaseOrderDetail.Where(x => x.PurchaseOrderId == purchaseorder.PurchaseOrderId).Where(x=>x.IsReceived==false).ToList();

            return PartialView("_Common", reveicedorder);


        }

        // POST: /ReceivedOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ReceivedOrderId,OrderNo,OrderDate,VendorId,LocationId,OrderRemarks,AmountPaid,Status,SubTotal,Total,Balance")] ReceivedOrder receivedorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receivedorder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", receivedorder.LocationId);
            ViewBag.VendorId = new SelectList(db.Vendor, "VendorId", "Name", receivedorder.PurchaseOrderId);
            return View(receivedorder);
        }

        // GET: /ReceivedOrder/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceivedOrder receivedorder = await db.ReceivedOrder.FindAsync(id);
            if (receivedorder == null)
            {
                return HttpNotFound();
            }
            return View(receivedorder);
        }

        // POST: /ReceivedOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReceivedOrder receivedorder = await db.ReceivedOrder.FindAsync(id);
            db.ReceivedOrder.Remove(receivedorder);
            await db.SaveChangesAsync();
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
