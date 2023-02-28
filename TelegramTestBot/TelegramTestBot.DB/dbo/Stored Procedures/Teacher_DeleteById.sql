CREATE PROCEDURE [dbo].[Teacher_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Teacher]
SET IsDeleted = 1
WHERE Id=@Id

END