CREATE PROCEDURE [dbo].[Testing_GetAll]
	
AS
BEGIN

	SELECT Id, [Date], TestId, GroupId
	FROM dbo.[Testing]
	WHERE (IsDeleted = 0)

END