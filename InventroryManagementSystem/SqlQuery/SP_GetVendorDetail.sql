USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVendorDetail]    Script Date: 7/13/2017 12:59:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetVendorDetail

@vendorid int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT        dbo.Product.Name, dbo.Product.Description, dbo.Product.ProductCode, dbo.PurchaseOrderDetail.UnitPrice,
	 dbo.PurchaseOrder.OrderNo,CAST(dbo.PurchaseOrder.OrderDate AS DATE) AS OrderDate, dbo.PurchaseOrder.Status, 
                         dbo.PurchaseOrder.Total, dbo.PurchaseOrder.AmountPaid, dbo.PurchaseOrder.Balance
FROM dbo.Product INNER JOIN
     dbo.PurchaseOrderDetail ON dbo.Product.ProdId = dbo.PurchaseOrderDetail.ProdId INNER JOIN
     dbo.PurchaseOrder ON dbo.PurchaseOrderDetail.PurchaseOrderId = dbo.PurchaseOrder.PurchaseOrderId INNER JOIN
     dbo.Vendor ON dbo.PurchaseOrder.VendorId = dbo.Vendor.VendorId

WHERE Vendor.VendorId=@vendorid


END

--exec [dbo].[SP_GetVendorDetail] 1