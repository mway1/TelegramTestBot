CREATE PROCEDURE [dbo].[Testing_Student_UpdateById]
	@Id int,
	@CountAnswers int,
	@StudentId int,
	@TestingId int,
	@IsAttendance bit

AS
BEGIN

UPDATE dbo.[Testing_Student]
SET CountAnswers = @CountAnswers,
	StudentId = @StudentId,
	TestingId = @TestingId,
	IsAttendance = @IsAttendance
WHERE Id = @Id

END
