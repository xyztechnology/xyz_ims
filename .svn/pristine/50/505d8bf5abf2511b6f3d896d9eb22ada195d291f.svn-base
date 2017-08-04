USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductDetail]    Script Date: 7/13/2017 12:51:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetProductDetail

	@ProdId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT        dbo.Vendor.Name AS VendorName, dbo.PurchaseOrderDetail.UnitPrice, dbo.Product.ProductCode, dbo.ItemType.ItemName,
	 dbo.PurchaseOrder.OrderNo, dbo.PurchaseOrder.OrderDate, dbo.PurchaseOrder.Status,dbo.PurchaseOrder.Total,
	  dbo.PurchaseOrderDetail.Quantity, dbo.PurchaseOrder.SubTotal
FROM    dbo.ItemType INNER JOIN
         dbo.Product ON dbo.ItemType.ItemTypeId = dbo.Product.ItemTypeId INNER JOIN
         dbo.PurchaseOrderDetail ON dbo.Product.ProdId = dbo.PurchaseOrderDetail.ProdId INNER JOIN
         dbo.PurchaseOrder ON dbo.PurchaseOrderDetail.PurchaseOrderId = dbo.PurchaseOrder.PurchaseOrderId INNER JOIN
          dbo.Vendor ON dbo.PurchaseOrder.VendorId = dbo.Vendor.VendorId
WHERE Product.ProdId=@ProdId AND PurchaseOrder.OrderDate=(select max(OrderDate) from PurchaseOrder inner join PurchaseOrderDetail
		on PurchaseOrder.PurchaseOrderId=PurchaseOrderDetail.PurchaseOrderId where PurchaseOrderDetail.ProdId=@ProdId)

END


--exec [dbo].[SP_GetProductDetail] 1
 