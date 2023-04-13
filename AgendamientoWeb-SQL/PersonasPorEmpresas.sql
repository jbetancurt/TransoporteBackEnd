CREATE TABLE [dbo].[PersonasPorEmpresas]
(
	[idPersonaPorEmpresa] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [idPersona] INT NOT NULL, 
    [idEmpresa] INT NOT NULL, 
    [tipoUsuario] VARCHAR(MAX) NOT NULL,
    FOREIGN KEY ([idPersona]) REFERENCES [Personas]([idPersona]),
	FOREIGN KEY ([idEmpresa]) REFERENCES [Empresas]([idEmpresa]),
)
