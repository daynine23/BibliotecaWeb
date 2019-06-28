USE master
GO
---Creacion de la base de datos y los archivos .mdf y .log
CREATE DATABASE Biblioteca2
on primary
(
name='Biblioteca2_Dat',
filename='C:\Proyecto_BD_APP1\Biblioteca2.mdf',
size=10MB,
maxsize=20MB,
filegrowth=20%
)
log on
(
name='Biblioteca2_Log',
filename='C:\Proyecto_BD_APP1\Biblioteca2.ldf',
size=20MB,
maxsize=30MB,
filegrowth=1MB
)

---Creacion de Tablas
USE Biblioteca2
go

CREATE TABLE LIBRO (
        IdLibro    char(3) PRIMARY KEY NOT NULL,
		IdAutor				char(3) ,
		IdCategoria			char(3) ,
		IdEditorial			char(3) ,
		IdIdioma			char(3) ,
        Titulo          varchar (30) NOT NULL,
        Año_Lanz          char(4) NOT NULL,
         )
go

CREATE TABLE IDIOMA(
		IdIdioma			char(3) PRIMARY KEY NOT NULL,
		Nombre_Idioma       varchar(50) NOT NULL,

)
GO

CREATE TABLE AUTOR (
        IdAutor               char(3) PRIMARY KEY NOT NULL,
        NomApe_Autor          varchar (40) NOT NULL,
         )
go


CREATE TABLE CATEGORIA (
        IdCategoria               char(3) PRIMARY KEY NOT NULL,
        Nombre_Categoria          varchar (30) NOT NULL,
         )
go

CREATE TABLE EDITORIAL (
        IdEditorial               char(3) PRIMARY KEY NOT NULL,
        Nombre_Editorial          varchar (30) NOT NULL,
		Dir_Editorial		 varchar(50) NOT NULL UNIQUE,
		Email_Editorial			varchar(50) NOT NULL UNIQUE,
         )
go

CREATE TABLE EJEMPLAR (
        IdEjemplar               char(3) PRIMARY KEY NOT NULL,
		IdLibro					char(3) NOT NULL,
		Estado				varchar (15) NOT NULL, 
         )
go

CREATE TABLE DETALLE_PRESTAMO (
        IdPrestamo             char(3) NOT NULL,
		IdEjemplar			   char(3) NOT NULL,
         )
go

CREATE TABLE PRESTAMO (
        IdPrestamo               char(3) PRIMARY KEY NOT NULL,
		IdLector					char(3) NOT NULL,
		Fecha_Prestamo			date NOT NULL,
        Fecha_Devolucion         date NOT NULL,
		Comentario				varchar(200) NOT NULL,
         )
go

CREATE TABLE LECTOR (
        IdLector					char(3) PRIMARY KEY NOT NULL,
		Nombre_Lector				varchar (30) NOT NULL,
		Ape_Paterno					varchar (30) NOT NULL,
		Ape_Materno					varchar (30) NOT NULL,
        Telefono					varchar (9) NOT NULL,
		Direccion_Lector			varchar (50) NOT NULL UNIQUE,
		Dni							varchar(8) NOT NULL UNIQUE,		
		Email_Lector				varchar(50) NOT NULL UNIQUE,
		IdDistrito					char(3) NOT NULL,
         )
go

CREATE TABLE DISTRITO (
		IdDistrito			char(3) PRIMARY KEY NOT NULL,
		Nombre_Distrito   varchar (50) NOT NULL,

)
GO

---Añadiendo Claves Foraneas
ALTER TABLE LIBRO
	ADD FOREIGN KEY (IdAutor)
	REFERENCES AUTOR
go
 
ALTER TABLE LIBRO
        ADD FOREIGN KEY (IdCategoria)
	REFERENCES CATEGORIA
go

ALTER TABLE LIBRO
        ADD FOREIGN KEY (IdEditorial)
	REFERENCES EDITORIAL
go

ALTER TABLE LIBRO
        ADD FOREIGN KEY (IdIdioma)
	REFERENCES IDIOMA
go

ALTER TABLE EJEMPLAR
        ADD FOREIGN KEY (IdLibro)
	REFERENCES LIBRO
go


ALTER TABLE DETALLE_PRESTAMO
        ADD FOREIGN KEY (IdPrestamo)
	REFERENCES PRESTAMO
go

