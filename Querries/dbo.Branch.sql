CREATE TABLE [dbo].[Branch]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [branch_code] NCHAR(10) NOT NULL,
	[addy_line1] NVARCHAR(50) NULL, 
    [addy_line2] NVARCHAR(50) NULL, 
    [city] NVARCHAR(50) NULL, 
    [county] NVARCHAR(50) NULL, 
    [country] NVARCHAR(50) NULL, 
    [postcode] NCHAR(10) NULL, 
    [manager_id] INT NOT NULL, 
)
