CREATE PROCEDURE [dbo].[Student_GetStudentsByGroupId]
	@GroupId int
AS
BEGIN

	SELECT Id, UserChatId
	FROM dbo.[Student]
	WHERE (GroupId = @GroupId) AND (IsDeleted = 0)

END
