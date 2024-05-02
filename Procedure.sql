CREATE OR ALTER PROCEDURE SP_MostrarEstudianteTodo
AS
BEGIN
    SELECT * FROM Estudiantes;
END
GO
EXEC SP_MostrarEstudianteTodo;
GO
 select * from Estudiantes

 exec SP_MostrarEstudianteTodo

 CREATE OR ALTER PROCEDURE SP_RegistrarEstudiante
    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @fechaNacimiento DATE,
    @direccion NVARCHAR(255),
    @email NVARCHAR(100),
    @telefono NVARCHAR(20),
    @estado INT = 1 -- Valor predeterminado para el estado
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN
        INSERT INTO Estudiantes (Nombre, Apellido, FechaNacimiento, Direccion, Email, Telefono, Estado)
        VALUES (@nombre, @apellido, @fechaNacimiento, @direccion, @email, @telefono, @estado);
        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
    END CATCH
END
GO

EXEC SP_RegistrarEstudiante
    @nombre = 'Camila',
    @apellido = 'Aguilar',
    @fechaNacimiento = '1999-01-01',
    @direccion = 'Dirección de Prueba',
    @email = 'test@example.com',
    @telefono = '958475123',
    @estado = 0; 

	select * from Estudiantes

CREATE OR ALTER PROCEDURE SP_ActualizarEstudiante
    @estudianteID INT,
    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @fechaNacimiento DATE,
    @direccion NVARCHAR(255),
    @email NVARCHAR(100),
    @telefono NVARCHAR(20),
    @estado INT = NULL -- Permitir que @estado sea nulo
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN
        UPDATE Estudiantes
        SET Nombre = @nombre,
            Apellido = @apellido,
            FechaNacimiento = @fechaNacimiento,
            Direccion = @direccion,
            Email = @email,
            Telefono = @telefono,
            Estado = CASE WHEN @estado IS NOT NULL THEN @estado ELSE Estado END -- Comprobar si @estado es nulo
        WHERE EstudianteID = @estudianteID;
        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
    END CATCH
END




-- Actualizar un estudiante existente
EXEC SP_ActualizarEstudiante
    @estudianteID = 1,
    @nombre = 'Juan Carlos',
    @apellido = 'Pérez',
    @fechaNacimiento = '1998-05-15',
    @direccion = 'Av. Principal 123, Lima',
    @email = 'juancarlos@example.com',
    @telefono = '987654321',
    @estado = 1; -- Cambiar el estado según corresponda

-- Verificar que el estudiante se haya actualizado correctamente
SELECT * FROM Estudiantes WHERE EstudianteID = 1;



CREATE OR ALTER PROCEDURE SP_EliminarEstudiante
    @estudianteID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN
        UPDATE Estudiantes
        SET Estado = 0, -- Soft delete cambiando el estado a 0
            FechaEliminacion = GETDATE() -- Agrega la fecha de eliminación
        WHERE EstudianteID = @estudianteID;
        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
    END CATCH
END


EXEC SP_EliminarEstudiante @estudianteID = 1;


CREATE OR ALTER PROCEDURE SP_CrearCategoria
    @nombreCategoria NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN

        -- Verificar si la categoría ya existe
        IF NOT EXISTS (SELECT 1 FROM Categorias WHERE NombreCategoria = @nombreCategoria)
        BEGIN
            INSERT INTO Categorias (NombreCategoria)
            VALUES (@nombreCategoria);
            COMMIT TRAN;
            SELECT 'Categoría creada exitosamente.' AS Mensaje;
        END
        ELSE
        BEGIN
            ROLLBACK TRAN;
            SELECT 'La categoría ya existe.' AS Mensaje;
        END
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        SELECT 'Error al crear la categoría.' AS Mensaje;
    END CATCH
END

EXEC SP_CrearCategoria @nombreCategoria = 'Notas';


CREATE OR ALTER PROCEDURE SP_ObtenerCategoria
    @nombreCategoria NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Categorias WHERE NombreCategoria = @nombreCategoria)
    BEGIN
        SELECT CategoriaID, NombreCategoria
        FROM Categorias
        WHERE NombreCategoria = @nombreCategoria;
    END
    ELSE
    BEGIN
        SELECT 'La categoría no existe.' AS Mensaje;
    END
END

EXEC SP_ObtenerCategoria @nombreCategoria = 'Notas';




CREATE OR ALTER PROCEDURE SP_ActualizarCategoria
    @categoriaID INT,
    @nombre NVARCHAR(50) 
