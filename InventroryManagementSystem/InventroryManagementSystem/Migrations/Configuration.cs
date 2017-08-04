namespace InventroryManagementSystem.Migrations
{
    using Inventory.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventroryManagementSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventroryManagementSystem.Models.ApplicationDbContext context)
        {
            IList<ProductCategory> Catlist = new List<ProductCategory>();

            Catlist.Add(new ProductCategory() { Name = "Product Categories", CategoryId = 1, ParentCategoryId = 0 });


            foreach (ProductCategory std in Catlist)
                context.ProductCategory.AddOrUpdate(std);


            IList<ItemType> Typelist = new List<ItemType>();

            Typelist.Add(new ItemType() { ItemName = "Stocked Product", ItemTypeId = 1 });
            Typelist.Add(new ItemType() { ItemName = "Fixed Assest", ItemTypeId = 2 });
            Typelist.Add(new ItemType() { ItemName = "Non Stocked Product", ItemTypeId = 3 });
            Typelist.Add(new ItemType() { ItemName = "Service", ItemTypeId = 4 });


            foreach (ItemType std in Typelist)
                context.ItemType.AddOrUpdate(std);


            IList<DoCumentNoFormat> Documentlist = new List<DoCumentNoFormat>();

            Documentlist.Add(new DoCumentNoFormat() { NextNumber = 1, MinDigits = 6, Prefix = "IS-", Suffix = "", DoCumentNoFormatId = 1,Preview="IS-000001" });

            Documentlist.Add(new DoCumentNoFormat() { NextNumber = 1, MinDigits = 6, Prefix = "PO-", Suffix = "", DoCumentNoFormatId = 2, Preview = "PO-000001" });
            Documentlist.Add(new DoCumentNoFormat() { NextNumber = 1, MinDigits = 6, Prefix = "CS-", Suffix = "", DoCumentNoFormatId = 3, Preview = "CS-000001" });
            Documentlist.Add(new DoCumentNoFormat() { NextNumber = 1, MinDigits = 6, Prefix = "WO-", Suffix = "", DoCumentNoFormatId = 4, Preview = "WO-000001" });
            Documentlist.Add(new DoCumentNoFormat() { NextNumber = 1, MinDigits = 6, Prefix = "GRN-", Suffix = "", DoCumentNoFormatId = 5, Preview = "GRN-000001" });

            foreach (DoCumentNoFormat std in Documentlist)
                context.DoCumentNoFormat.AddOrUpdate(std);
        }
    }
}
