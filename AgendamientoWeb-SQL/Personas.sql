CREATE TABLE [dbo].[Personas]
(
	[idPersona] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [idTipoDocumento] INT NOT NULL,
	idCiudad INT NOT NULL,
	nombrePersona VARCHAR(200) NOT NULL,
	apellidoPersona VARCHAR(200) NOT NULL,
	documentoPersona VARCHAR(200) NOT NULL,
	emailPersona VARCHAR(200) NOT NULL,
	telefonoPersona VARCHAR(200) NOT NULL,
	direccionPersona VARCHAR(200) NOT NULL,
	FOREIGN KEY ([idTipoDocumento]) REFERENCES [TiposDocumentos]([idTipoDocumento]),
	FOREIGN KEY ([idCiudad]) REFERENCES [Ciudades]([idCiudad])
)
