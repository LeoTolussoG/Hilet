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
@Contraseņa varchar(40)
as
begin 
	insert into Empleados (
		Nombre, Apellido, Dni, Direccion_calle, Direccion_num, Email, Telefono, F_nacimiento, Usuario, Contraseņa, Id_perfil)
	values
		(@Nombre, @Apellido, @Dni, @Direccion_calle, @Direccion_num, @Email, @Telefono, @F_nacimiento, @Usuario, @Contraseņa, 3)
end;

--------------------------------------------------------------------------------------

drop procedure sp_Modificar_Administrativo

create procedure sp_Modificar_Administrativo
@Id_empleado int,
@Nombre varchar(40),
@Apellido varchar(40),
@Dni varchar(20),
@Direccion_calle varchar(50),
@Direccion_num int,
@Email varchar(100),
@Telefono varchar(30),
@F_nacimiento date,
@Usuario varchar(40),
@Contraseņa varchar(40)
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
		Contraseņa = @Contraseņa,
		Id_perfil = 3
	where
		Id_empleado = @Id_empleado
end;

--------------------------------------------------------------------------------------

create procedure sp_eliminar_Administrativo
@Id_empleado int
as
begin
	delete from 
		empleados 
	where 
		Id_empleado = @Id_empleado
end;
---------------------------------------------------------------------------------------
create procedure sp_Cargar_Tabla_Administrativos
as
begin
	select
		Id_empleado as Nro_personal, 
		Nombre, 
		Apellido, 
		Dni, 
		Direccion_calle as domicilio, 
		Direccion_num as Altura, 
		Email, 
		Telefono, 
		F_nacimiento, 
		Usuario as Nombre_usuario,
		Contraseņa
	from
		Empleados
	where
		Id_perfil = 3
end;

drop procedure sp_Cargar_Tabla_Administrativos

use TPFinal