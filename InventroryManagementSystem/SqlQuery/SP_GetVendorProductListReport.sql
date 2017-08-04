USE [InflowInventory]


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetVendorProductListReport
	@vendorid int,
	@categoryid int,
	@productid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT        dbo.Product.Name AS Item, dbo.ProductCategory.Name AS Category, dbo.Vendor.Name AS VendorName,
			 dbo.Product.ProductCode AS VendorProductCode, dbo.PurchaseOrderDetail.UnitPrice AS UnitPrice
FROM  dbo.Product 
		INNER JOIN dbo.ProductCategory ON dbo.Product.CategoryId = dbo.ProductCategory.CategoryId 
		INNER JOIN dbo.PurchaseOrderDetail ON dbo.Product.ProdId = dbo.PurchaseOrderDetail.ProdId
		INNER JOIN dbo.Vendor ON dbo.Product.LastVendorId = dbo.Vendor.VendorId

 WHERE		(@vendorid IS NULL or Product.LastVendorId=@vendorid)
		 AND (@categoryid IS NULL OR Product.CategoryId=@categoryid)
		 AND (@productid IS NULL or Product.ProdId=@productid)
END
GO


--exec SP_GetVendorProductListReport null,null,4