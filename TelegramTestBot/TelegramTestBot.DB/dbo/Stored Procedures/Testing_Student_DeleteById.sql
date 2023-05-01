CREATE PROCEDURE [dbo].[Testing_Student_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Testing_Student]
SET IsDeleted = 1
WHERE Id=@Id

END
