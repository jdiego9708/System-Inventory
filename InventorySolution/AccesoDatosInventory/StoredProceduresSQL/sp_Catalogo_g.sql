CREATE OR ALTER PROC sp_Catalogo_g
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY

IF (@Tipo_busqueda = 'ID CATALOGO')
BEGIN
	SELECT *
	FROM Catalogo ca
	WHERE ca.Id_tipo = @Texto_busqueda
END
ELSE IF (@Tipo_busqueda = 'ID PADRE')
BEGIN
	SELECT *
	FROM Catalogo ca
	WHERE ca.Id_padre = @Texto_busqueda
END
ELSE IF (@Tipo_busqueda = 'CATALOGO')
BEGIN
	SELECT *
	FROM Catalogo ca
	WHERE ca.Nombre_tipo = @Texto_busqueda
END
ELSE IF (@Tipo_busqueda = 'CATALOGO PADRE')
BEGIN
	DECLARE @IdPadre int = 	
	(SELECT Id_tipo FROM Catalogo WHERE Nombre_tipo = @Texto_busqueda)

	SELECT *
	FROM Catalogo ca
	WHERE ca.Id_padre = @IdPadre
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