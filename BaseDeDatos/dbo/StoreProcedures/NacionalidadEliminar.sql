﻿CREATE PROCEDURE [dbo].[NacionalidadEliminar]
	@IdNacionalidad INT
AS BEGIN

SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	DELETE FROM dbo.Nacionalidad WHERE IdNacionalidad=@IdNacionalidad

	COMMIT TRANSACTION TRASA
	SELECT 0 As CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH

		SELECT
			ERROR_NUMBER() AS CodeError,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA

	END CATCH

END