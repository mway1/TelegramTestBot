CREATE PROCEDURE [dbo].[Testing_Student_GetByStudentId]
	@StudentId int
AS
BEGIN

	SELECT TS.Id, TS.CountAnswers,TS.IsAttendance,T.[Date] as DateOfTesting,S.Surname as SurnameOfStudent,S.Firstname as FirstnameOfStudent
	FROM dbo.[Testing_Student] as TS
    LEFT JOIN dbo.[Testing] as T on (TS.TestingId = T.Id)
	LEFT JOIN dbo.[Student] as S on (TS.StudentId = S.Id)
    WHERE TS.StudentId = @StudentId

END

