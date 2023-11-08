SELECT * FROM Medicos

SELECT * FROM Especialidades

SELECT * FROM Usuarios

CREATE TABLE Usuarios(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(50) NOT NULL,
    Pass VARCHAR(50)NOT NULL,
    TipoUser INT NOT NULL,
)

INSERT INTO Usuarios (Usuario,Pass,TipoUser)VALUES('Admin','Admin',1)
INSERT INTO Usuarios (Usuario,Pass,TipoUser)VALUES('Recepcionista','Recepcionista',2)
INSERT INTO Usuarios (Usuario,Pass,TipoUser)VALUES('Medico','Medico',3)