CREATE PROCEDURE [dbo].[Answer_GetByQuestionId]
	@QuestionId int
AS
BEGIN

	SELECT Id, Content, IsCorrect
	FROM dbo.[Answer]
	WHERE QuestionId=@QuestionId

END