AS
BEGIN
    BEGIN TRAN SP_ActualizarCategoria
    BEGIN TRY
        UPDATE Categorias
        SET NombreCategoria = @nombre
        WHERE CategoriaID = @categoriaID;
        COMMIT TRAN SP_ActualizarCategoria
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_ActualizarCategoria
    END CATCH
END
GO

EXEC SP_ActualizarCategoria @categoriaID = 6, @nombre = 'Reclamaciones';



CREATE OR ALTER PROCEDURE SP_EliminarCategoria
    @categoriaID INT
AS
BEGIN
    BEGIN TRAN SP_EliminarCategoria
    BEGIN TRY
        DELETE FROM Categorias
        WHERE CategoriaID = @categoriaID;
        COMMIT TRAN SP_EliminarCategoria
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_EliminarCategoria
    END CATCH
END
GO

EXEC SP_EliminarCategoria @categoriaID = 6;

select * from Categorias


--LOGIN

CREATE OR ALTER PROCEDURE SP_Login
    @nombreUsuario NVARCHAR(50),
    @contrasena NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrasena)
    BEGIN
        SELECT UsuarioID, RolID
        FROM Usuarios
        WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrasena;
    END
    ELSE
    BEGIN
        SELECT 'Usuario o contraseña incorrectos.' AS Mensaje;
    END
END



EXEC SP_Login @nombreUsuario = 'admin', @contrasena = 'admintest';


--NUEVAS FUNCIONALIDADES


--ACTUALIZANDO ESTADO ESTUDIANTE
CREATE OR ALTER PROCEDURE SP_ActualizarEstudianteEstado
    @estudianteID INT,
    @nombre NVARCHAR(100) = NULL,
    @apellido NVARCHAR(100) = NULL,
    @fechaNacimiento DATE = NULL,
    @direccion NVARCHAR(255) = NULL,
    @email NVARCHAR(100) = NULL,
    @telefono NVARCHAR(20) = NULL,
    @estado INT = NULL, 
    @nuevoEstado INT = NULL -- Nuevo parámetro para indicar el nuevo estado del estudiante
AS
BEGIN
    BEGIN TRAN SP_ActualizarEstudianteEstado
    BEGIN TRY
       
        IF @nuevoEstado IS NOT NULL
        BEGIN
            UPDATE Estudiantes
            SET Estado = @nuevoEstado -- Actualiza el estado del estudiante
            WHERE EstudianteID = @estudianteID;
        END
        ELSE
        BEGIN
            -- Actualiza otros datos del estudiante sin cambiar el estado
            UPDATE Estudiantes
            SET Nombre = COALESCE(@nombre, Nombre),
                Apellido = COALESCE(@apellido, Apellido),
                FechaNacimiento = COALESCE(@fechaNacimiento, FechaNacimiento),
                Direccion = COALESCE(@direccion, Direccion),
                Email = COALESCE(@email, Email),
                Telefono = COALESCE(@telefono, Telefono)
            WHERE EstudianteID = @estudianteID;
        END
        COMMIT TRAN SP_ActualizarEstudianteEstado
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_ActualizarEstudianteEstado
    END CATCH
END
GO

EXEC SP_ActualizarEstudianteEstado @estudianteID = 5, @nuevoEstado = 0;

USE GestorExpedientesEstudiantiles;
select * from Estudiantes

--PARA BUSCAR ESTUDIANTE
CREATE OR ALTER PROCEDURE SP_BuscarEstudiantes
    @nombre NVARCHAR(100)
AS
BEGIN
    SELECT EstudianteID, Nombre, Apellido, FechaNacimiento, Direccion, Email, Telefono, 
           CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS EstadoEstudiante
    FROM Estudiantes
    WHERE Nombre LIKE '%' + @nombre + '%' OR Apellido LIKE '%' + @nombre + '%';
END




CREATE INDEX idx_BusquedaEstudiantes ON Estudiantes(Nombre, Apellido);
EXEC SP_BuscarEstudiantes @nombre = 'Deiv';



--PARA BUSCAR EXPEDIENTES POR FECHA
CREATE OR ALTER PROCEDURE SP_BuscarExpedientes
    @estudianteID INT
AS
BEGIN
    SELECT ExpedienteID, EstudianteID, FechaCreacion, Descripcion
    FROM Expedientes
    WHERE EstudianteID = @estudianteID;
END

EXEC SP_BuscarExpedientes @estudianteID = 5; 



select * from Expedientes
EXEC SP_BuscarExpedientes @estudianteID = 1, @fechaInicio = '2023-02-10', @fechaFin = '2024-12-31';



	select *  from Estudiantes