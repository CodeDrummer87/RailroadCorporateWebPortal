IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'Railroads'))
USE Railroads

GO

IF OBJECT_ID('Industries', 'u') IS NOT NULL
ALTER TABLE Industries
ALTER COLUMN FullTitle NVARCHAR(50);