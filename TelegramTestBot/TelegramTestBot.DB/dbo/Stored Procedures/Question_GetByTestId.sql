CREATE PROCEDURE [dbo].[Question_GetByTestId]
	@TestId int
AS
BEGIN

	SELECT Id, Content, TestId
	FROM dbo.[Question]
	WHERE TestId=@TestId

END
