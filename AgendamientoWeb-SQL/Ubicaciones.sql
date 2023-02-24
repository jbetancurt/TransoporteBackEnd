CREATE TABLE [dbo].[Ubicaciones]
(
    [idUbicacion] INT NOT NULL PRIMARY KEY IDENTITY (1,1),  
    [nombreUbicacion] VARCHAR(200) NOT NULL, 
    [direccionUbicacion] VARCHAR(200) NOT NULL, 
    [telefonoUbicacion] INT NOT NULL, 
    [observacionUbicacion] VARCHAR(MAX) NOT NULL,
)
