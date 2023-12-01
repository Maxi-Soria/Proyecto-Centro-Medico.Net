CREATE DATABASE CentroMedico_DB;
GO
USE CentroMedico_DB;
GO
--    ESPECIALIDADES
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--    MEDICOS  --
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IDMedico] [int] IDENTITY(1,1) NOT NULL,
	[Legajo] [int] NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




--  HORARIOS ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[IDHorario] [int] IDENTITY(1,1) NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFin] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--  USUARIOS -- 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NOT NULL,
	[TipoUser] [int] NOT NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-- PACIENTES -- 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[NumeroTelefonico] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



-- ROLES
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-- TURNOS -- 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[IDTurno] [int] IDENTITY(1,1) NOT NULL,
	[IDMedico] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[ObservacionesMedico] [varchar](200) NULL,
	[Estado] [bit] NOT NULL,
	[IDHorario] [int] NULL,
	[IDUsuario] [int] NULL,
	[Situacion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD FOREIGN KEY([IDMedico])
REFERENCES [dbo].[Medicos] ([IDMedico])
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Horarios] FOREIGN KEY([IDHorario])
REFERENCES [dbo].[Horarios] ([IDHorario])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Horarios]
GO



-- TURNOS MANUALES
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurnosManuales](
	[IDTurnoManual] [int] IDENTITY(1,1) NOT NULL,
	[NombrePaciente] [nvarchar](255) NOT NULL,
	[ApellidoPaciente] [nvarchar](255) NOT NULL,
	[EmailPaciente] [nvarchar](255) NOT NULL,
	[DNIPaciente] [nvarchar](20) NOT NULL,
	[IDHorario] [int] NOT NULL,
	[IDMedico] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTurnoManual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TurnosManuales]  WITH CHECK ADD  CONSTRAINT [FK_TurnosManuales_Horarios] FOREIGN KEY([IDHorario])
REFERENCES [dbo].[Horarios] ([IDHorario])
GO
ALTER TABLE [dbo].[TurnosManuales] CHECK CONSTRAINT [FK_TurnosManuales_Horarios]
GO
ALTER TABLE [dbo].[TurnosManuales]  WITH CHECK ADD  CONSTRAINT [FK_TurnosManuales_Medicos] FOREIGN KEY([IDMedico])
REFERENCES [dbo].[Medicos] ([IDMedico])
GO
ALTER TABLE [dbo].[TurnosManuales] CHECK CONSTRAINT [FK_TurnosManuales_Medicos]
GO




--ESPECIALIDADES POR MEDICO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades_x_Medico](
	[IDEspecialidad] [int] NOT NULL,
	[IDMedico] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEspecialidad] ASC,
	[IDMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Especialidades_x_Medico]  WITH CHECK ADD FOREIGN KEY([IDEspecialidad])
REFERENCES [dbo].[Especialidades] ([Id])
GO
ALTER TABLE [dbo].[Especialidades_x_Medico]  WITH CHECK ADD FOREIGN KEY([IDMedico])
REFERENCES [dbo].[Medicos] ([IDMedico])
GO



--  HORARIOS POR MEDICO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios_x_Medico](
	[IDMedico] [int] NOT NULL,
	[IDHorario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDMedico] ASC,
	[IDHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Horarios_x_Medico]  WITH CHECK ADD FOREIGN KEY([IDHorario])
REFERENCES [dbo].[Horarios] ([IDHorario])
GO
ALTER TABLE [dbo].[Horarios_x_Medico]  WITH CHECK ADD FOREIGN KEY([IDMedico])
REFERENCES [dbo].[Medicos] ([IDMedico])
GO


-- ROCEDIMIENTO ALMACENADO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertarNuevo]
@Email VARCHAR(50),
@Pass VARCHAR(50),
@User VARCHAR(50)
AS
INSERT INTO Usuarios(Usuario,Pass,TipoUser,Email) output inserted.Id VALUES(@User,@Pass,4,@Email)
GO

-- CARGA DE DATOS DE PRUEBA
INSERT INTO Especialidades (Nombre)
VALUES
    ('Cardiologia'),
    ('Dermatologia'),
    ('Ginecologia'),
    ('Neurologia'),
    ('Oncologia'),
    ('Pediatria'),
    ('Psiquiatria'),
    ('Traumatologia'),
    ('Urologia'),
    ('Oftalmologia');

GO

INSERT INTO Medicos (Legajo, Nombre, Apellido, Email)
VALUES
    (12345, 'Juan', 'Gomez', 'juangomez@example.com'),
    (23456, 'Maria', 'Lopez', 'marialopez@example.com'),
    (34567, 'Carlos', 'Perez', 'carlosperez@example.com'),
    (45678, 'Laura', 'Rodriguez', 'laurarodriguez@example.com'),
    (56789, 'Pedro', 'Garcia', 'pedrogarcia@example.com'),
    (67890, 'Ana', 'Martinez', 'anamartinez@example.com'),
    (78901, 'Diego', 'Sanchez', 'diegosanchez@example.com'),
    (89012, 'Elena', 'Fernandez', 'elenafernandez@example.com'),
    (90123, 'Jorge', 'Torres', 'jorgetorres@example.com'),
    (12340, 'Sofia', 'Diaz', 'sofiadiaz@example.com');

