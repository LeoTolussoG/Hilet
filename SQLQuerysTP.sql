/*create database TPFinal;*/
use TPFinal;
/*use u26;*/

-- Tabla Carreras
CREATE TABLE Carreras(
Id_carrera INT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (30),
Num_res VARCHAR (10),
Año_PlanEstudio INT,
);

--Tabla Perfiles
CREATE TABLE Perfiles(
Id_perfil INT PRIMARY KEY IDENTITY (1,1),
Tipo_perfil VARCHAR (40)
);

--Tabla Instancias
CREATE TABLE Instancias(
Id_instancia INT PRIMARY KEY IDENTITY (1,1),
Descripcion VARCHAR (50)
);

--Tabla Alumnos
CREATE TABLE Alumnos(
Id_alumno INT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (30),
Apellido VARCHAR (30),
Dni VARCHAR (20),
Direccion_calle VARCHAR (50),
Direccion_num INT,
Email VARCHAR (100),
Telefono VARCHAR (30),
F_nacimiento DATE,
Usuario VARCHAR (40),
Contraseña VARCHAR (40),
Id_perfil INT,
FOREIGN KEY (Id_perfil) REFERENCES Perfiles (Id_perfil)
);

--Tabla Empleados
CREATE TABLE Empleados(
Id_empleado INT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (40),
Apellido VARCHAR (40),
Dni VARCHAR (20),
Direccion_calle VARCHAR (50),
Direccion_num INT,
Email VARCHAR (100),
Telefono VARCHAR (30),
F_nacimiento DATE,
Usuario VARCHAR (40),
Contraseña VARCHAR (40),
Id_perfil INT,
FOREIGN KEY (Id_perfil) REFERENCES Perfiles (Id_perfil)
);

--Tabla Permisos
CREATE TABLE Permisos(
Id_permisos INT PRIMARY KEY IDENTITY (1,1),
Tipo_permiso VARCHAR (50)
);

--Tabla Permisos por Perfil
CREATE TABLE PermisosXPerfil(
Id_PxP INT PRIMARY KEY IDENTITY (1,1),
Id_perfil INT,
Id_permisos INT,
FOREIGN KEY (Id_perfil) REFERENCES Perfiles(Id_perfil),
FOREIGN KEY (Id_permisos) REFERENCES Permisos(Id_permisos)
);

-- Tabla Asingnatura
CREATE TABLE Asignatura(
Id_asignatura INT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50),
Año_cursada INT,
Id_empleado INT,
FOREIGN KEY (Id_empleado) REFERENCES Empleados (Id_Empleado)
);

--Tabla Asignatura por Carrera
CREATE TABLE AsignaturaXCarrera(
Id_AxC INT PRIMARY KEY IDENTITY (1,1),
Id_carrera INT,
Id_asignatura INT,
FOREIGN KEY (Id_carrera) REFERENCES Carreras (Id_carrera),
FOREIGN KEY (Id_asignatura) REFERENCES Asignatura (Id_asignatura)
);

--Tabla Asignatura por Alumnos
CREATE TABLE AsignaturasXAlumnos(
Id_AxA INT PRIMARY KEY IDENTITY (1,1),
Id_asignatura INT,
Id_alumno INT,
FOREIGN KEY (Id_asignatura) REFERENCES Asignatura (Id_asignatura),
FOREIGN KEY (Id_alumno) REFERENCES Alumnos(Id_alumno)
);

--Tabla Examenes
CREATE TABLE Examenes (
Id_examenes INT PRIMARY KEY IDENTITY (1,1),
Nota DECIMAL (5,2),
Fecha DATE,
Id_asignatura INT,
Id_alumno INT,
Id_instancia INT,
Id_empleado int
FOREIGN KEY (Id_asignatura) REFERENCES Asignatura (Id_asignatura),
FOREIGN KEY (Id_alumno) REFERENCES Alumnos (Id_alumno),
FOREIGN KEY (Id_instancia) REFERENCES Instancias(Id_instancia),
FOREIGN KEY (Id_empleado) REFERENCES Empleados(Id_empleado)
);