ALTER TABLE DETALLE_PRESTAMO
        ADD FOREIGN KEY (IdEjemplar)
	REFERENCES EJEMPLAR
go

ALTER TABLE PRESTAMO
        ADD FOREIGN KEY (IdLector)
	REFERENCES LECTOR
go

ALTER TABLE LECTOR
        ADD FOREIGN KEY (IdDistrito)
	REFERENCES DISTRITO
go


---Insertar registros a la tabla IDIOMA

INSERT INTO IDIOMA (IdIdioma,Nombre_Idioma)
VALUES('I01','Español')
INSERT INTO IDIOMA (IdIdioma,Nombre_Idioma)
VALUES('I02','Ingles')

---Insertar registros a la tabla Autor

INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A01','Robert, Cecil Martin')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A02','Mario, Vargas Llosa')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A03','Gabriel, García Márquez')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A04','Oscar, Wilde')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A05','Federico, García Lorca')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A06','Pablo, Neruda')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A07','Paulo, Coelho')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A08','Isabel, Allende')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A09','Ernest, Hemingway')
INSERT INTO Autor (IdAutor,NomApe_Autor)
VALUES('A10','Joanne, Rowling')

SELECT * FROM AUTOR
GO

---Insertar registros a la tabla CATEGORIA
INSERT INTO CATEGORIA(IdCategoria,Nombre_Categoria)
VALUES('C01','Computacion e Informatica')
INSERT INTO CATEGORIA(IdCategoria,Nombre_Categoria)
VALUES('C02','Administracion')
INSERT INTO CATEGORIA(IdCategoria,Nombre_Categoria)
VALUES('C03','Literatura')
INSERT INTO CATEGORIA(IdCategoria,Nombre_Categoria)
VALUES('C04','Psicologia')
INSERT INTO CATEGORIA(IdCategoria,Nombre_Categoria)
VALUES('C05','Economia')

SELECT * FROM CATEGORIA
GO


---Insertar registros a la tabla EDITORIAL
INSERT INTO EDITORIAL(IdEditorial,Nombre_Editorial,Dir_Editorial,Email_Editorial)
VALUES('E01','Pearson Education, Inc','501 Boylston Street, Suite 900','international@pearsoned.com')
INSERT INTO EDITORIAL(IdEditorial,Nombre_Editorial,Dir_Editorial,Email_Editorial)
VALUES('E02','Alfaguara','Calle Manuel Gonzales Olaechea 247','ventas@alfaguara.com')
INSERT INTO EDITORIAL(IdEditorial,Nombre_Editorial,Dir_Editorial,Email_Editorial)
VALUES('E03','Santillana','Av. Andrés Aramburú 550','ventas@santillana.com')
INSERT INTO EDITORIAL(IdEditorial,Nombre_Editorial,Dir_Editorial,Email_Editorial)
VALUES('E04','Planeta',' Avenida Arequipa 3415','ventas@planeta.com')

SELECT * FROM EDITORIAL
GO


---Añadiendo regristro a la tabla LIBRO
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L01','A01','C01','E01','I02','Clean Code','2008')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L02','A02','C03','E02','I01','La ciudad y los perros','1962')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L03','A03','C03','E04','I01','Cien años de soledad','1967')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L04','A04','C03','E02','I01','El retrato de Dorian Gray','1890')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L05','A05','C03','E03','I02','The Tamarit Divan','1940')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L06','A04','C03','E04','I01','Canto General','1950')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L07','A04','C03','E01','I01','El Alquimista','1988')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L08','A04','C03','E02','I01','Paula','1994')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L09','A04','C03','E04','I02','El viejo y el mar','1952')
INSERT INTO LIBRO(IdLibro,IdAutor,IdCategoria,IdEditorial,IdIdioma,Titulo,Año_Lanz)
VALUES('L10','A04','C03','E01','I02','Harry Potter','1997')

Select * FROM LIBRO
GO



---Añadiendo regristro a la tabla EJEMPLAR
INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J01','L01','No Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J02','L02','No Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J03','L03','Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J04','L04','Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J05','L05','Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J06','L06','Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J07','L07','Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J08','L08','No Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J09','L09','No Disponible')

INSERT INTO EJEMPLAR(IdEjemplar,IdLibro,Estado)
VALUES('J10','L10','Disponible')

/*SELECT
       CASE WHEN Estado = 1 THEN 'disponible'
            ELSE 'no disponible' END AS estado
  FROM ejemplar*/

