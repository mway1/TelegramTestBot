CREATE PROCEDURE [dbo].[Answer_Add]
	@Content nvarchar(50),
	@IsCorrect bit,
	@QuestionId int
AS
BEGIN
INSERT INTO dbo.[Answer](
	[Content],
	IsCorrect,
	QuestionId)
VALUES(
	@Content,
	@IsCorrect,
	@QuestionId)
SELECT @@IDENTITY
END