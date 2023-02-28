CREATE PROCEDURE [dbo].[TypeOfQuestion_UpdateById]
	@Id int,
	@Name nvarchar(50)	

AS
BEGIN

UPDATE dbo.[TypeOfQuestion]
SET [Name] = @Name
WHERE Id = @Id

END