CREATE PROCEDURE [dbo].[Teacher_Test_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Teacher_Test]
SET IsDeleted = 1
WHERE Id=@Id

END
