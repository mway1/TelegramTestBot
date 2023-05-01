CREATE PROCEDURE [dbo].[Testing_Student_GetById]
	@Id int
AS
BEGIN

	SELECT Id, CountAnswers, StudentId, TestingId, IsAttendance
	FROM dbo.[Testing_Student]
	WHERE Id=@Id

END
