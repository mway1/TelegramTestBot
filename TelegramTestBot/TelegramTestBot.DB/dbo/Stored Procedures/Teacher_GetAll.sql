CREATE PROCEDURE [dbo].[Teacher_GetAll]
	
AS
BEGIN

	SELECT Id, Firstname, Lastname, Surname, Email
	FROM dbo.[Teacher]
	WHERE (IsDeleted = 0)

END