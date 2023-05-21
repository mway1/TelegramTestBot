CREATE PROCEDURE [dbo].[Answer_UpdateById]
    @Id int,
	@Content nvarchar(50),
	@IsCorrect bit,
	@QuestionId int

AS
BEGIN

UPDATE dbo.[Answer]
SET Content = @Content,
	IsCorrect = @IsCorrect,
	QuestionId = @QuestionId
WHERE Id = @Id

END