--Registro de Carreras
INSERT INTO Carreras (Nombre, Num_res, Año_PlanEstudio) VALUES
('Técnico Superior en Publicidad', '3805/06', 3),
('Analista de Sistemas', '6790/19', 3);

/*Asignaturas para Publicidad:*/
INSERT INTO Asignatura (Nombre, Año_cursada, Id_empleado) VALUES
('Marketing general', 1, 2),
('Psicología Comportamiento del Consumidor', 1, 2),
('Fundamentos del diseño publicitario', 1, 2),
('Computación 1', 1, 2),
('Introducción a la publicidad', 1, 2),
('Producción gráfica', 1, 2),
('Producción radial', 1, 2),
('Producción audiovisual', 1, 2),
('Computación 2', 2, 2),
( 'Inglés 1', 2, 2),
( 'Psicología social', 2, 2),
( 'Marketing directo', 2, 2),
( 'Arte, cine, literatura e historia de la publicidad', 2, 2),
( 'Redacción creativa 1', 2, 2),
( 'Dirección de arte 1', 2, 2),
( 'Planificación estratégica de medios', 2, 2),
( 'Semiología publicitaria', 2, 2),
( 'Técnica promocional y pop', 2, 2),
( 'Inglés 2', 3, 2),
( 'Investigación de mercados', 3, 2),
( 'Redacción creativa 2', 3, 2),
( 'Dirección de arte 2', 3, 2),
( 'Práctica profesional', 3, 2),
( 'Atención de cuentas', 3, 2),
( 'Organización y administración de la agencia', 3, 2),
( 'Derecho y legislación publicitaria', 3, 2);

-- Asignaturas para Analista de Sistemas
INSERT INTO Asignatura (Nombre, Año_cursada) VALUES
('Inglés I', 1),
('Ciencia, Tecnología y Sociedad', 1),
('Análisis Matemático I', 1),
('Álgebra', 1),
('Algoritmos y estructuras de datos I', 1),
('Sistemas y Organizaciones', 1),
('Arquitectura de Computadores', 1),
('Prácticas Profesionalizantes I', 1),
('Inglés II', 2),
('Análisis Matemático II', 2),
('Estadística', 2),
('Ingeniería de Software I', 2),
('Algoritmos y estructuras de datos II', 2),
('Sistemas Operativos', 2),
('Base de Datos', 2),
('Prácticas Profesionalizantes II', 2),
('Inglés III', 3),
('Aspectos legales de la profesión', 3),
('Seminario de actualización', 3),
('Redes y comunicaciones', 3),
('Ingeniería de Software II', 3),
('Algoritmos y estructuras de datos III', 3),
('Prácticas Profesionalizantes III', 3);

select * from Asignatura;
/*Asignaturas para Publicidad (ID_Carrera = 1)*/
INSERT INTO AsignaturaXCarrera (Id_carrera,Id_asignatura) VALUES
(1, 2), -- Marketing general
(1, 2), -- Psicología Comportamiento del Consumidor
(1, 3), -- Fundamentos del diseño publicitario
(1, 4), -- Computación 1
(1, 5), -- Introducción a la publicidad
(1, 6), -- Producción gráfica
(1, 7), -- Producción radial
(1, 8), -- Producción audiovisual
(1, 9), -- Computación 2
( 1, 10), -- Inglés 1
( 1, 11), -- Psicología social
( 1, 12), -- Marketing directo
( 1, 13), -- Arte, cine, literatura e historia de la publicidad
( 1, 14), -- Redacción creativa 1
( 1, 15), -- Dirección de arte 1
( 1, 16), -- Planificación estratégica de medios
( 1, 17), -- Semiología publicitaria
( 1, 18); -- Técnica promocional y pop

