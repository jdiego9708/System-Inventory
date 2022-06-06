CREATE OR ALTER PROC sp_Usuarios_i
@Id_usuario int output,
@Fecha_ingreso date,
@Nombre_usuario varchar(50),
@Telefono_usuario varchar(50),
@Identificacion_usuario varchar(50),
@Email_usuario varchar(50),
@Id_tipo_usuario int,
@Estado_usuario varchar(50),
@Fecha date,
@Hora time(2)
AS
BEGIN TRY

INSERT INTO Usuarios 
VALUES (@Fecha_ingreso, @Nombre_usuario, @Telefono_usuario, 
@Identificacion_usuario, @Email_usuario, @Id_tipo_usuario, @Estado_usuario);

SET @Id_usuario = SCOPE_IDENTITY();

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