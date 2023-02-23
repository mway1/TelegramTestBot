CREATE PROCEDURE [dbo].[Student_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Student]
SET IsDeleted = 1
WHERE Id=@Id

END