---Añadiendo regristro a la tabla DISTRITO
INSERT INTO DISTRITO(IdDistrito,Nombre_Distrito)
VALUES('D01','San Miguel')
INSERT INTO DISTRITO(IdDistrito,Nombre_Distrito)
VALUES('D02','San Isidro')
INSERT INTO DISTRITO(IdDistrito,Nombre_Distrito)
VALUES('D03','Miraflores')
INSERT INTO DISTRITO(IdDistrito,Nombre_Distrito)
VALUES('D04','San Borja')
INSERT INTO DISTRITO(IdDistrito,Nombre_Distrito)
VALUES('D05','Surco')
INSERT INTO DISTRITO(IdDistrito,Nombre_Distrito)
VALUES('D06','La Molina')

---Añadiendo regristro a la tabla LECTOR
INSERT INTO LECTOR (IdLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito)
VALUES('O01','Antonio','Valencia','Cespedez','71476839','Calle Los Geranios 103','2671128','antonio@gmail.com','D01')
INSERT INTO LECTOR (IdLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito)
VALUES('O02','Jorge','Espinoza','García','01456978','Av Miroquesada 145','1237896','jorgeEspi@gmail.com','D02')
INSERT INTO LECTOR (IdLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito)
VALUES('O03','Mario','Salcedo','Montesinos','45698732','Av. José Pardo 15074','4561237','marioSalcedo@gmail.com','D03')
INSERT INTO LECTOR (IdLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito)
VALUES('O04','Mariela','Casinelli','Ramos','78963254','Av San Borja Sur 278','4597412','mariela@hotmail.com','D04')
INSERT INTO LECTOR (IdLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito)
VALUES('O05','Fernada','Tello','Torres','96325874','Av. Benavides 4534','8523697','fernanda@hotmail.com','D05')
INSERT INTO LECTOR (IdLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito)
VALUES('O06','Raul','Mesa','Zegarra','45691234','Av. Los Ingenieros 753','2587413','raulMesa@hotmail.com','D06')

---Añadiendo regristro a la tabla PRESTAMO
INSERT INTO PRESTAMO(IdPrestamo,IdLector,Fecha_Prestamo,Fecha_Devolucion,Comentario)
VALUES('P01','O01','2017-10-04','2017-10-07','Tres dias habiles para devolverlo')
INSERT INTO PRESTAMO(IdPrestamo,IdLector,Fecha_Prestamo,Fecha_Devolucion,Comentario)
VALUES('P02','O02','2018-02-04','2018-02-07','Tres dias habiles para devolverlo')
INSERT INTO PRESTAMO(IdPrestamo,IdLector,Fecha_Prestamo,Fecha_Devolucion,Comentario)
VALUES('P03','O03','2018-05-01','2018-05-04','Tres dias habiles para devolverlo')
INSERT INTO PRESTAMO(IdPrestamo,IdLector,Fecha_Prestamo,Fecha_Devolucion,Comentario)
VALUES('P04','O04','2018-04-04','2018-04-07','Tres dias habiles para devolverlo')
INSERT INTO PRESTAMO(IdPrestamo,IdLector,Fecha_Prestamo,Fecha_Devolucion,Comentario)
VALUES('P05','O05','2018-03-08','2018-03-11','Tres dias habiles para devolverlo')
INSERT INTO PRESTAMO(IdPrestamo,IdLector,Fecha_Prestamo,Fecha_Devolucion,Comentario)
VALUES('P06','O06','2018-04-10','2018-04-13','Tres dias habiles para devolverlo')

---Añadiendo regristro a la tabla DETALLE_PRESTAMO
INSERT INTO DETALLE_PRESTAMO(IdEjemplar,IdPrestamo)
VALUES('J01','P01')


---CREACION DE PROCEDIMIENTOS ALMACENADOS

