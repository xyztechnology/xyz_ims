USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductSearch]    Script Date: 7/13/2017 12:55:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_GetProductSearch
	-- Add the parameters for the stored procedure here
	@Name nvarchar(255),
	@Code nvarchar(255),
	@CategoryId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT      dbo.Product.Name AS Name, dbo.ItemType.ItemName AS ItemType,  dbo.ProductCategory.Name AS ProdCategory, dbo.PurchaseOrderDetail.UnitPrice, dbo.Vendor.Name AS Vendor
FROM	        dbo.ItemType INNER JOIN
                         dbo.Product ON dbo.ItemType.ItemTypeId = dbo.Product.ItemTypeId INNER JOIN
                         dbo.ProductCategory ON dbo.Product.CategoryId = dbo.ProductCategory.CategoryId INNER JOIN
                         dbo.PurchaseOrderDetail ON dbo.Product.ProdId = dbo.PurchaseOrderDetail.ProdId INNER JOIN
                         dbo.PurchaseOrder ON dbo.PurchaseOrderDetail.PurchaseOrderId = dbo.PurchaseOrder.PurchaseOrderId INNER JOIN
                         dbo.Vendor ON dbo.PurchaseOrder.VendorId = dbo.Vendor.VendorId
WHERE (@Name IS NULL or Product.Name=@Name)
           AND ( @Code IS NULL or Product.ProductCode like '%'+@Code+'%')
        And ( Product.CategoryId=@CategoryId or @CategoryId=0 )


END


--exec [dbo].[SP_GetProductSearch]  NULL,NULL,0