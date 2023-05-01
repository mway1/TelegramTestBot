CREATE PROCEDURE [dbo].[Test_Add]
	@Name nvarchar(50)

AS
BEGIN
INSERT INTO dbo.[Test](
	[Name])

VALUES(
	@Name)

SELECT @@IDENTITY
END