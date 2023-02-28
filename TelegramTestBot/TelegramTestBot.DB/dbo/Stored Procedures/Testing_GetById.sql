CREATE PROCEDURE [dbo].[Testing_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Date], [Start], [End], GroupId, TestId
	FROM dbo.[Testing]
	WHERE Id=@Id

END