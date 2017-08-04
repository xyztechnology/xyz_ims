﻿using InventroryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventroryManagementSystem
{
    public class Utility
    {
        public static IEnumerable<SelectListItem> GetCustomerName()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return new SelectList(db.Customer, "CustomerId", "Name");
        }
        public static IEnumerable<SelectListItem> GetProductType()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return new SelectList(db.ItemType, "ItemTypeId", "ItemName");
        }
        public static IEnumerable<SelectListItem> GetProductCategory()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ProdCategoryList = db.ProductCategory.ToList();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "<Create New Category>", Value = "-1" });
            foreach(var item in ProdCategoryList)
            {
                list.Add(new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.ParentCategoryId.ToString()
                    });
            }
            return list.AsEnumerable();

            //return new SelectList(db.ProductCategory, "CategoryId", "Name");
        }
        public static IEnumerable<SelectListItem> GetLocation()
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
            return list.AsEnumerable();

        }
        public static byte[] ReturnByte(HttpPostedFileBase file)
        {
            byte[] buffer = null;

            if (file != null)
            {
                buffer = new byte[file.InputStream.Length];
                file.InputStream.Read(buffer, 0, buffer.Length);
            }
            return buffer;
        }

        public static IEnumerable<SelectListItem> GetVendor()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var VendorList = db.Vendor;
            var Vendorlist = new List<SelectListItem>();
            Vendorlist.Add(new SelectListItem { Text = "<Create New Vendor>", Value = "-1" });
            foreach (var item in VendorList)
            {
                Vendorlist.Add(new SelectListItem { Text = item.Name, Value = item.VendorId.ToString() });
            }
            return new SelectList(Vendorlist, "Value", "Text");

        }


        public static IEnumerable<SelectListItem> GetProductList()
        {
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    return new SelectList(db.Product, "ProdId", "Name");
            
            ApplicationDbContext db = new ApplicationDbContext();
            var ProductList = db.Product.ToList();


            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "<Create New product>", Value = "-1" });
            foreach (var item in ProductList)
            {

                list.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ProdId.ToString()
                });
            }
            return list.AsEnumerable();
        }

        public static IEnumerable<SelectListItem> GetMeasureList()
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

            return list.AsEnumerable();
        }

        public static IEnumerable<SelectListItem> GetPurchaseOrderNo()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return new SelectList(db.PurchaseOrder, "PurchaseOrderId", "OrderNo");
  
        }

        //public static IEnumerable<SelectListItem> GetTransactionSub()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    return new SelectList(db.TransactionAnalysisSubSetup, "TransactionAnalysisId", "Name");
  
        //}

        public static IEnumerable<SelectListItem> GetTransactionSub(int p)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return new SelectList(db.TransactionAnalysisSubSetup.Where(x=>x.TransactionAnalysisId==p), "TransactionAnalysisId", "Name");
  
        }

        public static object GetTransLabelName(int p)
        {
             ApplicationDbContext db = new ApplicationDbContext();
            var data = db.TransactionAnalysisSetup.Where(x => x.TransactionAnalysisId == p).FirstOrDefault();

            if (data != null)
            {
                var trananylsname = db.TransactionAnalysisSetup.Where(x => x.TransactionAnalysisId == data.TransactionAnalysisId).FirstOrDefault();
                if (trananylsname != null)
                {
                    return trananylsname.Name;
                }

            }
            return "";
  
        }


    }
}