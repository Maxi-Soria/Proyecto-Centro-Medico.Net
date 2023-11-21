
----------------------------------------------P A C I E N T E S ------------------------------------------
CREATE TABLE Pacientes(
    IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
    DNI INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Domicilio VARCHAR(100) NOT NULL,
    NumeroTelefonico VARCHAR(20) NOT null
)
GO
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


------------------------------------------M E D I C O S------------------------------------------------------------------
CREATE TABLE [dbo].[Medicos] (
    [IDMedico]       INT            IDENTITY (1, 1) NOT NULL,
    [Legajo]         INT            NOT NULL,
    [Nombre]         NVARCHAR (255) NOT NULL,
    [Apellido]       NVARCHAR (255) NOT NULL,
    [Email]          NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([IDMedico] ASC),
);
GO
INSERT INTO Medicos (Legajo, Nombre, Apellido, Email)
VALUES
    (12345, 'Juan', 'Gomez', 'juangomez@example.com'),
    (23456, 'Maria', 'Lopez', 'marialopez@example.com'),
    (34567, 'Pedro', 'Martinez', 'pedromartinez@example.com'),
    (45678, 'Ana', 'Rodriguez', 'anarodriguez@example.com'),
    (56789, 'Luis', 'Perez', 'luisperez@example.com'),
    (67890, 'Laura', 'Garcia', 'lauragarcia@example.com'),
    (78901, 'Diego', 'Hernandez', 'diegohernandez@example.com'),
    (89012, 'Carla', 'Diaz', 'carladiaz@example.com'),
    (90123, 'Sofia', 'Gomez', 'sofiagomez@example.com'),
    (10111, 'Pablo', 'Fernandez', 'pablofernandez@example.com');

------------------------------------------------------------------------------------------

SELECT * FROM Pacientes
SELECT IDMedico, Legajo, Nombre, Apellido, Email FROM Medicos

CREATE TABLE [dbo].[Especialidades_x_Medico] (
    [IDEspecialidad] INT NOT NULL,
    [IDMedico]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IDEspecialidad] ASC, [IDMedico] ASC),
    FOREIGN KEY ([IDEspecialidad]) REFERENCES [dbo].[Especialidades] ([Id]),
    FOREIGN KEY ([IDMedico]) REFERENCES [dbo].[Medicos] ([IDMedico])
);

CREATE TABLE [dbo].[Horarios] (
    [IDHorario]  INT      IDENTITY (1, 1) NOT NULL,
    [HoraInicio] TIME (7) NOT NULL,
    [HoraFin]    TIME (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([IDHorario] ASC)
);

INSERT INTO Horarios (HoraInicio, HoraFin)
VALUES
    ('00:00', '00:30'),
    ('00:30', '01:00'),
    ('01:00', '01:30'),
    ('01:30', '02:00'),
    ('02:00', '02:30'),
    ('02:30', '03:00'),
    ('03:00', '03:30'),
    ('03:30', '04:00'),
    ('04:00', '04:30'),
    ('04:30', '05:00'),
    ('05:00', '05:30'),
    ('05:30', '06:00'),
    ('06:00', '06:30'),
    ('06:30', '07:00'),
    ('07:00', '07:30'),
    ('07:30', '08:00'),
    ('08:00', '08:30'),
    ('08:30', '09:00'),
    ('09:00', '09:30'),
    ('09:30', '10:00'),
    ('10:00', '10:30'),
    ('10:30', '11:00'),
    ('11:00', '11:30'),
    ('11:30', '12:00'),
    ('12:00', '12:30'),
    ('12:30', '13:00'),
    ('13:00', '13:30'),
    ('13:30', '14:00'),
    ('14:00', '14:30'),
    ('14:30', '15:00'),
    ('15:00', '15:30'),
    ('15:30', '16:00'),
    ('16:00', '16:30'),
    ('16:30', '17:00'),
    ('17:00', '17:30'),
    ('17:30', '18:00'),
    ('18:00', '18:30'),
    ('18:30', '19:00'),
    ('19:00', '19:30'),
    ('19:30', '20:00'),
    ('20:00', '20:30'),
    ('20:30', '21:00'),
    ('21:00', '21:30'),
    ('21:30', '22:00'),
    ('22:00', '22:30'),
    ('22:30', '23:00'),
    ('23:00', '23:30'),
    ('23:30', '00:00');




CREATE TABLE [dbo].[Horarios_x_Medico] (
    [IDMedico]  INT NOT NULL,
    [IDHorario] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IDMedico] ASC, [IDHorario] ASC),
    FOREIGN KEY ([IDHorario]) REFERENCES [dbo].[Horarios] ([IDHorario]),
    FOREIGN KEY ([IDMedico]) REFERENCES [dbo].[Medicos] ([IDMedico])
);


CREATE TABLE [dbo].[Turnos] (
    [IDTurno]             INT           IDENTITY (1, 1) NOT NULL,
    [IDMedico]            INT           NOT NULL,
    [Fecha]               DATE          NOT NULL,
    [ObservacionesMedico] VARCHAR (200) NULL,
    [Estado]              BIT           NOT NULL,
    [IDHorario]           INT           NULL,
    [IDUsuario]           INT           NULL,
    PRIMARY KEY CLUSTERED ([IDTurno] ASC),
    FOREIGN KEY ([IDMedico]) REFERENCES [dbo].[Medicos] ([IDMedico]),
    CONSTRAINT [FK_Turnos_Horarios] FOREIGN KEY ([IDHorario]) REFERENCES [dbo].[Horarios] ([IDHorario])
);

SELECT * FROM Horarios
SELECT * FROM Turnos














--DROP TABLE Pacientes

ALTER TABLE Usuarios
ADD Email VARCHAR(50) NULL

GO



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








