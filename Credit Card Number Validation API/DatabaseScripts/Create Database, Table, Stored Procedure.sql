USE [master]
GO

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'CreditCard')
CREATE DATABASE [CreditCard]
GO

USE [CreditCard]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cards]') AND type in (N'U'))
DROP TABLE [Cards]
GO

BEGIN
CREATE TABLE [Cards](
	[CardNumber] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED ([CardNumber] ASC ))
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckCardNumberExist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CheckCardNumberExist]
GO

CREATE PROCEDURE [CheckCardNumberExist]
	@CardNumber nvarchar(16)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(SELECT * FROM Cards WHERE CardNumber = @CardNumber)
	 return 1;
	else
	 return 0;
END
GO