-- Asignaturas para Analista de Sistemas (ID_Carrera = 2)
INSERT INTO AsignaturaXCarrera (Id_carrera, Id_asignatura) VALUES
(2, 27), -- Inglés I
(2, 28), -- Ciencia, Tecnología y Sociedad
(2, 29), -- Análisis Matemático I
(2, 30), -- Álgebra
(2, 31), -- Algoritmos y estructuras de datos I
(2, 32), -- Sistemas y Organizaciones
(2, 33), -- Arquitectura de Computadores
(2, 34), -- Prácticas Profesionalizantes I
(2, 35), -- Inglés II
(2, 36), -- Análisis Matemático II
(2, 37), -- Estadística
(2, 38), -- Ingeniería de Software I
(2, 39), -- Algoritmos y estructuras de datos II
(2, 40), -- Sistemas Operativos
(2, 41), -- Base de datos
(2, 42), -- Prácticas Profesionalizantes II
(2, 43), -- Inglés III
(2, 44), -- Aspectos legales de la profesión
(2, 45), -- Seminario de actualización
(2, 46), -- Redes y comunicaciones
(2, 47), -- Ingeniería de Software II
(2, 48), -- Algoritmos y estructuras de datos III
(2, 49); -- Prácticas Profesionalizantes III

INSERT INTO Perfiles (Tipo_perfil) VALUES
('Alumno'),
('Profesor'),
('Personal Administrativo'),
('Administrador');

INSERT INTO Alumnos (Nombre, Apellido, Dni, Direccion_calle, Direccion_num, Email, Telefono, F_nacimiento, Usuario, Contraseña, Id_perfil) VALUES
('Leo', 'Tolusso', '98765432', 'Calle 1', 123, 'leo_tolusso@ejemplo.com', '1234-5678', '2000-01-01', 'Leo', '12345', 1),
('Pedro', 'Rodríguez', '87654321', 'Calle 2', 456, 'pedro.rodriguez@ejemplo.com', '2345-6789', '1999-02-02', 'alumno2', 'password123', 1),
('Ana', 'Gómez', '45678901', 'Calle 3', 789, 'ana.gomez@ejemplo.com', '3456-7890', '2001-03-03', 'alumno3', 'password123', 1),
('Javier', 'Sánchez', '65432109', 'Calle 4', 321, 'javier.sanchez@ejemplo.com', '4567-8901', '1998-04-04', 'alumno4', 'password123', 1),
('María', 'Fernández', '12345678', 'Calle 5', 654, 'maria.fernandez@ejemplo.com', '5678-9012', '1997-05-05', 'alumno5', 'password123', 1),
('Luis', 'Pérez', '98765432', 'Calle 6', 159, 'luis.perez@ejemplo.com', '6789-0123', '1996-06-06', 'alumno6', 'password123', 1),
('Sofía', 'Cruz', '87654321', 'Calle 7', 753, 'sofia.cruz@ejemplo.com', '7890-1234', '2002-07-07', 'alumno7', 'password123', 1),
('Carlos', 'Hernández', '65432109', 'Calle 8', 258, 'carlos.hernandez@ejemplo.com', '8901-2345', '1995-08-08', 'alumno8', 'password123', 1),
('Isabella', 'García', '12345678', 'Calle 9', 369, 'isabella.garcia@ejemplo.com', '9012-3456', '1994-09-09', 'alumno9', 'password123', 1),
( 'Andrés', 'Torres', '78901234', 'Calle 10', 951, 'andres.torres@ejemplo.com', '0123-4567', '1993-10-10', 'alumno10', 'password123', 1);

INSERT INTO AsignaturasXAlumnos(Id_alumno, Id_asignatura) VALUES
(1, 2), -- Laura está en Marketing general
(1, 2), -- Laura está en Psicología Comportamiento del Consumidor
(1, 3), -- Laura está en Fundamentos del diseño publicitario
(1, 4), -- Laura está en Computación 1
(1, 5), -- Laura está en Introducción a la publicidad
(2, 6), -- Pedro está en Producción gráfica
(2, 2), -- Pedro está en Marketing general
(2, 7), -- Pedro está en Producción radial
(1, 8), -- Laura está en Producción audiovisual
( 2, 9); -- Pedro está en Computación 2

INSERT INTO Instancias (Descripcion) VALUES
('Parcial'),
('Recuperatorio'),
('Final');

