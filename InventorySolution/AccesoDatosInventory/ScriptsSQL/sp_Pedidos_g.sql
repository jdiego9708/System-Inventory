CREATE OR ALTER PROC sp_Pedidos_g
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY

IF (@Tipo_busqueda = 'ID PEDIDO')
BEGIN
	SELECT *
	FROM Pedidos pe 
	INNER JOIN Catalogo ca ON pe.Id_tipo_pedido = ca.Id_tipo
	INNER JOIN Usuarios us ON pe.Id_cliente = us.Id_usuario AND pe.Id_empleado = us.Id_usuario
	WHERE pe.Id_pedido = @Texto_busqueda
END
ELSE IF (@Tipo_busqueda = 'FECHA PEDIDO')
BEGIN
	SELECT *
	FROM Pedidos pe 
	INNER JOIN Catalogo ca ON pe.Id_tipo_pedido = ca.Id_tipo
	INNER JOIN Usuarios us ON pe.Id_cliente = us.Id_usuario AND pe.Id_empleado = us.Id_usuario
	WHERE pe.Fecha_pedido = CONVERT(date, @Texto_busqueda)
END
ELSE IF (@Tipo_busqueda = 'PENDIENTE FECHA')
BEGIN
	SELECT *
	FROM Pedidos pe 
	INNER JOIN Catalogo ca ON pe.Id_tipo_pedido = ca.Id_tipo
	INNER JOIN Usuarios us ON pe.Id_cliente = us.Id_usuario AND pe.Id_empleado = us.Id_usuario
	WHERE pe.Fecha_pedido = CONVERT(date, @Texto_busqueda) AND pe.Estado_pedido = 'PENDIENTE'
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