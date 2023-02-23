CREATE PROCEDURE [dbo].[Test_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Test]
SET IsDeleted = 1
WHERE Id=@Id

END