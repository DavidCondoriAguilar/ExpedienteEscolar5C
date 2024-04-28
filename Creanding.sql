-- Crear la base de datos
CREATE DATABASE GestorExpedientesEstudiantiles;

-- Usar la base de datos recién creada
USE GestorExpedientesEstudiantiles;

-- Crear tabla de estudiantes
CREATE TABLE Estudiantes (
    EstudianteID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar estudiantes
    Nombre NVARCHAR(100) NOT NULL, -- Restricción NOT NULL para el nombre
    Apellido NVARCHAR(100) NOT NULL, -- Restricción NOT NULL para el apellido
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
    EstudianteID INT FOREIGN KEY REFERENCES Estudiantes(EstudianteID), -- Clave foránea que relaciona expedientes con estudiantes
    FechaCreacion DATETIME DEFAULT GETDATE(),
    Descripcion NVARCHAR(255)
);

-- Crear tabla de documentos
CREATE TABLE Documentos (
    DocumentoID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar documentos
    ExpedienteID INT FOREIGN KEY REFERENCES Expedientes(ExpedienteID), -- Clave foránea que relaciona documentos con expedientes
    NombreDocumento NVARCHAR(255),
    RutaDocumento NVARCHAR(255)
);

-- Crear tabla de categorías
CREATE TABLE Categorias (
    CategoriaID INT PRIMARY KEY IDENTITY, -- Clave primaria autoincrementable para identificar categorías
    NombreCategoria NVARCHAR(50) NOT NULL -- Restricción NOT NULL para el nombre de categoría
);

-- Crear tabla de asignación de categorías a documentos
CREATE TABLE DocumentoCategoria (
    DocumentoID INT,
    CategoriaID INT,
    PRIMARY KEY (DocumentoID, CategoriaID),
    FOREIGN KEY (DocumentoID) REFERENCES Documentos(DocumentoID), -- Clave foránea que relaciona DocumentoCategoria con Documentos
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID) -- Clave foránea que relaciona DocumentoCategoria con Categorias
);

-- Insertar datos de Estudiantes
INSERT INTO Estudiantes (Nombre, Apellido, FechaNacimiento, Direccion, Email, Telefono)
VALUES 
  ('Juan', 'Pérez', '1998-05-15', 'Av. Principal 123', 'juanperez@example.com', '987654321'),
  ('María', 'López', '1999-09-20', 'Calle 1A, Barrio Universitario', 'marialopez@example.com', '999888777'),
  ('Pedro', 'García', '2000-03-10', 'Jr. Los Álamos 456', 'pedrogarcia@example.com', '555444333'),
  ('Ana', 'Martínez', '1997-12-03', 'Urb. Los Robles Mz 7 Lt 15', 'anamartinez@example.com', '333222111'),
  ('Luis', 'Rodríguez', '2001-07-28', 'Av. Libertad 789', 'luisrodriguez@example.com', '777666555');

-- Insertar datos de Expedientes
INSERT INTO Expedientes (EstudianteID, FechaCreacion, Descripcion)
VALUES 
  (1, '2023-02-10T09:30:00', 'Expediente de Juan Pérez'),
  (2, '2023-02-12T10:15:00', 'Expediente de María López'),
  (3, '2023-02-14T11:45:00', 'Expediente de Pedro García'),
  (4, '2023-02-16T08:00:00', 'Expediente de Ana Martínez'),
  (5, '2023-02-18T09:00:00', 'Expediente de Luis Rodríguez');

-- Insertar datos de Documentos
INSERT INTO Documentos (ExpedienteID, NombreDocumento, RutaDocumento)
VALUES 
  (1, 'Boleta de Calificaciones Trimestre 1', '/documentos/juanperez/boleta_trimestre1.pdf'),
  (1, 'Boleta de Calificaciones Trimestre 2', '/documentos/juanperez/boleta_trimestre2.pdf'),
  (2, 'Certificado de Estudios', '/documentos/marialopez/certificado.pdf'),
  (3, 'Informe de Conducta', '/documentos/pedrogarcia/informe_conducta.pdf'),
  (4, 'Certificado Médico', '/documentos/anamartinez/certificado_medico.pdf'),
  (5, 'Fotocopia de DNI', '/documentos/luisrodriguez/fotocopia_dni.pdf');

-- Insertar datos de Categorías
INSERT INTO Categorias (NombreCategoria)
VALUES 
  ('Notas'),
  ('Documentos de Identidad'),
  ('Documentos Médicos'),
  ('Certificados'),
  ('Informes');



--TABLA PARA EL LOGIN

CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    Contraseña NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    RolID INT FOREIGN KEY REFERENCES Roles(RolID) -- Clave foránea que relaciona usuarios con roles
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
INSERT INTO Usuarios (NombreUsuario, Contraseña, Email, RolID)
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