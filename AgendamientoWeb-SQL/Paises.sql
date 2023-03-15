CREATE TABLE [dbo].[Paises]
(
	[idPais] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [nombrePais] VARCHAR(200) NOT NULL, 
    [codigoPais] VARCHAR(200) NOT NULL, 
    [iso2] VARCHAR(50) NOT NULL, 
    [iso3] VARCHAR(50) NOT NULL
)
