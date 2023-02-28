CREATE PROCEDURE [dbo].[TypeOfQuestion_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[TypeOfQuestion]
SET IsDeleted = 1
WHERE Id=@Id

END