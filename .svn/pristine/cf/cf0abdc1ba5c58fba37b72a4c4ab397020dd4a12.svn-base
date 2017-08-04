USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSalesorderunpaidissue]    Script Date: 7/24/2017 3:15:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetSalesorder_Unpaidissue
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  dbo.SalesOrder.OrderDate, dbo.Customer.Name as CustomerName, dbo.Customer.Phone, dbo.Location.Name AS Location,
			 dbo.SalesOrder.Total, dbo.SalesOrder.Balance
FROM   dbo.Customer INNER JOIN
       dbo.Location ON dbo.Customer.DefaultLocationId = dbo.Location.LocationId INNER JOIN
       dbo.SalesOrder ON dbo.Customer.CustomerId = dbo.SalesOrder.CustomerId AND dbo.Location.LocationId = dbo.SalesOrder.LocationId
WHERE dbo.SalesOrder.Balance IS NOT NULL

order by dbo.Customer.Name asc

END


--EXEC [dbo].[SP_GetSalesorderunpaidissue]
