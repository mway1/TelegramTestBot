CREATE PROCEDURE [dbo].[Student_GetByChatId]
	@UserChatId bigint
AS
BEGIN

	SELECT Id, UserChatId, Firstname, Lastname, Surname, Username
	FROM dbo.[Student]
	WHERE UserChatId=@UserChatId

END
