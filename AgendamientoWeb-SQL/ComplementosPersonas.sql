CREATE TABLE [dbo].[ComplementosPersonas]
(
	[idComplementoPersona] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idPersona] INT NOT NULL, 
    [idCampoComplementoPersona] INT NOT NULL, 
    [valor] VARCHAR(MAX) NOT NULL,
    FOREIGN KEY ([idPersona]) REFERENCES [Personas]([idPersona]),
    FOREIGN KEY ([idCampoComplementoPersona]) REFERENCES [CamposComplementosPersonas] ([idCampoComplementoPersona])
)
