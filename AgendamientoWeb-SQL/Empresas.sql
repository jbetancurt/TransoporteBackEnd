CREATE TABLE [dbo].[Empresas]
(
	[idEmpresa] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [idCiudad] INT NOT NULL,
	[idTipoNegocio] INT NOT NULL,
	[idPersonaResponsable] INT NOT NULL,
	[idTipoDocumento] INT NOT NULL,
	[razonSocialEmpresa] VARCHAR(200) NOT NULL,
	[documentoEmpresa] VARCHAR(200) NOT NULL,
	[emailEmpresa] VARCHAR(200) NOT NULL,
	[telefonoEmpresa] VARCHAR(200) NOT NULL,
	[direccionEmpresa] VARCHAR(200) NOT NULL,
	[rutaEmpresa] VARCHAR(50) NOT NULL, 
    FOREIGN KEY ([idTipoDocumento]) REFERENCES [TiposDocumentos]([idTipoDocumento]),
	FOREIGN KEY ([idCiudad]) REFERENCES [Ciudades]([idCiudad]),
	FOREIGN KEY ([idTipoNegocio]) REFERENCES [TiposNegocios]([idTipoNegocio]),
	FOREIGN KEY ([idPersonaResponsable]) REFERENCES Personas([idPersona]),
)
