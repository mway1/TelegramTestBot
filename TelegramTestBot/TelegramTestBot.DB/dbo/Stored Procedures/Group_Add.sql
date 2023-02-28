CREATE PROCEDURE [dbo].[Group_Add]
	@Name nvarchar(10),
	@StudentId int
AS
BEGIN
INSERT INTO dbo.[Group](
	[Name],
	StudentId)
VALUES(
	@Name,
	@StudentId)
SELECT @@IDENTITY
END