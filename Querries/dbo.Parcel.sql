CREATE TABLE [dbo].[Parcel] (
    [parcel_id]   INT           IDENTITY (1, 1) NOT NULL,
    [type]        NCHAR (20)    NOT NULL,
    [weight]      FLOAT (53)    NULL,
    [Height]      FLOAT (53)    NULL,
    [width]       NVARCHAR (50) NULL,
    [description] TEXT          NOT NULL,
    [branch_code] NCHAR(10) NOT NULL, 
    [shipping_addy_line1] NVARCHAR(50) NULL, 
    [shipping_addy_line2] NVARCHAR(50) NULL, 
    [shipping_city] NVARCHAR(50) NULL, 
    [shipping_county] NVARCHAR(50) NULL, 
    [shipping_country] NVARCHAR(50) NULL, 
    [shipping_postcode] NCHAR(10) NULL, 
    [tracking_id] NVARCHAR(50) NULL, 
    [shipping_mode] NVARCHAR(50) NULL,
	[date_create] DATE NOT NULL, 
	[creator_id] INT NULL, 
    PRIMARY KEY CLUSTERED ([parcel_id] ASC)
);

