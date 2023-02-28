CREATE PROCEDURE [dbo].[AnswerVariant_GetAll]
	
AS
BEGIN

	SELECT Id, Content, CorrectAnswer, QuestionId
	FROM dbo.[AnswerVariant]
	WHERE (IsDeleted = 0)

END