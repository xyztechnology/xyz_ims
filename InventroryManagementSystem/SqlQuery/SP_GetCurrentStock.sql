USE[IMS]


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetCurrentStock

@date DateTime,
@itemid int,
@locationid int,
@categoryid int,
@typeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT        dbo.Product.Name AS ItemName, dbo.ProductCategory.Name AS CategoryName, dbo.Vendor.Name AS LastVendor,
		 dbo.Location.Name AS LocationName, dbo.PurchaseOrderDetail.Quantity
FROM            dbo.Location INNER JOIN
                         dbo.Product ON dbo.Location.LocationId = dbo.Product.DefaultLocationId INNER JOIN
                         dbo.ProductCategory ON dbo.Product.CategoryId = dbo.ProductCategory.CategoryId INNER JOIN
                         dbo.PurchaseOrder ON dbo.Location.LocationId = dbo.PurchaseOrder.LocationId INNER JOIN
                         dbo.PurchaseOrderDetail ON dbo.Product.ProdId = dbo.PurchaseOrderDetail.ProdId AND
						  dbo.PurchaseOrder.PurchaseOrderId = dbo.PurchaseOrderDetail.PurchaseOrderId INNER JOIN
                         dbo.Vendor ON dbo.PurchaseOrder.VendorId = dbo.Vendor.VendorId
where ( @date IS NULL or CAST(PurchaseOrder.OrderDate  as date)=@date)
	AND (@itemid IS NULL OR Product.ProdId=@itemid)
	AND (@locationid is null or PurchaseOrder.LocationId=@locationid)
	AND (@categoryid IS NULL OR Product.CategoryId=@categoryid)
	AND (@typeid is null or Product.ItemTypeId=@typeid)
	--AND PurchaseOrder.OrderDate=(select max(OrderDate) from PurchaseOrder inner join PurchaseOrderDetail
		--on PurchaseOrder.PurchaseOrderId=PurchaseOrderDetail.PurchaseOrderId)


END
GO


--purchaseorder table's locationid and product table's defaultlocation id must be same