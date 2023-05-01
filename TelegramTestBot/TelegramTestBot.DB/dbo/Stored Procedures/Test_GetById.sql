CREATE PROCEDURE [dbo].[Test_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name], TeacherId
	FROM dbo.[Test]
	WHERE Id=@Id

END