CREATE TABLE [dbo].[Locaciones]
(
	[idLocacion] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idUbicacion] INT NOT NULL, 
    [nombreLocacion] VARCHAR(200) NOT NULL, 
    [observacionLocacion] VARCHAR(MAX) NOT NULL,
    FOREIGN KEY ([idUbicacion]) REFERENCES [Ubicaciones]([idUbicacion]) 
)
