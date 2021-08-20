CREATE OR ALTER PROC sp_Movimientos_i
@Id_movimiento int output,
@Id_tipo_movimiento int,
@Fecha_movimiento date,
@Hora_movimiento time(2),
@Descripcion_movimiento varchar(200),
@Estado_movimiento varchar(50)
AS
BEGIN TRY

INSERT INTO Movimientos
VALUES (@Id_tipo_movimiento, @Fecha_movimiento, @Hora_movimiento, 
@Descripcion_movimiento, @Estado_movimiento)

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