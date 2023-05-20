CREATE PROCEDURE [dbo].[Student_GetByChatId]
	@UserChatId bigint
AS
BEGIN

	SELECT Id, UserChatId, Firstname, Lastname, Surname, Username, GroupId
	FROM dbo.[Student]
	WHERE UserChatId=@UserChatId

END
