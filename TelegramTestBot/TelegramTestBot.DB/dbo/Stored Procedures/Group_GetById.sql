CREATE PROCEDURE [dbo].[Group_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[Group]
	WHERE Id=@Id

END