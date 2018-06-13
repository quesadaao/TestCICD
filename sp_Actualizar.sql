USE [Fidelitas]
GO

/****** Object:  StoredProcedure [dbo].[sp_Insertar]    Script Date: 6/9/2017 12:39:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_Actualizar]
	-- Add the parameters for the stored procedure here
@iCedula int,
@vNombre varchar(50),
@bMuerto bit,
@dtNacimiento date,
@iEdad int,
@vEmail varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE Persona
   SET vNombre = @vNombre, 
	   bMuerto = @bMuerto, 
	   dtNacimiento = @dtNacimiento, 
	   iEdad = @iEdad, 
	   vEmail = @vEmail
 WHERE (iCedula = @iCedula);

END

GO


