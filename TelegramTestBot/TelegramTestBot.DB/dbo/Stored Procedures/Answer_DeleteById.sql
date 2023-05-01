CREATE PROCEDURE [dbo].[Answer_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Answer]
SET IsDeleted = 1
WHERE Id=@Id

END