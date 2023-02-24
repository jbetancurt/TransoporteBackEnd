CREATE TABLE [dbo].[ProgramacionesDeServicios]
(
	[idProgramacionDeServicio] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idPersona] INT NOT NULL, 
    [idServicio] INT NOT NULL, 
    [fecha] DATE NOT NULL, 
    [horaInicial] DATETIME NOT NULL, 
    [horaFinal] DATETIME NOT NULL, 
    [cupo] INT NOT NULL,
    FOREIGN KEY ([idPersona]) REFERENCES [Personas]([idPersona]),
    FOREIGN KEY ([idServicio]) REFERENCES [Servicios]([idServicio]),
)
