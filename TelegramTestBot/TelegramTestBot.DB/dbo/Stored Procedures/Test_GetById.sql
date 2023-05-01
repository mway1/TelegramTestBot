CREATE PROCEDURE [dbo].[Test_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[Test]
	WHERE Id=@Id

END