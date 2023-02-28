CREATE PROCEDURE [dbo].[Teacher_GetById]
	@Id int
AS
BEGIN

	SELECT Id, FirstName, LastName, SurName, Email, [Login], [Password]
	FROM dbo.[Teacher]
	WHERE Id=@Id

END