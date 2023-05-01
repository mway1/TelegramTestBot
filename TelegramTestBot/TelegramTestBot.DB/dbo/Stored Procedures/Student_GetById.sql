CREATE PROCEDURE [dbo].[Student_GetById]
	@Id int
AS
BEGIN

	SELECT Id, Firstname, Lastname, Surname, Username
	FROM dbo.[Student]
	WHERE Id=@Id

END