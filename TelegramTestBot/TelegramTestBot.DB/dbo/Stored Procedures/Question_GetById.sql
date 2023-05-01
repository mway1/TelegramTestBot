CREATE PROCEDURE [dbo].[Question_GetById]
	@Id int
AS
BEGIN

	SELECT Id, Content, TestId
	FROM dbo.[Question]
	WHERE Id=@Id

END