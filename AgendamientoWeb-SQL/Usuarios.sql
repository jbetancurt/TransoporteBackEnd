CREATE TABLE [dbo].[Usuarios]
(
	[idUsuario] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idPersona] INT NOT NULL, 
    [loginUsuario] VARCHAR(50) NOT NULL, 
    [paswordUsuario] VARBINARY(50) NOT NULL, 
    [estadoUsuario] BIT NOT NULL, 
    [expiracionUsuario] BIT NOT NULL,
    FOREIGN KEY ([idPersona]) REFERENCES [Personas]([idPersona])
)
