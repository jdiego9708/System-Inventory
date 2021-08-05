CREATE PROC [dbo].[sp_Cerrar_turno]
@Id_turno int
AS
BEGIN TRY
--OBTENER LA FECHA DEL TURNO
DECLARE @Fecha_turno date
SET @Fecha_turno = 
(SELECT Fecha_inicio_turno FROM Turnos WHERE Id_turno = @Id_turno)

--OBTENER EL VALOR INICIAL
DECLARE @Valor_inicial decimal(19,2)
SET @Valor_inicial = 
(SELECT Valor_inicial FROM Turnos WHERE Id_turno = @Id_turno)

IF (@Valor_inicial IS NULL)
BEGIN
	SET @Valor_inicial = 0;
END

--OBTENER TODOS LOS EGRESOS
DECLARE @Total_egresos decimal(19,2)
SET @Total_egresos = 
(SELECT SUM(Total_facturacion) 
FROM Facturacion fac 
INNER JOIN Catalogo ca ON fac.Id_tipo_facturacion = ca.Id_tipo
WHERE Fecha_facturacion = @Fecha_turno and 
ca.Nombre_tipo = 'EGRESO')

IF (@Total_egresos IS NULL)
BEGIN
	SET @Total_egresos = 0;
END

--OBTENER TODOS LOS INGRESOS
DECLARE @Total_ingresos decimal(19,2)
SET @Total_ingresos = 
(SELECT SUM(Total_facturacion) 
FROM Facturacion fac 
INNER JOIN Catalogo ca ON fac.Id_tipo_facturacion = ca.Id_tipo
WHERE Fecha_facturacion = @Fecha_turno and 
ca.Nombre_tipo = 'INGRESO')

IF (@Total_ingresos IS NULL)
BEGIN
	SET @Total_ingresos = 0;
END

--OBTENER EL TOTAL DE VENTAS
DECLARE @Total_ventas decimal(19,2) = 
(SELECT SUM(Total_facturacion) 
FROM Facturacion fac 
INNER JOIN Catalogo ca ON fac.Id_tipo_facturacion = ca.Id_tipo
WHERE Fecha_facturacion = @Fecha_turno and 
ca.Nombre_tipo = 'VENTA')

IF (@Total_ventas IS NULL)
BEGIN
	SET @Total_ventas = 0;
END

--OBTENER EL TOTAL DE NOMINA
DECLARE @Total_nomina decimal(19,2) = 
(SELECT SUM(Total_facturacion) 
FROM Facturacion fac 
INNER JOIN Catalogo ca ON fac.Id_tipo_facturacion = ca.Id_tipo
WHERE Fecha_facturacion = @Fecha_turno and 
ca.Nombre_tipo = 'NOMINA')

IF (@Total_nomina IS NULL)
BEGIN
	SET @Total_nomina = 0;
END

DECLARE @Total_turno decimal(19,2)
SET @Total_turno = (@Valor_inicial + @Total_ingresos + @Total_ventas - @Total_egresos - @Total_nomina)

UPDATE Turnos SET
Total_ingresos = @Total_ingresos,
Total_egresos = @Total_egresos,
Total_ventas = @Total_ventas,
Total_nomina = @Total_nomina,
Total_turno = @Total_turno,
Estado_turno = 'CERRADO'
WHERE Id_turno = @Id_turno

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
