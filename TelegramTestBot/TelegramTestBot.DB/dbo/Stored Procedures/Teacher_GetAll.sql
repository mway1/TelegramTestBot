CREATE PROCEDURE [dbo].[Teacher_GetAll]
	
AS
BEGIN

	SELECT Id, FirstName, LastName, SurName, Email, [Login], [Password]
	FROM dbo.[Teacher]
	WHERE (IsDeleted = 0)

END