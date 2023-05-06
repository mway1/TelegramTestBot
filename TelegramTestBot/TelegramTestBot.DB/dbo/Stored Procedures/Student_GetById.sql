CREATE PROCEDURE [dbo].[Student_GetById]
	@Id int
AS
BEGIN

	SELECT Id, UserChatId, Firstname, Lastname, Surname, Username
	FROM dbo.[Student]
	WHERE Id=@Id

END