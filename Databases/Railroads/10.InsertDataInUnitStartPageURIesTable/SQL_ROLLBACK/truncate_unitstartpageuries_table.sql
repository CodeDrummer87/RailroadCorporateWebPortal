IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'Railroads'))
USE Railroads

GO

IF OBJECT_ID('UnitStartPageURIes', 'u') IS NOT NULL
TRUNCATE TABLE UnitStartPageURIes