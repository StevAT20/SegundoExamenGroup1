﻿CREATE TABLE [dbo].[TipoCliente]
(
	IdTipoCliente INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_TipoCliente] PRIMARY KEY CLUSTERED (IdTipoCliente ASC),
	Nombre VARCHAR(128) NOT NULL
)
