CREATE PROCEDURE [dbo].[TelegramBot_Add]
	@Name nvarchar(30),
	@HashToken nvarchar(200)

AS
BEGIN
INSERT INTO dbo.[TelegramBot](
	[Name],
	HashToken)
VALUES(
	@Name,
	@HashToken)
SELECT @@IDENTITY
END
