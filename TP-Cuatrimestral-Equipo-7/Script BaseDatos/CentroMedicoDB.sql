

CREATE DATABASE CentroMedicoDB;
GO

USE CentroMedicoDB;
GO

CREATE TABLE Especialidades (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255)
);
GO

INSERT INTO Especialidades (nombre)
VALUES
    ('Cardiología'),
    ('Dermatología'),
    ('Gastroenterología'),
    ('Neurología'),
    ('Pediatría'),
    ('Oftalmología'),
    ('Oncología'),
    ('Psiquiatría'),
    ('Traumatología'),
    ('Urología');
