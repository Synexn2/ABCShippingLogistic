CREATE TABLE [dbo].[Shipment] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [tracking_id] NVARCHAR (50) NOT NULL,
    [remarks]     TEXT          NULL,
    [creator_id]  INT           NOT NULL,
    [date]        DATE          NOT NULL,
    [category] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);