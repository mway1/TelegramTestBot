CREATE PROCEDURE [dbo].[Answer_GetRightAnswer]
	@QuestionId int
AS
BEGIN

	SELECT Id
	FROM dbo.[Answer]
	WHERE (QuestionId=@QuestionId) AND (IsCorrect=1) AND (IsDeleted=0)

END
