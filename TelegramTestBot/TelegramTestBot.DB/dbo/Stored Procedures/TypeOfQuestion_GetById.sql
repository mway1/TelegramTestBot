CREATE PROCEDURE [dbo].[TypeOfQuestion_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[TypeOfQuestion]
	WHERE Id=@Id

END