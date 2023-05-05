CREATE PROCEDURE [dbo].[TelegramBot_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[TelegramBot]
SET IsDeleted = 1
WHERE Id=@Id

END
