CREATE PROCEDURE [dbo].[Test_UpdateById]
	@Id int,
	@Name nvarchar(50)

AS
BEGIN

UPDATE dbo.[Test]
SET [Name] = @Name

WHERE Id = @Id

END