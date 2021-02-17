IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'Railroads'))
USE Railroads;

GO

IF OBJECT_ID('Units', 'u') IS NULL
DROP TABLE Units