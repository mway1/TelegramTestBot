CREATE PROCEDURE [dbo].[Test_GetAll]
	
AS
BEGIN

	SELECT Id, [Name], TeacherId
	FROM dbo.[Test]
	WHERE (IsDeleted = 0)

END