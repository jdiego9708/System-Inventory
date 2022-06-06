CREATE OR ALTER PROC [dbo].[sp_Login]
@Pass varchar(50),
@Fecha date,
@Hora time(2)
AS
BEGIN TRY
	BEGIN
	--DECLARAR LA RESPUESTA
	DECLARE @Respuesta varchar(200) = 'OK'
	--OBTENER EL ID DEL EMPLEADO
	DECLARE @Id_credencial int, 
	@Id_usuario int
	SET @Id_credencial =
	(SELECT cr.Id_credencial
	FROM Usuarios us 
	INNER JOIN Credenciales_usuario cr ON us.Id_usuario = cr.Id_usuario
	WHERE cr.Password = @Pass and cr.Estado_credencial = 'ACTIVO')

	--SI NO LO ENCUENTRA, RETORNA LA RESPUESTA CON EL ERROR
	IF (@Id_credencial IS NULL OR @Id_credencial = 0)
	BEGIN
		SET @Respuesta = 'Verifique la clave del usuario'
		SELECT @Respuesta as Respuesta
		RETURN 0;
	END

	SET @Id_usuario =
	(SELECT us.Id_usuario
	FROM Usuarios us 
	INNER JOIN Credenciales_usuario cr ON us.Id_usuario = cr.Id_usuario
	WHERE cr.Password = @Pass)

	--OBTENER EL TIPO DE USUARIO (CARGO_EMPLEADO)
	DECLARE @Tipo_usuario varchar(50)
	SELECT @Tipo_usuario = ca.Nombre_tipo
	FROM Usuarios us 
	INNER JOIN Credenciales_usuario cr ON us.Id_usuario = cr.Id_usuario
	INNER JOIN Catalogo ca ON us.Id_tipo_usuario = ca.Id_tipo
	WHERE cr.Id_credencial = @Id_credencial

	IF (@Tipo_usuario IS NULL OR @Tipo_usuario = '')
	BEGIN
		SET @Respuesta = 'Verifique el tipo de usuario'
		SELECT @Respuesta as Respuesta
		RETURN 0;
	END

	--OBTENER EL TURNO ANTERIOR
	DECLARE @Id_turno_anterior int,
	@Id_turno_actual int

	SELECT @Id_turno_anterior = tu.Id_turno
	FROM Turnos tu
	ORDER BY tu.Id_turno ASC

	--SI NO HAY TURNOS ANTERIORES INSERTAMOS UNO NUEVO
	IF (@Id_turno_anterior IS NULL OR @Id_turno_anterior = 0)
	BEGIN
		INSERT INTO Turnos VALUES (@Fecha, @Hora, 0, 0, 0, 0, 0, 0, 'ABIERTO')
		SET @Id_turno_actual = SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		--SI EXISTEN TURNOS ANTERIORES VERIFICAMOS SI ESTÁ ABIERTO
		DECLARE @Fecha_turno_anterior date
		SET @Fecha_turno_anterior = 
		(SELECT Fecha_inicio_turno FROM Turnos WHERE Id_turno = @Id_turno_anterior)

		--SI EXISTEN TURNOS ANTERIORES VERIFICAMOS SI ESTÁ ABIERTO
		DECLARE @Estado_turno_anterior varchar(50)
		SET @Estado_turno_anterior = 
		(SELECT Estado_turno FROM Turnos WHERE Id_turno = @Id_turno_anterior)
		--SI ESTÁ ABIERTO LO CERRAMOS
		IF (@Estado_turno_anterior = 'ABIERTO' and @Fecha > @Fecha_turno_anterior)
		BEGIN
			--EJECUTAMOS EL CERRAR TURNO DONDE CALCULARÁ LOS TOTALES
			EXEC sp_Cerrar_turno @Id_turno_anterior
			--INSERTAMOS EL TURNO ACTUAL
			INSERT INTO Turnos VALUES (@Fecha, @Hora, 0, 0, 0, 0, 0, 0, 'ABIERTO')
			SET @Id_turno_actual = SCOPE_IDENTITY();
		END
		ELSE IF (@Estado_turno_anterior = 'CERRADO' and @Fecha > @Fecha_turno_anterior)
		BEGIN
			--INSERTAMOS EL TURNO ACTUAL
			INSERT INTO Turnos VALUES (@Fecha, @Hora, 0, 0, 0, 0, 0, 0, 'ABIERTO')
			SET @Id_turno_actual = SCOPE_IDENTITY();
		END
		ELSE --IF (@Fecha = @Fecha_turno_anterior)
		BEGIN
			SET @Id_turno_actual = @Id_turno_anterior
		END
	END

	--ENVIAMOS LA RESPUESTA
	SELECT @Respuesta as Respuesta,
	@Tipo_usuario as Tipo_usuario

	--ENVIAMOS EL EMPLEADO QUE INGRESÓ
	SELECT *
	FROM Usuarios us 
	INNER JOIN Credenciales_usuario cr ON us.Id_usuario = cr.Id_usuario
	INNER JOIN Catalogo ca ON us.Id_tipo_usuario = ca.Id_tipo
	WHERE cr.Id_credencial = @Id_credencial

	--SELECCIONAMOS EL TURNO ACTUAL
	SELECT *
	FROM Turnos WHERE Id_turno = @Id_turno_actual

	--SELECCIONAMOS LAS REGLAS DEL USUARIO
	SELECT *
	FROM Reglas re 
	INNER JOIN Reglas_usuario reus ON re.Id_regla = reus.Id_regla
	INNER JOIN Usuarios us ON reus.Id_usuario = us.Id_usuario
	WHERE reus.Id_usuario = @Id_usuario

END
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
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
RETURN -1
END CATCH
