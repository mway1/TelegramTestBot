CREATE PROCEDURE [dbo].[Testing_Student_GetByStudentIdByTestingId]
	@StudentId int,
	@TestingId int

AS
BEGIN

	SELECT MAX(Id)
	FROM dbo.[Testing_Student]
	WHERE (StudentId = @StudentId) AND (TestingId = @TestingId) AND (IsDeleted = 0)

END

