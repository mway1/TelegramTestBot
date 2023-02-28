CREATE PROCEDURE [dbo].[Testing_GetAll]
	
AS
BEGIN

	SELECT Id, [Date], [Start], [End], GroupId, TestId
	FROM dbo.[Testing]
	WHERE (IsDeleted = 0)

END