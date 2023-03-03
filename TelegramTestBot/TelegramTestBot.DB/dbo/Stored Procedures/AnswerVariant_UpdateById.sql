CREATE PROCEDURE [dbo].[AnswerVariant_UpdateById]
	@Id int,
	@Content nvarchar(50),
	@IsCorrectAnswer bit,
	@QuestionId int

AS
BEGIN

UPDATE dbo.[AnswerVariant]
SET Content = @Content,
	IsCorrectAnswer = @IsCorrectAnswer,
	QuestionId = @QuestionId
WHERE Id = @Id

END