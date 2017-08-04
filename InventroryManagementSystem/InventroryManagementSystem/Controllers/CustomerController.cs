﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using InventroryManagementSystem.Models;

namespace InventroryManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Customer/
        public ActionResult Index()
        {
            Customer model = new Customer();
            model.CustomerList = new List<Customer>();
       
            model.CustomerList = db.Customer.ToList();
            return View(model);
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            ViewBag.DefaultLocationId = new SelectList(db.Location, "LocationId", "Name");
            ViewBag.LastModUserId = new SelectList(db.User, "UserId", "Name");
            Customer customer = new Customer();
            customer.CustomerList = new List<Customer>();
            customer.CustomerList = db.Customer.Include(c => c.Location).Include(c => c.UserId).ToList();
            return View(customer);
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(Customer customer)
        {
            
                if (customer.CustomerId == 0)
                {
                    if(customer.DefaultLocationId !=null)
                    {
                        db.Customer.Add(customer);
                        db.SaveChanges();
                    }

                            
                }
                var customerlist = db.Customer.Include(c => c.Location).Include(c => c.UserId);
                customer.CustomerList = new List<Customer>();
                customer.CustomerList = customerlist.ToList();
                return PartialView("_CustomerList", customer);

            
        }
        public ActionResult Search(Customer model)
        {
            IEnumerable<Customer> list = db.Customer;
            if (!string.IsNullOrEmpty(model.Name))
            {
                list = list.Where(x => x.Name.Contains(model.Name));
            }

            if (!string.IsNullOrEmpty(model.ContactName))
            {
                

                list = list.Where(x => x.ContactName.Contains(model.ContactName));
            }
            if(model.Phone !=null)
            {

                list = list.Where(x => x.Phone == model.Phone);
            }

            model.CustomerList = list.ToList();
            return PartialView("_CustomerList", model);
        }







        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DefaultLocationId = new SelectList(db.Location, "LocationId", "Name", customer.DefaultLocationId);
            ViewBag.LastModUserId = new SelectList(db.User, "UserId", "Name", customer.LastModUserId);
            return PartialView("_Common", customer);
        }

       
        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
