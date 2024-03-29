USE [Biblioteca2]
GO
/****** Object:  StoredProcedure [dbo].[usp_ConsultarLibro]    Script Date: 01/06/2018 19:13:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_ConsultarLibro]
@id_Libro char(3)
as
--Select
--IdLibro, 
--Titulo,
--NomApe_Autor,
--Nombre_Categoria, 
--Nombre_Editorial,
--Nombre_Idioma,
--Año_Lanz
--FROM  LIBRO L
--INNER JOIN AUTOR A ON L.IdAutor = A.IdAutor
--INNER JOIN CATEGORIA C ON L.IdCategoria = C.IdCategoria
--INNER JOIN EDITORIAL E ON L.IdEditorial = E.IdEditorial
--INNER JOIN IDIOMA I ON L.IdIdioma = I.IdIdioma
--where IdLibro=@id_Libro
Select idlibro,titulo,idautor,idcategoria,ideditorial,IdIdioma,año_lanz
from libro
where idlibro=@id_libro
go

use Biblioteca2
go

Create procedure usp_ConsultarLector
@id_Lector char(3)
as
Select idLector,Nombre_Lector,Ape_Paterno,Ape_Materno,Dni,Direccion_Lector,Telefono,Email_Lector,IdDistrito
from LECTOR
where IdLector = @id_Lector
go