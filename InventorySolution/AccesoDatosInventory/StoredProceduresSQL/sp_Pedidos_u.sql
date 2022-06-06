CREATE OR ALTER  PROC sp_Pedidos_u
@Id_pedido int, 
@Fecha_pedido date,
@Hora_pedido time(2),
@Id_tipo_pedido int,
@Id_cliente int,
@Id_empleado int,
@Observaciones_pedido varchar(200),
@CantidadClientes int,
@Informacion_adicional varchar(200),
@Estado_pedido varchar(50)
AS
BEGIN TRY

UPDATE Pedidos SET
Fecha_pedido = @Fecha_pedido, 
Hora_pedido = @Hora_pedido, 
Id_tipo_pedido = @Id_tipo_pedido, 
Id_cliente = @Id_cliente, 
Id_empleado = @Id_empleado, 
Observaciones_pedido = @Observaciones_pedido,
CantidadClientes = @CantidadClientes, 
Informacion_adicional = @Informacion_adicional, 
Estado_pedido = @Estado_pedido
WHERE Id_pedido = @Id_pedido;

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