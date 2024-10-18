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

-----------------------------------------------------------------------------------------------------------------------------------------------

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

------------------------------------------------------------------------------------------------------------------------------------------

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

-----------------------------------------------------------------------------------------------------------------------------------------

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

----------------------------------------------------------------------------------------------------------------------------------------

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

---------------------------------------------------------------------------------------------------------------------------------------

create procedure sp_Dash_Asignaturas
as
begin
	select TOP 3
	* from Asignatura
	order by 
		Id_asignatura
	desc
end;

---------------------------------------------------------------------------------------------------------------------------------------

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

----------------------------------------------------------------------------------------------------------------------------------------

create procedure sp_Dash_Carreras
as
begin
	select TOP 3
	* from Carreras
	order by 
		Id_carrera
	desc
end;