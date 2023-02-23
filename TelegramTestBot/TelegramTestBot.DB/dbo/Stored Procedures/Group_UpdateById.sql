CREATE PROCEDURE [dbo].[Group_UpdateById]
	@Id int,
	@Name nvarchar(10),
	@StudentId int

AS
BEGIN

UPDATE dbo.[Group]
SET [Name] = @Name,
    StudentId = @StudentId

WHERE Id = @Id

END