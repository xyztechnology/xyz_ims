USE [IMS]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetPurchaseRequisition_Search

@reqno varchar(25),
@date datetime

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT RequisitionDate,Vendor.Name from PurchaseRequisition inner join Vendor on PurchaseRequisition.VendorId=Vendor.VendorId
	 where (PurchaseRequisition.PurchaseRequisitionId=@reqno OR @reqno is null)
	 AND (cast(PurchaseRequisition.RequisitionDate as date)=@date or @date is null)
END
GO
--exec SP_GetPurchaseRequisition_Search 2,null