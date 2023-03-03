CREATE PROCEDURE [dbo].[Question_GetAll]
	
AS
BEGIN

	SELECT Id, Content, TypeOfQuestion, TestId
	FROM dbo.[Question]
	WHERE (IsDeleted = 0)

END