INSERT INTO Examenes (Nota, Fecha, Id_asignatura, Id_alumno, Id_instancia, Id_empleado) VALUES
(8.5, '2024-05-01', 2, 4, 1, 2), -- Laura en Marketing general (Parcial)
(7.0, '2024-05-02', 2, 5, 1, 2), -- Laura en Psicología Comportamiento del Consumidor (Parcial)
(9.0, '2024-05-03', 3, 2, 1, 2), -- Pedro en Fundamentos del diseño publicitario (Parcial)
(6.5, '2024-05-01', 4, 2, 1, 2), -- Pedro en Computación 1 (Parcial)
(8.0, '2024-06-01', 2, 6, 2, 2), -- Laura en Marketing general (Recuperatorio)
(5.5, '2024-06-02', 5, 2, 2, 2), -- Pedro en Introducción a la publicidad (Recuperatorio)
(9.5, '2024-07-01', 6, 7, 3, 2), -- Laura en Producción gráfica (Final)
(8.0, '2024-07-02', 7, 2, 3, 2), -- Pedro en Producción radial (Final)
(10.0, '2024-07-03', 8, 9,3, 2), -- Laura en Producción audiovisual (Final)
(7.5, '2024-07-01', 9, 2, 3, 2); -- Pedro en Computación 2 (Final)

select * from Alumnos

INSERT INTO Empleados (Nombre, Apellido, Dni, Direccion_calle, Direccion_num, Email, Telefono, F_nacimiento, Usuario, Contraseña, Id_perfil) VALUES
('Juan', 'Pérez', '12345678', 'Calle Falsa', 123, 'juan.perez@ejemplo.com', '1111-2222', '1980-05-10', 'profesor1', 'password123', 2),
('María', 'Gómez', '87654321', 'Av. Siempreviva', 456, 'maria.gomez@ejemplo.com', '2222-3333', '1975-07-22', 'profesor2', 'password123', 2),
('Carlos', 'López', '11223344', 'Av. Libertador', 789, 'carlos.lopez@ejemplo.com', '3333-4444', '1985-09-15', 'admin1', 'adminpass', 3),
('Ana', 'Martínez', '22334455', 'Calle Nueva', 321, 'ana.martinez@ejemplo.com', '4444-5555', '1982-11-30', 'profesor3', 'password123', 2),
('Luis', 'Ramírez', '33445566', 'Calle Vieja', 654, 'luis.ramirez@ejemplo.com', '5555-6666', '1990-01-01', 'admin2', 'adminpass', 3),
('Sofía', 'Cruz', '44556677', 'Calle 12', 159, 'sofia.cruz@ejemplo.com', '6666-7777', '1988-03-15', 'profesor4', 'password123', 2),
('Pedro', 'Fernández', '55667788', 'Calle 34', 753, 'pedro.fernandez@ejemplo.com', '7777-8888', '1995-04-20', 'profesor5', 'password123', 2),
('Isabella', 'Cano', '66778899', 'Calle 56', 258, 'isabella.cano@ejemplo.com', '8888-9999', '1983-05-10', 'admin3', 'adminpass', 3),
('Andrés', 'Torres', '77889900', 'Calle 78', 369, 'andres.torres@ejemplo.com', '9999-0000', '1992-06-30', 'profesor6', 'password123', 2),
( 'Laura', 'Molina', '88990011', 'Calle 90', 951, 'laura.molina@ejemplo.com', '0000-1111', '1990-07-15', 'admin4', 'adminpass', 3);

/*Ver bien que permisos tiene cada uno:*/
INSERT INTO Permisos (Tipo_permiso) VALUES
('Gestionar Alumnos'),
('Gestionar Asignaturas'),
('Gestionar Notas'),
('Gestionar Exámenes'),
('Gestionar Usuarios');

