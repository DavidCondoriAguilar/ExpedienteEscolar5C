-- Crear la base de datos
CREATE DATABASE GestorExpedientesEstudiantiles;

-- Usar la base de datos reci�n creada
USE GestorExpedientesEstudiantiles;

-- Crear tabla de estudiantes
CREATE TABLE Estudiantes (
    EstudianteID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar estudiantes
    Nombre NVARCHAR(100) NOT NULL, -- Restricci�n NOT NULL para el nombre
    Apellido NVARCHAR(100) NOT NULL, -- Restricci�n NOT NULL para el apellido
    FechaNacimiento DATE,
    Direccion NVARCHAR(255),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
	Estado INT DEFAULT 1
);
--ALTER TABLE Estudiantes ADD Estado INT DEFAULT 1; -- Valor por defecto 1 para estado activo


-- Crear tabla de expedientes
CREATE TABLE Expedientes (
    ExpedienteID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar expedientes
    EstudianteID INT FOREIGN KEY REFERENCES Estudiantes(EstudianteID), -- Clave for�nea que relaciona expedientes con estudiantes
    FechaCreacion DATETIME DEFAULT GETDATE(),
    Descripcion NVARCHAR(255)
);

-- Crear tabla de documentos
CREATE TABLE Documentos (
    DocumentoID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar documentos
    ExpedienteID INT FOREIGN KEY REFERENCES Expedientes(ExpedienteID), -- Clave for�nea que relaciona documentos con expedientes
    NombreDocumento NVARCHAR(255),
    RutaDocumento NVARCHAR(255)
);

-- Crear tabla de categor�as
CREATE TABLE Categorias (
    CategoriaID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar categor�as
    NombreCategoria NVARCHAR(50) NOT NULL -- Restricci�n NOT NULL para el nombre de categor�a
);

-- Crear tabla de asignaci�n de categor�as a documentos
CREATE TABLE DocumentoCategoria (
    DocumentoID INT,
    CategoriaID INT,
    PRIMARY KEY (DocumentoID, CategoriaID),
    FOREIGN KEY (DocumentoID) REFERENCES Documentos(DocumentoID), -- Clave for�nea que relaciona DocumentoCategoria con Documentos
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID) -- Clave for�nea que relaciona DocumentoCategoria con Categorias
);

-- Insertar datos de Estudiantes
INSERT INTO Estudiantes (Nombre, Apellido, FechaNacimiento, Direccion, Email, Telefono)
VALUES 
  ('Juan', 'P�rez', '1998-05-15', 'Av. Principal 123', 'juanperez@example.com', '987654321'),
  ('Mar�a', 'L�pez', '1999-09-20', 'Calle 1A, Barrio Universitario', 'marialopez@example.com', '999888777'),
  ('Pedro', 'Garc�a', '2000-03-10', 'Jr. Los �lamos 456', 'pedrogarcia@example.com', '555444333'),
  ('Ana', 'Mart�nez', '1997-12-03', 'Urb. Los Robles Mz 7 Lt 15', 'anamartinez@example.com', '333222111'),
  ('Luis', 'Rodr�guez', '2001-07-28', 'Av. Libertad 789', 'luisrodriguez@example.com', '777666555');

-- Insertar datos de Expedientes
INSERT INTO Expedientes (EstudianteID, FechaCreacion, Descripcion)
VALUES 
  (1, '2023-02-10T09:30:00', 'Expediente de Juan P�rez'),
  (2, '2023-02-12T10:15:00', 'Expediente de Mar�a L�pez'),
  (3, '2023-02-14T11:45:00', 'Expediente de Pedro Garc�a'),
  (4, '2023-02-16T08:00:00', 'Expediente de Ana Mart�nez'),
  (5, '2023-02-18T09:00:00', 'Expediente de Luis Rodr�guez');

-- Insertar datos de Documentos
INSERT INTO Documentos (ExpedienteID, NombreDocumento, RutaDocumento)
VALUES 
  (1, 'Boleta de Calificaciones Trimestre 1', '/documentos/juanperez/boleta_trimestre1.pdf'),
  (1, 'Boleta de Calificaciones Trimestre 2', '/documentos/juanperez/boleta_trimestre2.pdf'),
  (2, 'Certificado de Estudios', '/documentos/marialopez/certificado.pdf'),
  (3, 'Informe de Conducta', '/documentos/pedrogarcia/informe_conducta.pdf'),
  (4, 'Certificado M�dico', '/documentos/anamartinez/certificado_medico.pdf'),
  (5, 'Fotocopia de DNI', '/documentos/luisrodriguez/fotocopia_dni.pdf');

-- Insertar datos de Categor�as
INSERT INTO Categorias (NombreCategoria)
VALUES 
  ('Notas'),
  ('Documentos de Identidad'),
  ('Documentos M�dicos'),
  ('Certificados'),
  ('Informes');



--TABLA PARA EL LOGIN

CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    Contrase�a NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    RolID INT FOREIGN KEY REFERENCES Roles(RolID) -- Clave for�nea que relaciona usuarios con roles
);

CREATE TABLE Roles (
    RolID INT PRIMARY KEY IDENTITY,
    NombreRol NVARCHAR(50) NOT NULL
);


CREATE TABLE UsuarioRoles (
    UsuarioID INT,
    RolID INT,
    PRIMARY KEY (UsuarioID, RolID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

-- Insertar roles de ejemplo
INSERT INTO Roles (NombreRol) VALUES ('Admin'), ('Usuario');

-- Insertar usuarios de ejemplo
INSERT INTO Usuarios (NombreUsuario, Contrase�a, Email, RolID)
VALUES 
  ('admin', 'admintest', 'admin@example.com', 1), -- Asignar el rol de Admin (RolID = 1)
  ('usuario1', 'usuariotest', 'usuario1@example.com', 2); -- Asignar el rol de Usuario (RolID = 2)

-- Asignar roles a los usuarios
INSERT INTO UsuarioRoles (UsuarioID, RolID)
VALUES
  (1, 1), -- Asignar el rol de Admin al usuario con UsuarioID = 1
  (2, 2); -- Asignar el rol de Usuario al usuario con UsuarioID = 2


  select * from Estudiantes
  select * from Expedientes
  select * from Documentos
  select * from Categorias
  select * from DocumentoCategoria

  select * from Roles
  select * from UsuarioRoles
  select * from Usuarios