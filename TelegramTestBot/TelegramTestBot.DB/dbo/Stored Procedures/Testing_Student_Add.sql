CREATE PROCEDURE [dbo].[Testing_Student_Add]
	@CountAnswers int,
	@StudentId int,
	@TestingId int,
	@IsAttendance bit
AS
BEGIN
INSERT INTO dbo.[Testing_Student](
	CountAnswers,
	StudentId,
	TestingId,
	IsAttendance)
VALUES(
	@CountAnswers,
	@StudentId,
	@TestingId,
	@IsAttendance)
SELECT @@IDENTITY
END
