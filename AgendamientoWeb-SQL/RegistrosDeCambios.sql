CREATE TABLE [dbo].[RegistrosDeCambios]
(
	[idRegistroCambio] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idEmpresa] INT NOT NULL, 
    [idUsuario] INT NOT NULL, 
    [idPersona] INT NOT NULL, 
    [fechaAccion] Date NOT NULL,   
    [valorActual] VARCHAR(MAX) NOT NULL, 
    [valorAnterior] VARCHAR(MAX) NOT NULL, 
    [tipoAccion] VARCHAR(200) NOT NULL,
    FOREIGN KEY ([idPersona]) REFERENCES [Personas]([idPersona]),
	FOREIGN KEY ([idEmpresa]) REFERENCES [Empresas]([idEmpresa]),
    FOREIGN KEY ([idUsuario]) REFERENCES [Usuarios]([idUsuario]),
)
