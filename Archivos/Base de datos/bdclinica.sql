
create database CLINICA_finall
use CLINICA_finall


CREATE TABLE usuario(
IdUsuario int primary key identity(1,1),
electronico varchar(100),
clave varchar(100)
)

CREATE TABLE citas(
Idcitas int identity primary key,
nombre varchar(100),
telefono varchar(100),
correo varchar(100),
fecha varchar(100),
hora varchar(100),
comentario varchar(100)
)
--------------------------------------------
CREATE TABLE inventario(
   Idinventario   int identity primary key, 
  descripcion   VARCHAR(100),
  unitario  VARCHAR(100),
  ingreso varchar(100),
  precio  VARCHAR(100), 
  codigo     VARCHAR(100), 
  cantidad  VARCHAR(100) 
)
------------------------------------------------
CREATE TABLE  ficha(
   Idficha   int identity primary key, 
  nombreficha   VARCHAR(100),
  apellido VARCHAR(100),
  nacimiento VARCHAR(100),
  edad VARCHAR(100),
  dpi VARCHAR(100),
  direccion VARCHAR(100),
  genero VARCHAR(100),
  doctora  VARCHAR(100),
  tratamiento  VARCHAR(100), 
)

--select * from ficha

--set identity_insert ficha on
--insert into ficha(Idficha,nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento)values('1','Maria','Mercedez','1998-09-2','24','21995234560101','zona 4','femenino','oncologia','extraccion molar')
--insert into ficha(Idficha,nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento)values('2','Marcia','Moran','2000-02-4','24','1368234190101','zona 12','femenino','endodoncia','relleno')
--insert into ficha(Idficha,nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento)values('3','Miguel','Duarte','2005-06-8','24','8782185430101','zona 8','masculinoo','ortodoncia','revicion de retenedor')
--insert into ficha(Idficha,nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento)values('4','Esdras','Reinoso','2005-06-8','22','8782185430101','zona 8','masculinoo','cirugia','maatrar el nervo')
--insert into ficha(Idficha,nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento)values('5','Jonas','Rosales','2005-06-8','21','8782185430101','zona 8','masculinoo','cirugia','tratamiento canales')
--insert into ficha(Idficha,nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento)values('6','Pablo','Ramos','2005-06-8','23','8782185430101','zona 8','masculinoo','endodncia','carias')
--------------------------------------usuario----------------------------------
create proc sp_RegistrarUsuario(
@electronico varchar(100),
@clave varchar(100),
@registrado bit output,
@mensaje varchar(100) output
)
as 
begin
   
       if (not exists(select *from usuario where electronico = @electronico))
      begin 
      insert into usuario(electronico,clave) values (@electronico, @clave)
      set @registrado = 1
      set @mensaje = 'usuario registrado'
   end
   else 
   begin 
       set @registrado = 0
	   set @mensaje ='correo ya existe'
    end

end

-------------------------------------
create proc sp_validarUsuario(
@electronico varchar(100),
@clave varchar(100)
)
as 
begin 
   if(exists(select * from usuario where electronico = @electronico and clave = @clave))
       select IdUsuario from usuario where electronico = @electronico and clave = @clave
   else
       select '0'
end

-------------------------------------------------

declare @registrado bit, @mensaje varchar(100)

exec sp_RegistrarUsuario 'usuario@gmail.com','9250e222c4c71f0c58d4c54b50a880a312e9f9fed55d5c3aa0b0e860ded99165', @registrado output, @mensaje output 
 
 select @registrado
 select @mensaje

-------------------------------------------------------------

exec sp_validarUsuario 'usuario@gmail.com','9250e222c4c71f0c58d4c54b50a880a312e9f9fed55d5c3aa0b0e860ded99165'




-----------------------------------citas------------------------------------------------

create procedure sp_listar
as
begin
     select * from citas
end

----------------------------------------

create procedure sp_obtener(
@Idcitas int
)
as
begin 
    select * from citas where Idcitas = @Idcitas
end


----------------------------