INSERT INTO PermisosXPerfil (Id_permisos, Id_perfil) VALUES
(1, 2), -- Profesor puede gestionar alumnos
(2, 2), -- Profesor puede gestionar asignaturas
(3, 2), -- Profesor puede gestionar notas
(4, 2), -- Profesor puede gestionar exámenes
(5, 4), -- Administrador puede gestionar usuarios
(1, 4), -- Administrador puede gestionar alumnos
(2, 4), -- Administrador puede gestionar asignaturas
(3, 4), -- Administrador puede gestionar notas
(4, 4); -- Administrador puede gestionar exámenes

select * from Perfiles


--------------Procedimientos Almacenados----------------------------

create procedure sp_Estado
as
begin
	select
		(select 
			COUNT (Id_alumno)
		from
			Alumnos) as TotalAlumnos, (select
											COUNT (Id_empleado)
										from
											Empleados
										where
											Id_perfil = 2) as TotalProfesores, (select
																						COUNT (Id_empleado)
																					from
																						Empleados
																					where
																						Id_perfil = 3) as TotalAdministrativos, (select
																																		COUNT (Id_asignatura)
																																	from
																																		Asignatura) as TotalMaterias;																													
end;
---------------------------------
create procedure sp_Acceso_Login
@Usuario varchar(40),
@Contraseña varchar(40)
as
begin
    SELECT 
		P.Tipo_perfil 
    FROM 
		Perfiles P 
    JOIN 
		Alumnos A ON P.Id_perfil = A.Id_perfil 
    WHERE 
		A.Usuario = @Usuario AND A.Contraseña = @Contraseña
    UNION
    SELECT 
		P.Tipo_perfil 
    FROM 
		Perfiles P 
    JOIN 
		Empleados E ON P.Id_perfil = E.Id_perfil 
    WHERE 
		E.Usuario = @Usuario AND E.Contraseña = @Contraseña
end;


---------------------------------------

create procedure sp_Dash_Examenes
as
begin
	select TOP 3
		*
	from
		Examenes
	order by
		Fecha
	desc
end;

--------------------------------------
create procedure sp_Dash_Alumnos
as
begin
	select TOP 3
		*
	from
		Alumnos
	order by
		Id_alumno
	desc
end;

----------------------------------------
create procedure sp_Dash_Profesores
as
begin
	select TOP 3
	* from Empleados
	where Id_perfil = 2
	order by 
		Id_empleado
	desc
end;

-------------------------------------------

create procedure sp_Dash_Asignaturas
as
begin
	select TOP 3
	* from Asignatura
	order by 
		Id_asignatura
	desc
end;

-------------------------------------------
create procedure sp_Dash_Administrativos
as
begin
	select TOP 3
	* from Empleados
	where Id_perfil = 3
	order by 
		Id_empleado
	desc
end;
--------------------------------------------
create procedure sp_Dash_Carreras
as
begin
	select TOP 3
	* from Carreras
	order by 
		Id_carrera
	desc
end;
---------------------------------------------


CREATE PROCEDURE sp_AgregarProfesor
@Nombre varchar(40),
@Apellido varchar(40),
@Dni varchar(20),
@Direccion_calle varchar(50),
@Direccion_num int,
@Email varchar(100),
@Telefono varchar(30),
@F_nacimiento date,
@Usuario varchar(40),
@Contraseña varchar(40)
AS
BEGIN
    -- El Id_perfil será siempre 2 para los profesores
    DECLARE @Id_perfil INT = 2;

    -- Insertar el nuevo profesor
    INSERT INTO Empleados(Nombre, Apellido, Dni, Direccion_calle, Direccion_num, Email, Telefono, F_nacimiento, Usuario, Contraseña, Id_perfil)
    VALUES(@Nombre, @Apellido, @Dni, @Direccion_calle, @Direccion_num, @Email, @Telefono, @F_nacimiento, @Usuario, @Contraseña, @Id_perfil);

   
END;




-------------------------------------------------------------------
CREATE PROCEDURE sp_ModificarProfesor
    @Id_empleado INT,          -- ID del profesor que queremos modificar
    @Nombre VARCHAR(40),
    @Apellido VARCHAR(40),
    @Dni VARCHAR(20),
    @Direccion_calle VARCHAR(50),
    @Direccion_num INT,
    @Email VARCHAR(100),
    @Telefono VARCHAR(30),
    @F_nacimiento DATE,
    @Usuario VARCHAR(40),
    @Contraseña VARCHAR(40)
