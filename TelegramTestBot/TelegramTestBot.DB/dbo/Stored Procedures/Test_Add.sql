CREATE PROCEDURE [dbo].[Test_Add]
	@Name nvarchar(50),
	@TeacherId int
AS
BEGIN
INSERT INTO dbo.[Test](
	[Name],
	TeacherId)
VALUES(
	@Name,
	@TeacherId)
SELECT @@IDENTITY
END