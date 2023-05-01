CREATE PROCEDURE [dbo].[Teacher_Test_GetAll]
	
AS
BEGIN

	SELECT Id, TestId, TeacherId
	FROM dbo.[Teacher_Test]
	WHERE (IsDeleted = 0)

END