AS
BEGIN
    -- El Id_perfil será siempre 2 para los profesores
    DECLARE @Id_perfil INT = 2;

    -- Verificamos si el profesor existe en la tabla Empleados y pertenece al perfil 2 (profesor)
    IF NOT EXISTS (
        SELECT 1
        FROM Empleados
        WHERE Id_empleado = @Id_empleado AND Id_perfil = @Id_perfil
    )
    BEGIN
        RAISERROR('El ID proporcionado no corresponde a un profesor existente.', 16, 1);
        RETURN;  -- Terminamos la ejecución del procedimiento si no es válido
    END

    -- Si el profesor existe, realizamos la actualización
    UPDATE Empleados
    SET 
        Nombre = @Nombre,
        Apellido = @Apellido,
        Dni = @Dni,
        Direccion_calle = @Direccion_calle,
        Direccion_num = @Direccion_num,
        Email = @Email,
        Telefono = @Telefono,
        F_nacimiento = @F_nacimiento,
        Usuario = @Usuario,
        Contraseña = @Contraseña,
        Id_perfil = @Id_perfil  -- Aseguramos que el perfil sigue siendo profesor (2)
    WHERE Id_empleado = @Id_empleado;

    PRINT 'Profesor modificado exitosamente.';  -- Mensaje de éxito
END;

------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_EliminarProfesor
    @Id_empleado INT  -- ID del profesor que queremos eliminar
AS
BEGIN
    -- Verificamos si el ID de empleado corresponde a un profesor (Id_perfil = 2)
    IF NOT EXISTS (
        SELECT 1
        FROM Empleados
        WHERE Id_empleado = @Id_empleado AND Id_perfil = 2
    )
    BEGIN
        RAISERROR('El ID proporcionado no corresponde a un profesor existente.', 16, 1);
        RETURN;  -- Terminamos la ejecución del procedimiento si no es válido
    END

    -- Si el profesor existe, realizamos la eliminación
    DELETE FROM Empleados
    WHERE Id_empleado = @Id_empleado AND Id_perfil = 2;

    PRINT 'Profesor eliminado exitosamente.';  -- Mensaje de éxito
END;
SELECT 1
        FROM Empleados
        WHERE Id_empleado = 1 AND Id_perfil = 2 AND Id_perfil IN (
            SELECT Id_perfil FROM Perfiles WHERE Tipo_perfil = 'Profesor');
-------------------------------------------------------------------------------
--PROCEDIMIENTO PARA AGREGAR ALUMNO
CREATE PROCEDURE sp_AgregarAlumno
@Id_perfil INT,
@Nombre NVARCHAR(50),
@Apellido NVARCHAR(50),
@DNI NVARCHAR(20),
@F_nacimiento DATE,
@Direccion NVARCHAR(100),
@Altura INT,
@Email NVARCHAR(50),
@Telefono NVARCHAR(20),
@Usuario NVARCHAR(50),
@Contraseña NVARCHAR(50)
AS
BEGIN
	IF not exists (
		SELECT 1
		FROM Perfiles
		WHERE Id_perfil = @Id_perfil and Tipo_perfil = 'Alumno')
		BEGIN
			RAISERROR ('El Id de perfil no corresponde a un alumno', 16,1);
			RETURN;
		END
		
		INSERT INTO Alumnos ( Nombre, Apellido, DNI, F_nacimiento, Direccion_calle, Direccion_num, Email, Telefono, Usuario, Contraseña, Id_perfil)
		VALUES (@Nombre, @Apellido, @DNI, @F_nacimiento, @Direccion, @Altura, @Email, @Telefono, @Usuario, @Contraseña, @Id_perfil);
END;

