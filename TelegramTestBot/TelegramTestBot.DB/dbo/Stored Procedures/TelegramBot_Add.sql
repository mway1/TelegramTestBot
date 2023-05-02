CREATE PROCEDURE [dbo].[TelegramBot_Add]
	@HashToken nvarchar(200)

AS
BEGIN
INSERT INTO dbo.[TelegramBot](
	HashToken)
VALUES(
	@HashToken)
SELECT @@IDENTITY
END
