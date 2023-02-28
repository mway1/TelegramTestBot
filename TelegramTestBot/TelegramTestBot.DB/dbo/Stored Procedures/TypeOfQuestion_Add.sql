CREATE PROCEDURE [dbo].[TypeOfQuestion_Add]
	@Name nvarchar(50)
AS
BEGIN
INSERT INTO dbo.[TypeOfQuestion](
	[Name])
VALUES(
	@Name)
SELECT @@IDENTITY
END