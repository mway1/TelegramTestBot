CREATE PROCEDURE [dbo].[Teacher_GetByLogin]
	@Login VARCHAR (30)

AS
BEGIN

	SELECT Id, Firstname, Lastname, Surname, Email, [Login], [Password]
	FROM dbo.[Teacher]
	WHERE [Login]=@Login

END