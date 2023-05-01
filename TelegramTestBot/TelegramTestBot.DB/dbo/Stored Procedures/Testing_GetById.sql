CREATE PROCEDURE [dbo].[Testing_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Date], TestId
	FROM dbo.[Testing]
	WHERE Id=@Id

END