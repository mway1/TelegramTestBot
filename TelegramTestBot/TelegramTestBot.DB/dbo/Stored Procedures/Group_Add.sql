CREATE PROCEDURE [dbo].[Group_Add]
	@Name nvarchar(10)

AS
BEGIN
INSERT INTO dbo.[Group](
	[Name])
VALUES(
	@Name)
SELECT @@IDENTITY
END