USE [Biblioteca2]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarLector]    Script Date: 01/06/2018 19:41:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_InsertarLector]
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


insert into LECTOR
values('o07','test','test','test','12345678','Av. los angeles 345','12345678','test@gmail.com','d01')
go

