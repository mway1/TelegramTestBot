CREATE PROCEDURE [dbo].[Testing_Student_GetByStudentId]
	@StudentId int
AS
BEGIN

	SELECT TS.Id, TS.CountAnswers, S.Surname,S.Firstname, T.[Date],TS.IsAttendance
	FROM dbo.[Testing_Student] as TS
    LEFT JOIN dbo.[Student] as S on (S.Id = TS.StudentId)
	LEFT JOIN dbo.[Testing] as T on (T.Id = TS.TestingId)
    WHERE StudentId = @StudentId

END

