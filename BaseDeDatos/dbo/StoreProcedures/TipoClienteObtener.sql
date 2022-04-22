CREATE PROCEDURE [dbo].[TipoClienteObtener]
	@IdTipoCliente INT = NULL
AS
Begin
	SET NOCOUNT ON

	SELECT
		IdTipoCliente,
		Nombre
	FROM dbo.TipoCliente
	WHERE (@IdTipoCliente IS NULL OR IdTipoCliente=@IdTipoCliente)
End
