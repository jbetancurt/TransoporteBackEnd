CREATE TABLE [dbo].[Servicios]
(
	[idServicio] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idEmpresa] INT NOT NULL,
    [nombreServicio] VARCHAR(200) NOT NULL, 
    [duracionServicio] INT NOT NULL, 
    [cupoServicio] INT NOT NULL
    FOREIGN KEY ([idEmpresa]) REFERENCES [Empresas]([idEmpresa]),
)
