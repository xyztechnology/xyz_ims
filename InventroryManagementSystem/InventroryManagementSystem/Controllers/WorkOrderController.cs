﻿using System;
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
    public class WorkOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /WorkOrder/
        public async Task<ActionResult> Index()
        {
            var workorder = db.WorkOrder.Include(w => w.CreUserId).Include(w => w.Location).Include(w => w.UserId);
            return View(await workorder.ToListAsync());
        }

        // GET: /WorkOrder/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workorder = await db.WorkOrder.FindAsync(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            return View(workorder);
        }

        // GET: /WorkOrder/Create
        public ActionResult Create()
        {
            WorkOrder wo = new WorkOrder();
            wo.workOrderLine = new WorkOrderLine();
            wo.workOrderLine.DestiProductLineList = new List<WorkOrderLine>();
            wo.workOrderLine.DestiProductLineList.Add(wo.workOrderLine);
            wo.workOrderLine.WorkOrderLineList = new List<WorkOrderLine>();
            wo.workOrderLine.WorkOrderLineList.Add(wo.workOrderLine);

            string prolist = "Sp_WorkedOrder_GetOrderNo";

            ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 280;

            var OrderNumber = db.Database.SqlQuery<string>(prolist).FirstOrDefault();
            wo.WorkOrderNumber = OrderNumber;

            wo.WorkOrderList = db.WorkOrder.Include(v => v.Location).ToList();


            return View(wo);
        }


        public ActionResult _WorkOrderLine()
        {
            WorkOrderLine wol = new WorkOrderLine();
            return PartialView(wol);
        }

        public ActionResult _DestProductLine()
        {
            WorkOrderLine wol = new WorkOrderLine();
            return PartialView(wol);
        }

        // POST: /WorkOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrder workorder)
        {

            using (ApplicationDbContext dbnew = new ApplicationDbContext())
            {
                if (workorder.WorkOrderId == 0)
                {
                    
                        WorkOrder workedeordernew = new WorkOrder();
                        workedeordernew.AssembledBy = workorder.AssembledBy;
                        workedeordernew.LocationId = workorder.LocationId;
                        workedeordernew.ExtraCost = workorder.ExtraCost;
                        workedeordernew.OrderDate = workorder.OrderDate;
                        workedeordernew.WorkOrderNumber = workorder.WorkOrderNumber;
                        workedeordernew.CompleteDate = workorder.CompleteDate;


                        dbnew.WorkOrder.Add(workedeordernew);
                        dbnew.SaveChanges();
                    
                  

                    if (workorder.workOrderLine != null && workorder.workOrderLine.DestiProductLineList != null && workorder.workOrderLine.WorkOrderLineList != null)
                    {

                        WorkOrderLine workline = new WorkOrderLine();
                        foreach (var item in workorder.workOrderLine.DestiProductLineList)
                        {
                           
                            workline.WorkOrderId = workedeordernew.WorkOrderId;
                            workline.ParentWorkOrderLineId = 0;
                            workline.ProdId = item.ProdId;
                            workline.Quantity = item.Quantity;
                            workline.PartsCost = item.PartsCost;
                            workline.TotalAverageCost = item.TotalAverageCost;

                            dbnew.WorkOrderLine.Add(workline);
                            dbnew.SaveChanges();
                        }
                        foreach (var itemnew in workorder.workOrderLine.WorkOrderLineList)
                        {
                            
                            itemnew.WorkOrderId = workedeordernew.WorkOrderId;
                            itemnew.ParentWorkOrderLineId = workline.WorkOrderLineId;

                            dbnew.WorkOrderLine.Add(itemnew);
                        }


                        dbnew.SaveChanges();
                    }
                }



                else
                {

                    var parentid = db.WorkOrderLine.Where(x => x.WorkOrderId == workorder.WorkOrderId).Where(x=>x.ParentWorkOrderLineId==0).FirstOrDefault().WorkOrderLineId;
                    dbnew.Entry(workorder).State = EntityState.Modified;
                   

                    if (workorder.workOrderLine != null && workorder.workOrderLine.DestiProductLineList != null && workorder.workOrderLine.WorkOrderLineList != null)
                    {


                        foreach (var item in workorder.workOrderLine.DestiProductLineList)
                        {
                            ApplicationDbContext woc = new ApplicationDbContext();
                            var data = woc.WorkOrderLine.Where(x => x.WorkOrderLineId == item.WorkOrderLineId).FirstOrDefault();
                            if (data == null)
                            {
                                WorkOrderLine workline = new WorkOrderLine();
                                workline.WorkOrderId = workorder.WorkOrderId;
                                workline.ParentWorkOrderLineId =0;
                                workline.ProdId = item.ProdId;
                                workline.Quantity = item.Quantity;
                                workline.PartsCost = item.PartsCost;
                                workline.TotalAverageCost = item.TotalAverageCost;

                                woc.WorkOrderLine.Add(workline);
                                woc.SaveChanges();
                            }
                            else
                            {
                                data.WorkOrderId = workorder.WorkOrderId;
                                data.ProdId = item.ProdId;
                                data.ParentWorkOrderLineId =0;
                                data.Quantity = item.Quantity;
                                data.PartsCost = item.PartsCost;
                                data.TotalAverageCost = item.TotalAverageCost;
                                woc.Entry(data).State = EntityState.Modified;
                                woc.SaveChanges();

                            }

                        }
                        foreach (var itemnew in workorder.workOrderLine.WorkOrderLineList)
                        {
                            ApplicationDbContext woc = new ApplicationDbContext();
                            var data = woc.WorkOrderLine.Where(x => x.WorkOrderLineId == itemnew.WorkOrderLineId).FirstOrDefault();
                            if (data == null)
                            {
                                WorkOrderLine workline = new WorkOrderLine();
                                workline.WorkOrderId = workorder.WorkOrderId;
                                workline.ParentWorkOrderLineId = parentid; ;
                                workline.ProdId = itemnew.ProdId;
                                workline.Quantity = itemnew.Quantity;
                                workline.PartsCost = itemnew.PartsCost;
                                workline.TotalAverageCost = itemnew.TotalAverageCost;

                                woc.WorkOrderLine.Add(workline);
                                woc.SaveChanges();
                            }
                            else
                            {
                                data.WorkOrderId = workorder.WorkOrderId;
                                data.ProdId = itemnew.ProdId;
                                data.ParentWorkOrderLineId = itemnew.ParentWorkOrderLineId;
                                data.Quantity = itemnew.Quantity;
                                data.PartsCost = itemnew.PartsCost;
                                data.TotalAverageCost = itemnew.TotalAverageCost;
                                woc.Entry(data).State = EntityState.Modified;
                                woc.SaveChanges();

                            }


                            dbnew.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Create");
            }

       
        }


        public ActionResult Search(WorkOrder model)
        {
            IEnumerable<WorkOrder> list = db.WorkOrder;
            if (!string.IsNullOrEmpty(model.WorkOrderNumber))
            {

                list = list.Where(x => x.WorkOrderNumber.Contains(model.WorkOrderNumber));

            }

          
            int? locationid = model.LocationId;
            if (!string.IsNullOrEmpty(locationid.ToString()))
            {
                list = list.Where(x => x.LocationId == locationid);


            }
            model.WorkOrderList = list.ToList();
            return PartialView("_CreateSearchlist", model);
        }



        // GET: /WorkOrder/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workorder = await db.WorkOrder.FindAsync(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }

            workorder.Location = new Location();
            workorder.Location = db.Location.Where(x => x.LocationId == workorder.LocationId).FirstOrDefault();



            workorder.workOrderLine = new WorkOrderLine();
            workorder.workOrderLine.DestiProductLineList = db.WorkOrderLine.Where(x => x.WorkOrderId == workorder.WorkOrderId).Where(x=>x.ParentWorkOrderLineId==0).ToList();
            workorder.workOrderLine.WorkOrderLineList = db.WorkOrderLine.Where(x => x.WorkOrderId == workorder.WorkOrderId).Where(x => x.ParentWorkOrderLineId != 0).ToList();


            //workorder.SalesOrderDetail.Product = new Product();
            //salesorder.SalesOrderDetail.Product = db.Product.Where(x => x.ProdId == salesorder.SalesOrderDetail.ProdId).FirstOrDefault();
            ////ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", salesorder.CustomerId);
            //ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", salesorder.LocationId);
            return PartialView("_Common", workorder);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //WorkOrder workorder = await db.WorkOrder.FindAsync(id);
            //if (workorder == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.CreatedUserId = new SelectList(db.User, "UserId", "Name", workorder.CreatedUserId);
            //ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", workorder.LocationId);
            //ViewBag.LastModUserId = new SelectList(db.User, "UserId", "Name", workorder.LastModUserId);
            //return View(workorder);
        }

        // POST: /WorkOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="WorkOrderId,WorkOrderNumber,LastModUserId,LastModDttm,CreatedUserId,CreatedDttm,AssembledBy,OrderDate,CompleteDate,LocationId,Status,ExtraCost")] WorkOrder workorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workorder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedUserId = new SelectList(db.User, "UserId", "Name", workorder.CreatedUserId);
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "Name", workorder.LocationId);
            ViewBag.LastModUserId = new SelectList(db.User, "UserId", "Name", workorder.LastModUserId);
            return View(workorder);
        }

        // GET: /WorkOrder/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workorder = await db.WorkOrder.FindAsync(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            return View(workorder);
        }

        // POST: /WorkOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WorkOrder workorder = await db.WorkOrder.FindAsync(id);
            db.WorkOrder.Remove(workorder);
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
