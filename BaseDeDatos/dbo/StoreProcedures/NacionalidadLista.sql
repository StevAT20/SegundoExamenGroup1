CREATE PROCEDURE [dbo].[NacionalidadLista]
	AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		IdNacionalidad
		,Nombre
	FROM dbo.Nacionalidad

	END
