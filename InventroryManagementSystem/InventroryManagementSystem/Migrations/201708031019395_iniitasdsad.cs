namespace InventroryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniitasdsad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrderAnalayis",
                c => new
                    {
                        PurchaseOrderAnalysisId = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        TransactionAnalysisId = c.Int(nullable: false),
                        TransactionAnalysisSubSetupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderAnalysisId)
                .ForeignKey("dbo.PurchaseOrder", t => t.PurchaseOrderId)
                .ForeignKey("dbo.TransactionAnalysisSetup", t => t.TransactionAnalysisId)
                .ForeignKey("dbo.TransactionAnalysisSubSetup", t => t.TransactionAnalysisSubSetupId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.TransactionAnalysisId)
                .Index(t => t.TransactionAnalysisSubSetupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrderAnalayis", "TransactionAnalysisSubSetupId", "dbo.TransactionAnalysisSubSetup");
            DropForeignKey("dbo.PurchaseOrderAnalayis", "TransactionAnalysisId", "dbo.TransactionAnalysisSetup");
            DropForeignKey("dbo.PurchaseOrderAnalayis", "PurchaseOrderId", "dbo.PurchaseOrder");
            DropIndex("dbo.PurchaseOrderAnalayis", new[] { "TransactionAnalysisSubSetupId" });
            DropIndex("dbo.PurchaseOrderAnalayis", new[] { "TransactionAnalysisId" });
            DropIndex("dbo.PurchaseOrderAnalayis", new[] { "PurchaseOrderId" });
            DropTable("dbo.PurchaseOrderAnalayis");
        }
    }
}