create procedure sp_guardar(
@nombre varchar(100),
@telefono varchar(100),
@correo varchar(100),
@fecha varchar(100),
@hora varchar(100),
@comentario varchar(100)
)
as 
 begin 
     insert into citas (nombre,telefono,correo,fecha,hora,comentario) values (@nombre,@telefono,@correo,@fecha,@hora,@comentario)
	 end

---------------------------

create procedure sp_editar(
@Idcitas int,
@nombre varchar(100),
@telefono varchar(100),
@correo varchar(100),
@fecha varchar(100),
@hora varchar(100),
@comentario varchar(100)
)
as
  begin 
      update citas set nombre = @nombre, telefono = @telefono, correo = @correo, fecha = @fecha,hora =@hora,comentario = @comentario where Idcitas = @Idcitas
end

------------------------

create procedure sp_eliminar(
@Idcitas int
)
as
begin
    delete from citas where Idcitas = @Idcitas
end


---------------------------------------------------inventario -----------------------------------------

create procedure sp_listarinventario
as
begin
     select * from inventario
end

--------------------------------


create procedure sp_obtenerinventario(
@Idinventario int
)
as
begin 
    select * from inventario where Idinventario = @Idinventario
end


--------------------------------------------
create procedure sp_guardarinventario(
@descripcion varchar(100),
@unitario varchar(100),
@ingreso varchar(100),
@precio varchar(100),
@codigo varchar(100),
@cantidad varchar(100)
)
as 
 begin 
     insert into inventario(descripcion,unitario,ingreso,precio,codigo,cantidad) values (@descripcion,@unitario,@ingreso,@precio,@codigo,@cantidad)
	 end

------------------------------------------

create procedure sp_editarinventario(
@Idinventario int,
@descripcion varchar(100),
@unitario varchar(100),
@ingreso varchar(100),
@precio varchar(100),
@codigo varchar(100),
@cantidad varchar(100)
)
as
  begin 
      update inventario set descripcion = @descripcion, unitario = @unitario, ingreso = @ingreso,precio = @precio, codigo = @codigo, cantidad = @cantidad where Idinventario = @Idinventario
end
------------------------------------------------
create procedure sp_eliminarinventario(
@Idinventario int
)
as
begin
    delete from inventario where Idinventario = @Idinventario
end

-----------------------------------------------------ficha-----------------------------

create procedure sp_listarficha
as
begin
     select * from ficha
end

-------------------------------

create procedure sp_obtenerficha(
@Idficha int
)
as
begin 
    select * from ficha where Idficha = @Idficha
end

-------------------------------------------------
create procedure sp_guardarficha(
@nombreficha varchar(100),
@apellido varchar(100),
@nacimiento varchar(100),
@edad varchar(100),
@dpi varchar(100),
@direccion varchar(100),
@genero VARCHAR(100),
@doctora  VARCHAR(100),
@tratamiento  VARCHAR(100)
)
as 
 begin 
     insert into ficha(nombreficha,apellido,nacimiento,edad,dpi,direccion,genero,doctora,tratamiento) values (@nombreficha,@apellido,@nacimiento,@edad,@dpi,@direccion,@genero,@doctora,@tratamiento)
	 end

---------------------------------------------------------------
create procedure sp_editarficha(
@Idficha int,
@nombreficha varchar(100),
@apellido varchar(100),
@nacimiento varchar(100),
@edad varchar(100),
@dpi varchar(100),
@direccion varchar(100),
@genero VARCHAR(100),
@doctora  VARCHAR(100),
@tratamiento  VARCHAR(100)
)
as
  begin 
      update ficha set nombreficha = @nombreficha, apellido = @apellido, nacimiento = @nacimiento, edad = @edad, dpi =@dpi, direccion=@direccion,genero = @genero,doctora =@doctora,tratamiento=@tratamiento where Idficha = @Idficha
end

-----------------------------------------------------------------

create procedure sp_eliminarficha(
@Idficha int
)
as
begin
    delete from ficha where Idficha = @Idficha
end

-----------------------------
