﻿CREATE PROCEDURE [dbo].[Teacher_GetByLogin]
	@Login VARCHAR (30),
	@Password VARCHAR (256)
AS
BEGIN

	SELECT Id, Firstname, Lastname, Surname, Email, [Login], [Password]
	FROM dbo.[Teacher]
	WHERE [Login]=@Login and [Password]=@Password

END