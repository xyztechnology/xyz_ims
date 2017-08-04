﻿using InventroryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;

namespace InventroryManagementSystem.Controllers
{
    public class JsonRequestController : Controller
    {
        //
        // GET: /JsonRequest/
        public ActionResult GetVendorDetail(int vendorid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Vendor vendor = new Vendor();
            vendor = db.Vendor.Where(x => x.VendorId == vendorid).FirstOrDefault();
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUnitMeasure(int measureid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
       
                UnitMeasure unitmeasure = new UnitMeasure();
                unitmeasure = db.UnitMeasure.Where(x => x.UnitMeasureId == measureid).FirstOrDefault();
                return Json(unitmeasure, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUnitMeasure()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var UnitMeasurelist = db.UnitMeasure.ToList();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "<Create New Unit Measure>", Value = "-1" });
            foreach (var item in UnitMeasurelist)
            {

                list.Add(new SelectListItem
                {
                    Text = item.UnitName,
                    Value = item.UnitMeasureId.ToString()
                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductcode(int prodid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Product product = new Product();
            product = db.Product.Where(x => x.ProdId == prodid).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductDetail(int prodid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Inventorystore inventorystore = new Inventorystore();
            inventorystore = db.Inventorystore.Where(x => x.ProdId == prodid).FirstOrDefault();
            return Json(inventorystore, JsonRequestBehavior.AllowGet);
        }



        public ActionResult GetCustomerDetail(int customerid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Customer customer = new Customer();
            customer = db.Customer.Where(x => x.CustomerId == customerid).FirstOrDefault();
            return Json(customer, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetLocation()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Locationlist = db.Location.ToList();


            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "<Create New Location>", Value = "-1" });
            foreach (var item in Locationlist)
            {

                list.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.LocationId.ToString()
                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }

	}
}