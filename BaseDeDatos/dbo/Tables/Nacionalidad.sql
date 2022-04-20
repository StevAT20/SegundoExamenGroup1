﻿CREATE TABLE [dbo].[Nacionalidad]
(
	IdNacionalidad INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Nacionalidad] PRIMARY KEY CLUSTERED (IdNacionalidad ASC),
	Nombre VARCHAR(128) NOT NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO
