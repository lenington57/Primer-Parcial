CREATE DATABASE PrimerParcialDb
go

CREATE TABLE Grupos
(
	GrupoID int primary key identity(1,1),
	Fecha datetime,
	Descripcion varchar(40),
	Cantidad float,
	GrupoCant float,
	Integrantes float
);

CREATE TABLE Personas
(
	ID int primary key identity(1,1),
	Fecha datetime,
	Nombre varchar(40),
	Direccion varchar(30),
	Cedula varchar(13),
	Telefono varchar(12)
);
go
select * from Grupos

select * from Personas


