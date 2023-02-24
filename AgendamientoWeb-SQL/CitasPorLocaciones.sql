CREATE TABLE [dbo].[CitasPorLocaciones]
(
	[idCitaPorLocacion] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [idCita] INT NOT NULL, 
    [idLocacion] INT NOT NULL,
    FOREIGN KEY ([idCita]) REFERENCES [Citas]([idCita]),
	FOREIGN KEY ([idLocacion]) REFERENCES [Locaciones]([idLocacion])
)
