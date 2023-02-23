CREATE PROCEDURE [dbo].[Question_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Question]
SET IsDeleted = 1
WHERE Id=@Id

END
