CREATE PROCEDURE [dbo].[Testing_GetAll]
	
AS
BEGIN

	SELECT Id, [Date], TestId
	FROM dbo.[Testing]
	WHERE (IsDeleted = 0)

END