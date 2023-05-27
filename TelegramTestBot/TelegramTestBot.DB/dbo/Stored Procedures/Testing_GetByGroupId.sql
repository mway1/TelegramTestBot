CREATE PROCEDURE [dbo].[Testing_GetByGroupId]
	@GroupId int
AS
BEGIN

	SELECT MAX(Id), [Date], TestId, GroupId
	FROM dbo.[Testing]
	WHERE (GroupId = @GroupId) AND (IsDeleted = 0)

END
