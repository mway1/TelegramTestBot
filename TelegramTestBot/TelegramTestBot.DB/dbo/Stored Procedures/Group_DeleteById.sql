CREATE PROCEDURE [dbo].[Group_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Group]
SET IsDeleted = 1
WHERE Id=@Id

END