USE [InflowInventory]
GO
/****** Object:  StoredProcedure [dbo].[_INV_CountSheet_GetDocNo]    Script Date: 7/13/2017 9:33:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sp_CountSheet_GetDocNo] 
(
	@DocNo nvarchar(20) OUTPUT
)
AS

DECLARE @DocNoFormatId int
--CHANGE THIS LINE PER DOC TYPE
SET @DocNoFormatId = 4

DECLARE @NextNumber int
DECLARE @MinDigits int
DECLARE @Prefix nvarchar(20)
DECLARE @Suffix nvarchar(20)

SELECT @NextNumber = NextNumber, @MinDigits = MinDigits, @Prefix = Prefix, @Suffix = Suffix
  FROM DoCumentNoFormat WHERE DoCumentNoFormatId = @DocNoFormatId

WHILE 1 = 1
BEGIN
  --Set the document number
  IF LEN(@NextNumber) < @MinDigits
  BEGIN
    SET @DocNo = @Prefix + RIGHT('00000000000000000000' + CONVERT(nvarchar(20), @NextNumber), @MinDigits) + @Suffix
  END
  ELSE
  BEGIN
    SET @DocNo = @Prefix + CONVERT(nvarchar(20), @NextNumber) + @Suffix
  END
  
  
  
  --Otherwise, go up to the next number and try again.
  SET @NextNumber = @NextNumber + 1
END

--Update the next number in the database
UPDATE DoCumentNoFormat SET NextNumber = @NextNumber + 1 WHERE DoCumentNoFormatId = @DocNoFormatId
