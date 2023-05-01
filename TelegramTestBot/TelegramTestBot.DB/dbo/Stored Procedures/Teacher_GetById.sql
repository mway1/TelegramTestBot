CREATE PROCEDURE [dbo].[Teacher_GetById]
	@Id int
AS
BEGIN

	SELECT Id, Firstname, Lastname, Surname, Email, [Login], [Password]
	FROM dbo.[Teacher]
	WHERE Id=@Id

END