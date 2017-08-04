USE [InflowInventory]
GO

/****** Object:  StoredProcedure [dbo].[Sp_PurchaseOrder_GetOrderNo]    Script Date: 7/13/2017 10:38:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_PurchaseOrder_GetOrderNo] 

AS

DECLARE @DocNoFormatId int
--CHANGE THIS LINE PER DOC TYPE
SET @DocNoFormatId = 3
Declare  @DocNo nvarchar(20)
DECLARE @NextNumber int
DECLARE @MinDigits int
DECLARE @Prefix nvarchar(20)
DECLARE @Suffix nvarchar(20)

SELECT @NextNumber = NextNumber, @MinDigits = MinDigits, @Prefix = Prefix, @Suffix = Suffix
  FROM [dbo].[DoCumentNoFormat] WHERE DoCumentNoFormatId = @DocNoFormatId

WHILE 1 = 1
BEGIN
  --Set the document number
  IF LEN(@NextNumber) < @MinDigits
  BEGIN
    select @Prefix + RIGHT('00000000000000000000' + CONVERT(nvarchar(20), @NextNumber), @MinDigits) + @Suffix as OrderNo
  END
  ELSE
  BEGIN
   select @Prefix + CONVERT(nvarchar(20), @NextNumber) + @Suffix as OrderNo
  END
  
  --Test if this document number is already used.  If so, break the loop
  --CHANGE THIS LINE PER DOC TYPE
  IF NOT EXISTS(SELECT 1 FROM PurchaseOrder WHERE OrderNo = @DocNo)
    BREAK
  
  --Otherwise, go up to the next number and try again.
  SET @NextNumber = @NextNumber + 1
END

--Update the next number in the database
UPDATE DoCumentNoFormat SET NextNumber = @NextNumber + 1 WHERE DoCumentNoFormatId = @DocNoFormatId

GO


