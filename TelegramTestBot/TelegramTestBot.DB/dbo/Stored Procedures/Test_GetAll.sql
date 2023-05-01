CREATE PROCEDURE [dbo].[Test_GetAll]
	
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[Test]
	WHERE (IsDeleted = 0)

END