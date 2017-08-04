USE [IMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVendorListReport]    Script Date: 7/13/2017 3:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetVendorListReport

	@VendorId int,
	@Phone varchar(100),
	@City nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT  Name,ContactName,Phone,Email,Address1
FROM  Vendor
 WHERE (@VendorId IS NULL OR  VendorId=@VendorId)
  AND ( @Phone IS NULL or CAST(Phone AS varchar(100)) like '%'+@Phone+'%')
  AND (@City IS NULL or City like '%'+@City+'%')
END


--exec [dbo].[SP_GetVendorListReport] null,98,null
 
 