USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSalesorder_Recentissues]    Script Date: 7/24/2017 4:12:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  SP_GetSalesorder_Recentissues

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT        dbo.SalesOrder.OrderDate, dbo.Customer.Name as CustomerName, dbo.Customer.Phone, dbo.Location.Name AS Location, dbo.Product.Name AS ProductName, dbo.SalesOrderDetail.Quantity
FROM            dbo.Customer INNER JOIN
                         dbo.Location ON dbo.Customer.DefaultLocationId = dbo.Location.LocationId INNER JOIN
                         dbo.Product ON dbo.Location.LocationId = dbo.Product.DefaultLocationId INNER JOIN
                         dbo.SalesOrder ON dbo.Customer.CustomerId = dbo.SalesOrder.CustomerId AND dbo.Location.LocationId = dbo.SalesOrder.LocationId INNER JOIN
                         dbo.SalesOrderDetail ON dbo.Product.ProdId = dbo.SalesOrderDetail.ProdId AND dbo.SalesOrder.SalesOrderId = dbo.SalesOrderDetail.SalesOrderId
 where  dbo.SalesOrder.OrderDate >= DATEADD(day,-7, GETDATE())

END
