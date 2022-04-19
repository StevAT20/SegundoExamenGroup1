CREATE PROCEDURE [dbo].[TipoClienteLista]
	AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		IdTipoCliente
		,Nombre
	FROM dbo.TipoCliente

	END
