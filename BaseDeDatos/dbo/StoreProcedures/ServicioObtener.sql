CREATE PROCEDURE [dbo].[ServicioObtener]
		@IdServicio INT = NULL
AS
Begin
	SET NOCOUNT ON

	SELECT
		IdServicio,
		NombreServicio,
		PlazoEntrega,
		CostoServicio,
		Estado,
		CuentaContable

	FROM dbo.Servicio
	WHERE (@IdServicio IS NULL OR IdServicio=@IdServicio)
End