CREATE TABLE [dbo].[RolesUsuarios]
(
	[idRolUsuario] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idRol] INT NOT NULL, 
    [idUsuario] INT NOT NULL,
    FOREIGN KEY ([idRol]) REFERENCES [Roles]([idRol]),
    FOREIGN KEY ([idUsuario]) REFERENCES [Usuarios]([idUsuario])
)
