CREATE TABLE [dbo].[Parcel_Tracking_Log]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[tracking_id]         NVARCHAR (50) NULL,
	[branch_code] NCHAR (10)    NOT NULL, 
    [date] DATE NOT NULL, 
    [time_out] TIMESTAMP NULL, 
    [remarks] TEXT NULL,

)
