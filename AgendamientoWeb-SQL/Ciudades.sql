CREATE TABLE [dbo].[Ciudades]
(
	[idCiudad] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idPais] INT NOT NULL, 
    [nombreCiudad] VARCHAR(200) NOT NULL
    FOREIGN KEY ([idPais]) REFERENCES [Paises]([idPais]) 
)
