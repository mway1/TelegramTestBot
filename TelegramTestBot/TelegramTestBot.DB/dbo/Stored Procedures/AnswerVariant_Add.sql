CREATE PROCEDURE [dbo].[AnswerVariant_Add]
	@Content nvarchar(50),
	@IsCorrectAnswer bit,
	@QuestionId int
AS
BEGIN
INSERT INTO dbo.[AnswerVariant](
	[Content],
	IsCorrectAnswer,
	QuestionId)
VALUES(
	@Content,
	@IsCorrectAnswer,
	@QuestionId)
SELECT @@IDENTITY
END