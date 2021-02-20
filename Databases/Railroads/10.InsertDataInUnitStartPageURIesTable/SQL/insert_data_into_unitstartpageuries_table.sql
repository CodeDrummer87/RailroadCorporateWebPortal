IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'Railroads'))
USE Railroads

GO

IF OBJECT_ID('UnitStartPageURIes', 'u') IS NOT NULL
INSERT INTO UnitStartPageURIes
VALUES (5, 9, 41, 'https://localhost:44323/start/index');