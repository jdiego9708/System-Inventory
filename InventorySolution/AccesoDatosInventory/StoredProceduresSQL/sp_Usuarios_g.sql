CREATE OR ALTER PROC sp_Usuarios_g
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY 
IF (@Tipo_busqueda = 'ID USUARIO')
BEGIN
	SELECT * 
	FROM Usuarios us
	WHERE us.Id_usuario = @Texto_busqueda
END
ELSE IF (@Tipo_busqueda = 'NOMBRE')
BEGIN
	SELECT *
	FROM Usuarios us 
	WHERE us.Nombre_usuario like @Texto_busqueda + '%'
END
ELSE IF (@Tipo_busqueda = 'COMPLETO')
BEGIN
	SELECT *
	FROM Usuarios us 
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