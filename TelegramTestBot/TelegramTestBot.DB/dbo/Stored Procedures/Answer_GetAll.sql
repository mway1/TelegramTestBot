CREATE PROCEDURE [dbo].[Answer_GetAll]
	
AS
BEGIN

	SELECT Id, Content, IsCorrect, QuestionId
	FROM dbo.[Answer]
	WHERE (IsDeleted = 0)

END