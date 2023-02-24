CREATE TABLE [dbo].[CitasPorProgramacionesDeServicios]
(
	[idCitasPorprogramacionDeServicio] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idCita] INT NOT NULL, 
    [idProgramacionDeServicio] INT NOT NULL,
    FOREIGN KEY ([idCita]) REFERENCES [Citas]([idCita]),
	FOREIGN KEY ([idProgramacionDeServicio]) REFERENCES [ProgramacionesDeServicios]([idProgramacionDeServicio]),
)
