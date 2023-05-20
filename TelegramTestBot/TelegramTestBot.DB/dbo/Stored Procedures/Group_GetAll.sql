CREATE PROCEDURE [dbo].[Group_GetAll]
	
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[Group]
	WHERE (IsDeleted = 0)

END