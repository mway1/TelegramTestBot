CREATE PROCEDURE [dbo].[Testing_Student_GetAll]
	
AS
BEGIN

	SELECT Id, CountAnswers, StudentId, TestingId, IsAttendance
	FROM dbo.[Testing_Student]
	WHERE (IsDeleted = 0)

END
