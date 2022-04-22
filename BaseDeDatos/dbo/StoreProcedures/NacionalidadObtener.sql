CREATE PROCEDURE [dbo].[NacionalidadObtener]
	@IdNacionalidad INT = NULL
AS
Begin
	SET NOCOUNT ON

	SELECT
		IdNacionalidad,
		Nombre
	FROM dbo.Nacionalidad
	WHERE (@IdNacionalidad IS NULL OR IdNacionalidad=@IdNacionalidad)
End
