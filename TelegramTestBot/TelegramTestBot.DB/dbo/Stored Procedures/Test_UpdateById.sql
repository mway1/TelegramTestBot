CREATE PROCEDURE [dbo].[Test_UpdateById]
	@Id int,
	@Name nvarchar(50),
	@TeacherId int

AS
BEGIN

UPDATE dbo.[Test]
SET [Name] = @Name,
    TeacherId = @TeacherId
WHERE Id = @Id

END