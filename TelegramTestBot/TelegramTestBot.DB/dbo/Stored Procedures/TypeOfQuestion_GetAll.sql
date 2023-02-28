CREATE PROCEDURE [dbo].[TypeOfQuestion_GetAll]
	
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[TypeOfQuestion]
	WHERE (IsDeleted = 0)

END