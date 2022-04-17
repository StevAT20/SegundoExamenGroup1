CREATE PROCEDURE [dbo].[ListarServicio]
	AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		IdServicio
		,NombreServicio
	FROM dbo.Servicio

	END