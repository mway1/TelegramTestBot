CREATE PROCEDURE [dbo].[AnswerVariant_UpdateById]
	@Id int,
	@Content nvarchar(50),
	@CorrectAnswer bit,
	@QuestionId int

AS
BEGIN

UPDATE dbo.[AnswerVariant]
SET Content = @Content,
	CorrectAnswer = @CorrectAnswer,
	QuestionId = @QuestionId
WHERE Id = @Id

END