CREATE TABLE [dbo].[Inventarios]
(
	[idInventario] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idUbicacion] INT NOT NULL,
    [codigoProducto] VARCHAR(50) NOT NULL, 
    [nombreProducto] VARCHAR(200) NOT NULL, 
    [cantidadProducto] INT NOT NULL,
    FOREIGN KEY ([idUbicacion]) REFERENCES [Ubicaciones]([idUbicacion]),
)