GO

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

GO

INSERT INTO Usuarios (Usuario, Pass, TipoUser, Email)
VALUES
    ('Admin', 'admin', 1, 'admin@example.com'),
    ('Recepcionista', 'recepcionista', 2, 'recepcionista@example.com'), 
    ('Medico', 'medico', 3, 'medico@example.com'); 

GO

INSERT INTO Pacientes (DNI, Nombre, Apellido, Email, FechaNacimiento, Domicilio, NumeroTelefonico)
VALUES
    (11111111, 'Juan', 'Gomez', 'juangomez@example.com', '1990-05-15', 'Calle 123', '1234567890'),
    (22222222, 'Maria', 'Lopez', 'marialopez@example.com', '1985-08-20', 'Avenida Principal', '9876543210'),
    (33333333, 'Carlos', 'Perez', 'carlosperez@example.com', '1978-12-10', 'Calle Central', '5556667777'),
    (44444444, 'Laura', 'Rodriguez', 'laurarodriguez@example.com', '1995-02-28', 'Calle Norte', '1112223333'),
    (55555555, 'Pedro', 'Garcia', 'pedrogarcia@example.com', '1980-07-03', 'Avenida Sur', '9998887777'),
    (66666666, 'Ana', 'Martinez', 'anamartinez@example.com', '1992-10-18', 'Calle Este', '3334445555'),
    (77777777, 'Diego', 'Sanchez', 'diegosanchez@example.com', '1987-04-25', 'Calle Oeste', '6667778888'),
    (88888888, 'Elena', 'Fernandez', 'elenafernandez@example.com', '1976-11-30', 'Avenida Este', '2223334444'),
    (99999999, 'Jorge', 'Torres', 'jorgetorres@example.com', '1998-09-12', 'Avenida Oeste', '7778889999'),
    (10101010, 'Sofia', 'Diaz', 'sofiadiaz@example.com', '2000-03-05', 'Calle Principal', '4445556666');

GO

INSERT INTO Roles (Nombre)
VALUES
    ('Administrador'),
    ('Recepcionista'),
    ('Medico');

GO

INSERT INTO Turnos (IDMedico, Fecha, ObservacionesMedico, Estado, IDHorario, IDUsuario, Situacion)
VALUES
    (1, '2023-12-15', 'Consulta de rutina', 1, 1, 1, 'Confirmado'),
    (2, '2023-12-16', 'Control post-operatorio', 1, 2, 2, 'Confirmado'),
    (3, '2023-12-17', 'Examen medico', 1, 3, 3, 'Confirmado'),
    (4, '2023-12-18', 'Consulta general', 1, 4, 4, 'Confirmado'),
    (1, '2023-12-19', 'Chequeo anual', 1, 5, 5, 'Confirmado'),
    (2, '2023-12-20', 'Control de medicacion', 1, 6, 6, 'Confirmado'),
    (3, '2023-12-21', 'Consulta de seguimiento', 1, 7, 7, 'Confirmado'),
    (4, '2023-12-22', 'Consulta de especialista', 1, 8, 8, 'Confirmado'),
    (1, '2023-12-23', 'Evaluacion fisica', 1, 9, 9, 'Confirmado'),
    (2, '2023-12-24', 'Tratamiento medico', 1, 10, 10, 'Confirmado');

GO

INSERT INTO Especialidades_x_Medico (IDEspecialidad, IDMedico)
VALUES
    (1, 1), 
    (2, 1),
    (3, 2), 
    (4, 2),
    (5, 3), 
    (6, 3),
    (7, 4), 
    (8, 4),
    (9, 5), 
    (10, 5),
    (1, 6), 
    (2, 6),
    (3, 7), 
    (4, 7),
    (5, 8), 
    (6, 8),
    (7, 9), 
    (8, 9),
    (9, 10), 
    (10, 10);

GO

INSERT INTO Horarios_x_Medico (IDMedico, IDHorario)
VALUES
    (1, 1), 
    (1, 2), 
    (1, 3), 
    (1, 4), 
    (1, 5),
    (2, 6), 
    (2, 7), 
    (2, 8), 
    (2, 9), 
    (2, 10),
    (3, 11), 
    (3, 12), 
    (3, 13), 
    (3, 14), 
    (3, 15),
    (4, 16), 
    (4, 17), 
    (4, 18), 
    (4, 19), 
    (4, 20);



/*
Especialidad, 
Medicos, 
Horarios, 
Usuarios, 
Pacientes, 
Roles,
Turnos,
TurnosManuales, 

Especialidades_x_Medico, 
Horario_x_Medico */

