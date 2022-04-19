CREATE TABLE [dbo].[Cliente]
(
	IdCliente INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED (IdCliente ASC),
	IdNacionalidad INT NULL CONSTRAINT [FK_Nacionalidad_Cliente] FOREIGN KEY (IdNacionalidad) REFERENCES dbo.Nacionalidad (IdNacionalidad),
	Identificacion VARCHAR (128) NULL,
	IdTipoIdentificacion INT NULL,
	Nombre VARCHAR (128) NULL,
	PrimerApellido VARCHAR (128) NULL,
	SegundoApellido VARCHAR (128) NULL,
	FechaNacimiento DATETIME NULL,
	FechaDefuncion DATETIME NULL,
	Genero CHAR (1) NULL,
	NombreApellidosPadre VARCHAR (200) NULL,
	NombreApellidosMadre VARCHAR (200) NULL,
	Pasaporte VARCHAR (50) NULL,
	CuentaIBAN VARCHAR(50) NULL,
	CorreoNotifica VARCHAR(128) NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO
