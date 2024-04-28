CREATE OR ALTER PROCEDURE SP_MostrarEstudianteTodo
AS
BEGIN
    SELECT * FROM Estudiantes;
END
GO
EXEC SP_MostrarEstudianteTodo;
GO



CREATE OR ALTER PROCEDURE SP_RegistrarEstudiante
    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @fechaNacimiento DATE,
    @direccion NVARCHAR(255),
    @email NVARCHAR(100),
    @telefono NVARCHAR(20)
AS
BEGIN
    BEGIN TRAN SP_RegistrarEstudiante
    BEGIN TRY
        INSERT INTO Estudiantes (Nombre, Apellido, FechaNacimiento, Direccion, Email, Telefono)
        VALUES (@nombre, @apellido, @fechaNacimiento, @direccion, @email, @telefono);
        COMMIT TRAN SP_RegistrarEstudiante
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_RegistrarEstudiante
    END CATCH
END
GO

EXEC SP_RegistrarEstudiante
    @nombre = 'Deiv',
    @apellido = 'Aguilar',
    @fechaNacimiento = '1999-01-01',
    @direccion = 'Dirección de Prueba',
    @email = 'test@example.com',
    @telefono = '958475123';


CREATE OR ALTER PROCEDURE SP_ActualizarEstudiante
    @estudianteID INT,
    @nombre NVARCHAR(100),
    @apellido NVARCHAR(100),
    @fechaNacimiento DATE,
    @direccion NVARCHAR(255),
    @email NVARCHAR(100),
    @telefono NVARCHAR(20),
    @estado INT -- Agregado para actualizar el estado del estudiante
AS
BEGIN
    BEGIN TRAN SP_ActualizarEstudiante
    BEGIN TRY
        UPDATE Estudiantes
        SET Nombre = @nombre,
            Apellido = @apellido,
            FechaNacimiento = @fechaNacimiento,
            Direccion = @direccion,
            Email = @email,
            Telefono = @telefono,
            Estado = @estado -- Actualiza el estado del estudiante
        WHERE EstudianteID = @estudianteID;
        COMMIT TRAN SP_ActualizarEstudiante
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_ActualizarEstudiante
    END CATCH
END
GO



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
    BEGIN TRAN SP_EliminarEstudiante
    BEGIN TRY
        UPDATE Estudiantes
        SET Estado = 0 -- Cambia el estado del estudiante en lugar de eliminar físicamente
        WHERE EstudianteID = @estudianteID;
        COMMIT TRAN SP_EliminarEstudiante
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_EliminarEstudiante
    END CATCH
END
GO

EXEC SP_EliminarEstudiante @estudianteID = 1;


CREATE OR ALTER PROCEDURE SP_CrearCategoria
    @nombre NVARCHAR(50) 
AS
BEGIN
    BEGIN TRAN SP_CrearCategoria
    BEGIN TRY
        INSERT INTO Categorias (NombreCategoria)
        VALUES (@nombre);
        COMMIT TRAN SP_CrearCategoria
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN SP_CrearCategoria
    END CATCH
END
GO

EXEC SP_CrearCategoria @nombre = 'Auxiliares';


CREATE OR ALTER PROCEDURE SP_ObtenerCategoria
    @categoriaID INT
AS
BEGIN
    SELECT CategoriaID, NombreCategoria
    FROM Categorias
    WHERE CategoriaID = @categoriaID;
END
GO

EXEC SP_ObtenerCategoria @categoriaID = 6



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

CREATE PROCEDURE SP_Login
    @nombreUsuario NVARCHAR(50),
    @contraseña NVARCHAR(100)
AS
BEGIN
    DECLARE @usuarioID INT, @rolID INT;

    -- Verificar si las credenciales son válidas
    SELECT @usuarioID = UsuarioID, @rolID = RolID
    FROM Usuarios
    WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña;

    -- Si se encontró el usuario y las credenciales son correctas
    IF @usuarioID IS NOT NULL
    BEGIN
        SELECT 'Login exitoso' AS Mensaje, @rolID AS RolID;
    END
    ELSE
    BEGIN
        SELECT 'Credenciales inválidas' AS Mensaje, NULL AS RolID;
    END
END

EXEC SP_Login @nombreUsuario = 'usuario1', @contraseña = 'usuariotest';


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
    @estado INT = NULL, -- Agregado para actualizar el estado del estudiante
    @nuevoEstado INT = NULL -- Nuevo parámetro para indicar el nuevo estado del estudiante
AS
BEGIN
    BEGIN TRAN SP_ActualizarEstudianteEstado
    BEGIN TRY
        -- Verifica si se especifica un nuevo estado para actualizar
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

EXEC SP_ActualizarEstudianteEstado @estudianteID = 6, @nuevoEstado = 1;



--PARA BUSCAR ESTUDIANTE
CREATE OR ALTER PROCEDURE SP_BuscarEstudiantes
    @nombre NVARCHAR(100) = NULL,
    @apellido NVARCHAR(100) = NULL,
    @email NVARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM Estudiantes
    WHERE (@nombre IS NULL OR Nombre LIKE '%' + @nombre + '%')
        AND (@apellido IS NULL OR Apellido LIKE '%' + @apellido + '%')
        AND (@email IS NULL OR Email LIKE '%' + @email + '%');
END
GO

EXEC SP_BuscarEstudiantes @nombre = 'Deiv', @apellido = 'Aguilar';


--PARA BUSCAR EXPEDIENTES POR FECHA
CREATE OR ALTER PROCEDURE SP_BuscarExpedientes
    @estudianteID INT = NULL,
    @fechaInicio DATETIME = NULL,
    @fechaFin DATETIME = NULL,
    @descripcion NVARCHAR(255) = NULL
AS
BEGIN
    SELECT *
    FROM Expedientes
    WHERE (@estudianteID IS NULL OR EstudianteID = @estudianteID)
        AND (@fechaInicio IS NULL OR FechaCreacion >= @fechaInicio)
        AND (@fechaFin IS NULL OR FechaCreacion <= @fechaFin)
        AND (@descripcion IS NULL OR Descripcion LIKE '%' + @descripcion + '%');
END
GO

EXEC SP_BuscarExpedientes @estudianteID = 1, @fechaInicio = '2023-02-10', @fechaFin = '2024-12-31';



	select *  from Estudiantes