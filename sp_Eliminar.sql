CREATE PROCEDURE dbo.sp_Eliminar
	-- Add the parameters for the stored procedure here
@iCedula int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- statements for procedure here
--DELETE FROM Persona
--WHERE        (iCedula = @iCedula);

-- Dar de baja 
UPDATE       Persona
SET                bMuerto = 1
WHERE        (iCedula = @iCedula);

END
GO
