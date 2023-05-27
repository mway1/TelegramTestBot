CREATE PROCEDURE [dbo].[Testing_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Date], TestId, GroupId
	FROM dbo.[Testing]
	WHERE Id=@Id

END