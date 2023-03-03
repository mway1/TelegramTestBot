CREATE PROCEDURE [dbo].[AnswerVariant_GetById]
	@Id int
AS
BEGIN

	SELECT Id, Content, IsCorrectAnswer, QuestionId
	FROM dbo.[AnswerVariant]
	WHERE Id=@Id

END