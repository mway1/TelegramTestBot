CREATE PROCEDURE [dbo].[Student_GetByGroupId]
	@GroupId int
AS
BEGIN

	SELECT Id, UserChatId, Firstname, Lastname, Surname, Username, GroupId
	FROM dbo.[Student]
	WHERE GroupId=@GroupId

END
