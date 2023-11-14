ALTER TABLE Usuarios
ADD Email VARCHAR(50) NULL

GO

SELECT * FROM Pacientes
SELECT * FROM Usuarios

GO

ALTER TABLE Pacientes
ADD IDUsuario INT FOREIGN KEY REFERENCES Usuarios(Id)

GO

CREATE PROCEDURE insertarNuevo
@Email VARCHAR(50),
@Pass VARCHAR(50),
@User VARCHAR(50)
AS
INSERT INTO Usuarios(Usuario,Pass,TipoUser,Email) output inserted.Id VALUES(@User,@Pass,4,@Email)

SELECT * FROM Usuarios
