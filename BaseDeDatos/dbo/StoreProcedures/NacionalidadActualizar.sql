﻿CREATE PROCEDURE [dbo].[NacionalidadActualizar]
	@IdNacionalidad INT,
	@Nombre VARCHAR (128)
AS BEGIN

SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	UPDATE dbo.Nacionalidad SET
		Nombre=@Nombre
	WHERE 
		IdNacionalidad=@IdNacionalidad

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
