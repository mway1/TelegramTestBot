CREATE PROCEDURE [dbo].[TelegramBot_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name], HashToken
	FROM dbo.[TelegramBot]
	WHERE Id=@Id

END
