CREATE TABLE [dbo].[CamposComplementosPersonas]
(
	[idCampoComplementoPersona] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idEmpresa] INT NOT NULL, 
    [nombreCampoComplementoPersona] VARCHAR(200) NOT NULL, 
    [tipoCampoComplementoPersona] VARCHAR(200) NOT NULL
    FOREIGN KEY ([idEmpresa]) REFERENCES [Empresas]([idEmpresa]),
)
