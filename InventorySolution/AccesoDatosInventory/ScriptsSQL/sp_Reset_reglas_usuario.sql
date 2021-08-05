USE [InventoryBD]
GO
/****** Object:  StoredProcedure [dbo].[sp_Reset_reglas_usuario]    Script Date: 5/08/2021 12:18:08 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_Reset_reglas_usuario]
@Id_usuario int
AS
BEGIN
DELETE FROM Reglas_usuarios WHERE Id_usuario = @Id_usuario

INSERT INTO Reglas_usuarios
SELECT Id_regla, @Id_usuario , Estado_regla
FROM Reglas

SELECT * FROM Reglas_usuarios WHERE Id_usuario = @Id_usuario
END