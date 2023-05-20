CREATE PROCEDURE [dbo].[Group_UpdateById]
	@Id int,
	@Name nvarchar(10)

AS
BEGIN

UPDATE dbo.[Group]
SET [Name] = @Name

WHERE Id = @Id

END