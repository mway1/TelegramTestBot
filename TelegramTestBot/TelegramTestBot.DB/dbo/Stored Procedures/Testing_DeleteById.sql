CREATE PROCEDURE [dbo].[Testing_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Testing]
SET IsDeleted = 1
WHERE Id=@Id

END