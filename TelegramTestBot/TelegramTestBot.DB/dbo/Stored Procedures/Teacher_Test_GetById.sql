CREATE PROCEDURE [dbo].[Teacher_Test_GetById]
	@Id int
AS
BEGIN

	SELECT Id, TestId, TeacherId
	FROM dbo.[Teacher_Test]
	WHERE Id=@Id

END
