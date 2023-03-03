CREATE PROCEDURE [dbo].[Student_GetAll]
	
AS
BEGIN

	SELECT Id, FirstName, LastName, SurName, Username, IsAttendance
	FROM dbo.[Student]
	WHERE (IsDeleted = 0)

END
