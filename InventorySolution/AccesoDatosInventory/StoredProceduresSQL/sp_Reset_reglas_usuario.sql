CREATE PROC [dbo].[sp_Reset_reglas_usuario]
@Id_usuario int
AS
BEGIN
DELETE FROM Reglas_usuario WHERE Id_usuario = @Id_usuario

INSERT INTO Reglas_usuario
SELECT Id_regla, @Id_usuario , Estado_regla
FROM Reglas

SELECT * FROM Reglas_usuario WHERE Id_usuario = @Id_usuario
END