---LISTAR LIBROS
CREATE PROCEDURE usp_ListarLibro
AS
Select 
L.IdLibro AS CODIGO,
L.Titulo AS TITULO,
A.NomApe_Autor AS AUTOR,
C.Nombre_Categoria AS CATEGORIA, 
E.Nombre_Editorial AS EDITORIAL,
I.Nombre_Idioma AS IDIOMA,
L.Año_Lanz AS [AÑO LANZAMIENTO]
---(SELECT CASE WHEN Estado LIKE '1' THEN 'Disponible' ELSE 'No Disponible' END) AS ESTADO 
FROM  AUTOR A
INNER JOIN LIBRO L ON A.IdAutor = L.IdAutor
INNER JOIN CATEGORIA C ON L.IdCategoria = C.IdCategoria
INNER JOIN EDITORIAL E ON L.IdEditorial = E.IdEditorial
INNER JOIN IDIOMA I ON L.IdIdioma = I.IdIdioma
ORDER BY 1 ASC
GO

---LISTAR AUTOR
CREATE PROCEDURE usp_ListarAutor
AS 
Select IdAutor, NomApe_Autor from AUTOR
GO

Execute usp_ListarLibro


---LISTAR CATEGORIA
CREATE PROCEDURE usp_ListarCategoria
AS
Select IdCategoria, Nombre_Categoria
FROM CATEGORIA

---LISTAR EDITORIAL
CREATE PROCEDURE usp_ListarEditorial
AS 
Select IdEditorial, Nombre_Editorial
FROM EDITORIAL

---LISTAR IDIOMA
CREATE PROCEDURE usp_ListarIdioma
AS
Select IdIdioma, Nombre_Idioma
FROM IDIOMA




---INSERTAR LIBROS

CREATE PROCEDURE usp_InsertarLibro
@id_Aut char(3),
@id_Cat char(3),
@id_Edit char(3),
@id_Idi char(3),
@Tit varchar(30),
@año_lanz char(4)
AS
declare @id_Libro char(3)
declare @vcont int
set @vcont=(Select count(*) from LIBRO)
if @vcont=0 
       set @id_Libro ='L01'
else
        set @id_Libro=(Select 'L' +Right(Max (Right(IdLibro,2)+ 101 ),2) 
		  From LIBRO)
insert into LIBRO 
values(@id_Libro,@id_Aut,@id_Cat,@id_Edit,@id_Idi,@Tit,@año_lanz)
GO

/*(		
		@id_Aut int,
		@id_Cat int,
		@id_Edit int, 
		@id_Idi int,
		@Tit varchar (30),
		@año_lanz char(4)
		
)
AS
INSERT INTO LIBRO 
(		
		IdAutor,
		IdCategoria, 
		IdEditorial,
		IdIdioma,
		Titulo,
		Año_Lanz
)  
VALUES
(		@id_Aut,
		@id_Cat,
		@id_Edit, 
		@id_Idi,
		@Tit,
		@año_lanz
)*/


---ACTUALIZAR LIBROS

CREATE PROCEDURE usp_ActualizarLibro
@id_Libro char(3),
@id_Aut char(3),
@id_Cat char(3),
@id_Edit char(3),
@id_Idi char(3),
@Tit varchar (30),
@año_lanz char(4)

AS
Update LIBRO 
set IdAutor = @id_Aut,
    IdCategoria = @id_Cat,
	IdEditorial = @id_Edit,
	IdIdioma = @id_Idi,
	Titulo = @Tit,
	Año_Lanz = @año_lanz
where IdLibro=@id_Libro
GO

---ELIMINAR LIBRO

CREATE PROCEDURE usp_EliminarLibro
@id_Libro char(3)
AS
delete from LIBRO where IdLibro = @id_Libro
GO

---CONSULTAR LIBRO
/*
CREATE PROCEDURE usp_ConsultarLibro
@id_Libro char(3)
as
Select
IdLibro, 
Titulo,
NomApe_Autor,
Nombre_Categoria, 
Nombre_Editorial,
Nombre_Idioma,
Año_Lanz
FROM  LIBRO L
INNER JOIN AUTOR A ON L.IdAutor = A.IdAutor
INNER JOIN CATEGORIA C ON L.IdCategoria = C.IdCategoria
INNER JOIN EDITORIAL E ON L.IdEditorial = E.IdEditorial
INNER JOIN IDIOMA I ON L.IdIdioma = I.IdIdioma
where IdLibro=@id_Libro
GO*/
CREATE PROCEDURE usp_ConsultarLibro
@id_Libro char(3)
as
Select idlibro,titulo,idautor,idcategoria,ideditorial,IdIdioma,año_lanz
from libro
where idlibro=@id_libro
go


