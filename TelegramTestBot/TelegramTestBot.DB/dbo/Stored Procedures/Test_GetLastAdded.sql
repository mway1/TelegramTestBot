CREATE PROCEDURE [dbo].[Test_GetLastAdded]
	@TeacherId int
AS
BEGIN

	SELECT MAX(Id)
	FROM dbo.[Test]
	WHERE TeacherId=@TeacherId

END
