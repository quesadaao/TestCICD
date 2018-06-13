CREATE PROCEDURE dbo.sp_Insertar
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

    -- Insert statements for procedure here
INSERT INTO Persona
                         (iCedula, vNombre, bMuerto, dtNacimiento, iEdad, vEmail)
VALUES        (@iCedula,@vNombre,@bMuerto,@dtNacimiento,@iEdad,@vEmail);

END
GO
