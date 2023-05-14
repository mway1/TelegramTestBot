CREATE PROCEDURE [dbo].[Test_GetByTeacherId]
	@TeacherId int
AS
BEGIN

	SELECT Id, [Name], TeacherId
	FROM dbo.[Test]
	WHERE TeacherId=@TeacherId

END
