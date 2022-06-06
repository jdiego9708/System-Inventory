INSERT INTO Usuarios VALUES('2021-08-04', 'JUAN DIEGO DUQUE', '3229098696', '1053859229', 'jdiego9708@gmail.com', 2, 'ACTIVO');
DECLARE @Id_usuario int = SCOPE_IDENTITY();
INSERT INTO Credenciales_usuario
VALUES (@Id_usuario, '2021-08-04', '16:05', '9708', 'ACTIVO')