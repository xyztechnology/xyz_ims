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
using System.Data.Entity.Infrastructure;

namespace InventroryManagementSystem.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PurchaseRequisition/
        public async Task<ActionResult> Index()
        {
            var purchaserequisition = db.PurchaseRequisition.Include(p => p.Location).Include(p => p.Vendor);
            return View(await purchaserequisition.ToListAsync());
        }

        // GET: /PurchaseRequisition/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaserequisition = await db.PurchaseRequisition.FindAsync(id);
            if (purchaserequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaserequisition);
        }

        // GET: /PurchaseRequisition/Create
        public ActionResult Create()
        {
            PurchaseRequisition purreq = new PurchaseRequisition();
            purreq.PurchaseRequisitionLine = new PurchaseRequisitionLine();
            purreq.PurchaseRequisitionLine.PurchaseRequisitionLineList = new List<PurchaseRequisitionLine>();
            purreq.PurchaseRequisitionLine.PurchaseRequisitionLineList.Add(purreq.PurchaseRequisitionLine);

            purreq.PurchaseRequisitionList = db.PurchaseRequisition.Include(v => v.Vendor).Include(v=>v.Location).ToList();



            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name");
            ViewBag.VendorId = new SelectList(db.Vendor, "VendorId", "Name");
            return View(purreq);
        }

        public ActionResult _OrderList()
        {
            PurchaseRequisitionLine prq = new PurchaseRequisitionLine();
            return PartialView(prq);
        }
        // POST: /PurchaseRequisition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseRequisition purchaserequisition)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dbnew = new ApplicationDbContext())
                {

                    if (purchaserequisition.PurchaseRequisitionId == 0)
                    {
                        PurchaseRequisition purreqnew = new PurchaseRequisition();
                        purreqnew.RequisitionNo = purchaserequisition.RequisitionNo;
                        purreqnew.RequisitionDate = purchaserequisition.RequisitionDate;
                        purreqnew.VendorId = purchaserequisition.VendorId;
                        purreqnew.LocationId = purchaserequisition.LocationId;
                        purreqnew.AdditionalRequirements = purchaserequisition.AdditionalRequirements;
                        purreqnew.Remarks = purchaserequisition.Remarks;

                        dbnew.PurchaseRequisition.Add(purreqnew);

                        if(purchaserequisition.PurchaseRequisitionLine !=null && purchaserequisition.PurchaseRequisitionLine.PurchaseRequisitionLineList !=null)
                        {
                            foreach(var item in purchaserequisition.PurchaseRequisitionLine.PurchaseRequisitionLineList)
                            {
                                item.PurchaseRequisitionId = purreqnew.PurchaseRequisitionId;
                                dbnew.PurchaseRequisitionLine.Add(item);
                            }
                            dbnew.SaveChanges();
                        }

                    }
                    purchaserequisition.PurchaseRequisitionList = new List<PurchaseRequisition>();
                    purchaserequisition.PurchaseRequisitionList = db.PurchaseRequisition.Include(v => v.Vendor).Include(v => v.Location).ToList();
                    return RedirectToAction("Create");
                }

              
            }
            return View(purchaserequisition);
            //ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", purchaserequisition.LocationId);
            //ViewBag.VendorId = new SelectList(db.Vendor, "VendorId", "Name", purchaserequisition.VendorId);
         
        }
        //search for create page

        public ActionResult Search(PurchaseRequisition model, string RequisitionNo)
        {
            IEnumerable<PurchaseRequisition> list = db.PurchaseRequisition;
            if (!string.IsNullOrEmpty(RequisitionNo))
            {
               list=list.Where(x=>x.RequisitionNo.Contains(RequisitionNo));
            }
            if (model.RequisitionDate !=null)
            {
               list=list.Where(x=>x.RequisitionDate==model.RequisitionDate);
            }
            //else
            //{
            //    reqdt = "'" + Convert.ToDateTime(model.RequisitionDate).ToString("yyyy/MM/dd") + "'";
            //}

            //string prolist = "SP_GetPurchaseRequisition_Search" + " " + RequisitionNo + "," + reqdt;

            //((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            //var list = db.Database.SqlQuery<PurchaseRequisition>(prolist).ToList();
            model.PurchaseRequisitionList = list.ToList();
            return PartialView("_CreateSearchList", model);
        }
        // GET: /PurchaseRequisition/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaserequisition = await db.PurchaseRequisition.FindAsync(id);
            if (purchaserequisition == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", purchaserequisition.LocationId);
            ViewBag.VendorId = new SelectList(db.Vendor, "VendorId", "Name", purchaserequisition.VendorId);
            return View(purchaserequisition);
        }

        // POST: /PurchaseRequisition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PurchaseRequisitionId,RequisitionNo,RequisitionDate,VendorId,LocationId,AdditionalRequirements,Remarks")] PurchaseRequisition purchaserequisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaserequisition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", purchaserequisition.LocationId);
            ViewBag.VendorId = new SelectList(db.Vendor, "VendorId", "Name", purchaserequisition.VendorId);
            return View(purchaserequisition);
        }

        // GET: /PurchaseRequisition/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaserequisition = await db.PurchaseRequisition.FindAsync(id);
            if (purchaserequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaserequisition);
        }

        // POST: /PurchaseRequisition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PurchaseRequisition purchaserequisition = await db.PurchaseRequisition.FindAsync(id);
            db.PurchaseRequisition.Remove(purchaserequisition);
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
