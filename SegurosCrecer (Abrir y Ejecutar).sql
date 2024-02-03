CREATE DATABASE [SegurosCrecer]

USE [SegurosCrecer]

CREATE TABLE TipoRamos(
	Id INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(100),
	PRIMARY KEY (Id)
)

INSERT TipoRamos VALUES ('Personas')
INSERT TipoRamos VALUES ('Generales')

CREATE TABLE Ramos (
	Id INT IDENTITY(1,1) NOT NULL,
	TipoRamoId INT NOT NULL,
	Descripcion VARCHAR(100),
	PRIMARY KEY(Id),
	FOREIGN KEY (TipoRamoId) REFERENCES TipoRamos(Id)
)

INSERT INTO Ramos VALUES (1, 'Vida')
INSERT INTO Ramos VALUES (1, 'Accidentes Personales')

INSERT INTO Ramos VALUES (2, 'Auto')
INSERT INTO Ramos VALUES (2, 'Incendio')
INSERT INTO Ramos VALUES (2, 'Transporte Maritimo')
INSERT INTO Ramos VALUES (2, 'Transporte Terrestre')

CREATE TABLE Productos (
	Id INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(100),
	PRIMARY KEY (Id)
)

INSERT INTO Productos VALUES ('Vida')

CREATE TABLE Tasas (
	Id INT IDENTITY(1,1) NOT NULL,
	ProductoId INT NOT NULL,
	Descripcion VARCHAR(100),
	Tasa DECIMAL(18, 2) NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY (ProductoId) REFERENCES Tasas(Id)
)

INSERT INTO Tasas VALUES (1, 'Tasa Vida', 0.08)
INSERT INTO Tasas VALUES (1, 'Tasa Accidentes Personales', 0.02)
INSERT INTO Tasas VALUES (1, 'Tasa Auto', 0.15)
INSERT INTO Tasas VALUES (1, 'Tasa Incendio', 0.20)