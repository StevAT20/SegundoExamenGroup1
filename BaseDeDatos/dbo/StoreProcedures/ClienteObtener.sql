CREATE PROCEDURE [dbo].[ClienteObtener]
		@IdCliente INT = NULL
AS
Begin
	SET NOCOUNT ON

	SELECT
		C.IdCliente,
		C.Identificacion,
		C.IdTipoIdentificacion,
		C.Nombre,
		C.PrimerApellido,
		C.SegundoApellido,
		C.FechaNacimiento,
		C.FechaDefuncion,
		C.Genero,
		C.NombreApellidosPadre,
		C.NombreApellidosMadre,
		C.Pasaporte,
		C.CuentaIBAN,
		C.CorreoNotifica,
		N.IdNacionalidad,
		N.Nombre,
		T.IdTipoCliente,
		T.Nombre
	FROM dbo.Cliente C
	    INNER JOIN dbo.Nacionalidad N
			ON C.IdNacionalidad = N.IdNacionalidad INNER JOIN dbo.TipoCliente T 
			ON C.IdTipoIdentificacion = T.IdTipoCliente
	WHERE (@IdCliente IS NULL OR IdCliente=@IdCliente)
End
