CREATE PROCEDURE [dbo].[SolicitudObtener]
	@IdSolicitud INT = NULL
AS 
BEGIN
  SET NOCOUNT ON

  
  SELECT
         S.IdSolicitud
		,C.IdCliente
		,V.IdServicio
		,S.Cantidad
		,S.Monto
		,S.FechaEntrega
		,S.UsuarioEntrega
		,S.Observaciones
		

  FROM 
       dbo.Solicitud S
	    INNER JOIN dbo.Cliente C
		 ON S.IdCliente = C.IdCliente

	    INNER JOIN dbo.Servicio V
		 ON S.IdServicio = V.IdServicio
		 
  WHERE
      (@IdSolicitud IS NULL OR @IdSolicitud=@IdSolicitud)

END