CREATE PROCEDURE [dbo].[Answer_GetById]
	@Id int
AS
BEGIN

	SELECT Id, Content, IsCorrect, QuestionId
	FROM dbo.[Answer]
	WHERE Id=@Id

END