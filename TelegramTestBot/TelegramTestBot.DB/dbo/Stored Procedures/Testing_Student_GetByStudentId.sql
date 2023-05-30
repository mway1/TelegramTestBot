CREATE PROCEDURE [dbo].[Testing_Student_GetByStudentId]
	@StudentId int
AS
BEGIN

	SELECT TS.Id, TS.CountAnswers, TS.IsAttendance, Tg.[Date] AS DateOfTesting, S.Surname AS SurnameOfStudent, S.Firstname AS FirstnameOfStudent, T.[Name] AS Testname, COUNT(Q.Id) AS CountQuestions
    FROM dbo.[Testing_Student] AS TS
    LEFT JOIN dbo.[Testing] AS Tg ON TS.TestingId = Tg.Id
    LEFT JOIN dbo.[Test] AS T ON Tg.TestId = T.Id
    LEFT JOIN dbo.[Question] AS Q ON T.Id = Q.TestId
    LEFT JOIN dbo.[Student] AS S ON TS.StudentId = S.Id
    WHERE TS.StudentId = @StudentId
    GROUP BY TS.Id, TS.CountAnswers, TS.IsAttendance, Tg.[Date], S.Surname, S.Firstname, T.[Name]

END

