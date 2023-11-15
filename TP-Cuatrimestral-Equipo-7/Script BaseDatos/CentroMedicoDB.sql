
---------------------------------------------------------------PACIENTES ------------------------------------------
CREATE TABLE Pacientes(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DNI INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Domicilio VARCHAR(100) NOT NULL,
    NumeroTelefonico VARCHAR(20) NOT null
)

INSERT INTO Pacientes (DNI, Nombre, Apellido, Email, FechaNacimiento, Domicilio, NumeroTelefonico)
VALUES
    (123456789, 'Juan', 'Recursamos', 'juan@example.com', '1990-05-15', 'Calle Principal 123', '123-456-7890'),
    (987654321, 'Maria', 'SoloDiez', 'maria@example.com', '1985-10-20', 'Avenida Central 456', '456-789-0123'),
    (555555555, 'Leonel', 'Messi', 'leonel@example.com', '1978-12-03', 'Calle Secundaria 789', '789-012-3456'),
    (777777777, 'Esteban', 'Quito', 'esteban@example.com', '1995-08-25', 'Calle Nueva 567', '321-654-9870'),
    (999999999, 'Steve', 'Jobs', 'steve@example.com', '1980-03-10', 'Avenida Principal 890', '654-987-0123'),
    (111111111, 'Pedro', 'El Escamoso', 'pedro@example.com', '1992-06-28', 'Calle Grande 234', '987-012-3456'),
    (222222222, 'Elsa', 'Pallito', 'elsa@example.com', '1987-09-17', 'Avenida Pequeña 432', '789-123-4560'),
    (333333333, 'Elena', 'De Trolla', 'elena@example.com', '1975-11-05', 'Calle Tranquila 876', '012-345-6789'),
    (444444444, 'Miguel', 'Granados', 'miguel@example.com', '1998-02-20', 'Avenida Rapida 654', '234-567-8901'),
    (666666666, 'Luis', 'Recurseti', 'luis@example.com', '1983-07-12', 'Calle Estrecha 210', '567-890-1234');
    
---------------------------------------------------------------------------------------------------------------------------


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
