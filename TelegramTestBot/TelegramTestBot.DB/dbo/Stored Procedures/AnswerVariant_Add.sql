CREATE PROCEDURE [dbo].[AnswerVariant_Add]
	@Content nvarchar(50),
	@CorrectAnswer bit,
	@QuestionId int
AS
BEGIN
INSERT INTO dbo.[AnswerVariant](
	[Content],
	CorrectAnswer,
	QuestionId)
VALUES(
	@Content,
	@CorrectAnswer,
	@QuestionId)
SELECT @@IDENTITY
END