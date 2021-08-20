CREATE OR ALTER PROC sp_Movimientos_g
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY

IF (@Tipo_busqueda = 'ID MOVIMIENTO')
BEGIN
	SELECT *
	FROM Movimientos mov 
	INNER JOIN Catalogo ca ON mov.Id_tipo_movimiento = ca.Id_tipo
	WHERE mov.Id_movimiento = @Texto_busqueda
END
ELSE IF (@Tipo_busqueda = 'FECHA MOVIMIENTO')
BEGIN
	SELECT *
	FROM Movimientos mov 
	INNER JOIN Catalogo ca ON mov.Id_tipo_movimiento = ca.Id_tipo
	WHERE mov.Fecha_movimiento = CONVERT(date, @Texto_busqueda)
END

END TRY
BEGIN CATCH
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
END CATCH