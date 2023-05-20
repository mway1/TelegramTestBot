CREATE PROCEDURE [dbo].[Question_GetLastAdded]
	@TestId int
AS
BEGIN

	SELECT MAX(Id)
	FROM dbo.[Question]
	WHERE TestId=@TestId

END