--PROCEDIMIENTO PARA MODIFICAR ALUMNO
CREATE PROCEDURE sp_ModificarAlumno
    @Id_alumno INT,
    @Nombre VARCHAR(40),
    @Apellido VARCHAR(40),
    @Dni VARCHAR(20),
    @Direccion VARCHAR(50),
    @Altura INT,
    @Email VARCHAR(100),
    @Telefono VARCHAR(30),
    @F_nacimiento DATE,
    @Usuario VARCHAR(40),
    @Contraseña VARCHAR(40),
    @Id_perfil INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Alumnos
        WHERE Id_alumno = @Id_alumno AND Id_perfil = @Id_perfil
    )
    BEGIN
        RAISERROR('El alumno no existe.', 16, 1);
        RETURN; 
    END

  
    UPDATE Alumnos
    SET 
        Nombre = @Nombre,Apellido = @Apellido, Dni = @Dni, Direccion_calle = 
		@Direccion,Direccion_num = @Altura,Email = @Email,Telefono = @Telefono, 
		F_nacimiento = @F_nacimiento,Usuario = @Usuario,Contraseña = @Contraseña, Id_perfil = @Id_perfil  
    WHERE Id_alumno = @Id_alumno;  
END;

---------------------------------------------------------------------------------------------------
--PROCEDIMIENTO PARA ELIMINAR UN ALUMNO
CREATE PROCEDURE sp_EliminarAlumno
    @Id_alumno INT, 
	@Id_perfil INT  
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Alumnos
        WHERE Id_alumno = @Id_alumno AND Id_perfil = @Id_perfil)
    BEGIN
        RAISERROR('El alumno no existe.', 16, 1);
        RETURN;
    END

    DELETE FROM Alumnos
    WHERE Id_alumno = @Id_alumno;
END;
drop procedure sp_EliminarAlumno

use TPFinal


---------------------------------------------------------------------------

create procedure sp_Agregar_Administrativo
@Nombre varchar(40),
@Apellido varchar(40),
@Dni varchar(20),
@Direccion_calle varchar(50),
@Direccion_num int,
@Email varchar(100),
@Telefono varchar(30),
@F_nacimiento date,
@Usuario varchar(40),
@Contraseña varchar(40)
as
begin 
	insert into Empleados (
		Nombre, Apellido, Dni, Direccion_calle, Direccion_num, Email, Telefono, F_nacimiento, Usuario, Contraseña, Id_perfil)
	values
		(@Nombre, @Apellido, @Dni, @Direccion_calle, @Direccion_num, @Email, @Telefono, @F_nacimiento, @Usuario, @Contraseña, 3)
end;

exec sp_Agregar_Administrativo @Nombre = 'Martin', @Apellido = 'M', @Dni = '1111111', @Direccion_calle = 'balcarce', @Direccion_num = 1111, @Email = 'hola@hotmail.com', @Telefono = '444444', @F_nacimiento = '2024-01-01', @Usuario = 'martin', @Contraseña = '12345';


--------------------------------------------------------------------------------------
create procedure sp_Modificar_Administrativo
@Nombre varchar(40),
@Apellido varchar(40),
@Dni varchar(20),
@Direccion_calle varchar(50),
@Direccion_num int,
@Email varchar(100),
@Telefono varchar(30),
@F_nacimiento date,
@Usuario varchar(40),
@Contraseña varchar(40)
as
begin
	update Empleados
	set
		Nombre = @Nombre, 
		Apellido = @Apellido, 
		Dni = @Dni, 
		Direccion_calle = @Direccion_calle, 
		Direccion_num = @Direccion_num, 
		Email = @Email, 
		Telefono = @Telefono, 
		F_nacimiento = @F_nacimiento, 
		Usuario = @Usuario, 
		Contraseña = @Contraseña,
		Id_perfil = 3;
end;

--------------------------------------------------------------------------------------
use TPFinal
create procedure sp_eliminar_Administrativo
@Id_empleado int
as
begin
	delete from 
		empleados 
	where 
		Id_empleado = @Id_empleado
end;

create procedure sp_Cargar_Tabla_Administrativos
as
begin
	select
		*
	from
		Empleados
	where
		Id_perfil = 3
end;

exec sp_Cargar_Tabla_Administrativos;