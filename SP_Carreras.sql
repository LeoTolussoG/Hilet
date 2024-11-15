use TPFinal;
use u26;
create procedure sp_Cargar_Tabla_Carreras
as
begin
	select
		*
	from
		Carreras
end;

------------------------------------------------------------------

create procedure sp_Agregar_Carrera
@Nombre varchar(50),
@Num_res varchar(30),
@Año_Plan_Estudio int
as
begin
	insert into
		Carreras
	values
		(@Nombre, @Num_res, @Año_Plan_Estudio)
end;

------------------------------------------------------------------------------

create procedure sp_Modificar_Carrera
@Id_carrera int,
@Nombre varchar(50),
@Num_res varchar(30),
@Año_Plan_Estudio int
as
begin
	update 
		Carreras
	set
		Nombre = @Nombre, Num_res = @Num_res, Año_PlanEstudio = @Año_Plan_Estudio
	where
		Id_carrera = @Id_carrera
end;

----------------------------------------------------------------------------------------------------

create procedure sp_Eliminar_Carrera
@Id_carrera int
as
begin
	delete from
		Carreras
	where
		Id_carrera = @Id_carrera
end;