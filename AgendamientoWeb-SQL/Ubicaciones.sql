CREATE TABLE [dbo].[Ubicaciones]
(
    [idUbicacion] INT NOT NULL PRIMARY KEY IDENTITY (1,1),  
    [idEmpresa] INT NOT NULL,
    [nombreUbicacion] VARCHAR(200) NOT NULL, 
    [direccionUbicacion] VARCHAR(200) NOT NULL, 
    [telefonoUbicacion] VARCHAR(100) NOT NULL, 
    [observacionUbicacion] VARCHAR(MAX) NOT NULL, 
     FOREIGN KEY ([idEmpresa]) REFERENCES [Empresas]([idEmpresa])
    
    
)