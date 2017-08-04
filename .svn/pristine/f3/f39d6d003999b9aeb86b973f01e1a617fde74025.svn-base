USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetPurchaseOrderSearch]    Script Date: 7/13/2017 12:56:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_GetPurchaseOrderSearch
	-- Add the parameters for the stored procedure here
	@OrderNo nvarchar(255),
	@Vendor int,
	@Orderdt datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT         dbo.PurchaseOrder.OrderNo, dbo.PurchaseOrder.OrderDate,dbo.PurchaseOrder.Status, dbo.Vendor.Name AS Vendor,dbo.Location.Name as Location,dbo.PurchaseOrder.Total, dbo.PurchaseOrder.AmountPaid,  dbo.PurchaseOrder.Balance
                        
FROM            dbo.Location INNER JOIN
                         dbo.PurchaseOrder ON dbo.Location.LocationId = dbo.PurchaseOrder.LocationId INNER JOIN
                         dbo.Vendor ON dbo.PurchaseOrder.VendorId = dbo.Vendor.VendorId
						  WHERE (@OrderNo IS NULL or PurchaseOrder.OrderNo=@OrderNo)
						   And (@Vendor is null or PurchaseOrder.VendorId=@Vendor  )
						 AND ( @Orderdt IS NULL or CAST(PurchaseOrder.OrderDate  as date)=@Orderdt)
						


END

--exec [dbo].[SP_GetPurchaseOrderSearch]  null,1,null