CREATE PROCEDURE usp_ListarLector
AS
Select 
L.IdLector AS CODIGO,
(L.Nombre_Lector + ' '+ L.Ape_Paterno + ' '+ L.Ape_Materno) AS Lector,
L.DNI AS DNI, 
L.Direccion_Lector AS DIRECCION,
L.Telefono AS TELEFONO,
L.Email_Lector AS EMAIL,
D.Nombre_Distrito AS DISTRITO
--
FROM  LECTOR L
INNER JOIN DISTRITO D ON L.IdDistrito = D.IdDistrito
ORDER BY 1 ASC
GO

EXECUTE usp_ListarLector

---INSERTAR LECTOR

CREATE PROCEDURE usp_InsertarLector
@nom_lec varchar (30),
@apePat_lec varchar (30),
@apeMat_lec varchar (30),
@dni_lec varchar (8),
@dir_lec varchar (50),
@tel_lec varchar (9),
@email_lec varchar(50),
@id_dis char(3)
AS
declare @id_Lector char(3)
declare @vcont int
set @vcont=(Select count(*) from LECTOR)
if @vcont=0 
       set @id_Lector ='O01'
else
    --    set @id_Lector=(Select 'O' +Right(Max (Right(IdLector,2)+ 101 ),2) 
		  --From LECTOR)
		  set @id_Lector ='o07'
insert into LECTOR
values(@id_Lector,@nom_lec,@apePat_lec,@apeMat_lec,@dni_lec,@dir_lec,@tel_lec,@email_lec,@id_dis)
go


--ACTUALIZAR LECTOR
CREATE PROCEDURE usp_ActualizarLector
@id_Lector char (3),
@nom_lec varchar (30),
@apePat_lec varchar (30),
@apeMat_lec varchar (30),
@dni_lec varchar (8),
@dir_lec varchar (50),
@tel_lec varchar (9),
@email_lec varchar(50),
@id_dis char(3)

AS
Update LECTOR
set IdLector = @id_Lector,
	Nombre_Lector = @nom_lec,
    Ape_Paterno = @apePat_lec,
	Ape_Materno = @apeMat_lec,
	Telefono = @tel_lec,
	Direccion_Lector = @dir_lec,
	Dni = @dni_lec,
	IdDistrito = @id_dis,
	Email_Lector = @email_lec
where IdLector=@id_Lector
GO

--CONSULTAR LECTOR
Create procedure usp_ConsultarLector
@id_Lector char(3)
as
Select idLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito
from LECTOR
where IdLector = @id_Lector
go

---ELIMINAR LECTOR

CREATE PROCEDURE usp_EliminarLector
@id_Lector char(3)
AS
delete from LECTOR where IdLector = @id_Lector
GO

execute usp_ListarLector


CREATE PROCEDURE usp_ListarDistrito
AS
Select IdDistrito, Nombre_Distrito
FROM DISTRITO

--Listar Ejemplar
CREATE Procedure usp_ListarEjemplar
AS
Select 
E.IdEjemplar AS CODIGO,
L.Titulo AS TITULO,
E.Estado AS ESTADO
FROM  EJEMPLAR E
INNER JOIN LIBRO L ON E.IdLibro = L.IdLibro
ORDER BY 1 ASC
GO

Exec usp_ListarEjemplar

--Actualizar ejemplar
CREATE PROCEDURE usp_ActualizarEjemplar
@id_Ejemplar char(3),
@id_Libro char(3),
@estado varchar(15)
AS
Update EJEMPLAR
set 
	IdLibro = @id_Libro,
	Estado= @estado
where IdEjemplar=@id_Ejemplar
GO

--insertar ejemplar

CREATE PROCEDURE usp_InsertarEjemplar
@id_Libro char(3),
@estado varchar(15)
AS
declare @id_Ejemplar char(3)
declare @vcont int
set @vcont=(Select count(*) from EJEMPLAR)
if @vcont=0 
       set @id_Ejemplar ='J01'
else
        set @id_Ejemplar=(Select 'J' +Right(Max (Right(IdEjemplar,2)+ 101 ),2) 
		  From EJEMPLAR)
insert into EJEMPLAR 
values(@id_Ejemplar,@id_Libro,@estado)
GO

--Consultar Ejemplar
Create procedure usp_ConsultarEjemplar
@id_Ejemplar char(3)
as
Select IdEjemplar,IdLibro,Estado
from EJEMPLAR
where IdEjemplar = @id_Ejemplar
go
