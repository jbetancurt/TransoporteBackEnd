CREATE TABLE [dbo].[Citas]
(
	[idCita] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idPersona] INT  NOT NULL,
    [fecha] DATE NOT NULL, 
    [horaInicial] DATETIME NOT NULL, 
    [horaFinal] DATETIME NOT NULL, 
    [estadoCita] VARCHAR(200) NOT NULL,
    [descripcion] VARCHAR(MAX) NOT NULL,
    FOREIGN KEY ([idPersona]) REFERENCES [Personas]([idPersona]),
)
