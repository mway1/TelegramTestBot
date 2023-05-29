CREATE PROCEDURE [dbo].[Testing_GetByGroupId]
	@GroupId int
AS
BEGIN

	SELECT Id, [Date], TestId, GroupId
	FROM dbo.[Testing]
	WHERE (GroupId = @GroupId) AND (IsDeleted = 0)

END
