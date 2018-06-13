USE [FidelitasIICUAP4]
GO

/****** Object:  StoredProcedure [dbo].[sp_Insertar]    Script Date: 6/2/2017 8:33:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_Mostrar]


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Persona;
END

GO


