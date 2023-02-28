CREATE PROCEDURE [dbo].[Student_UpdateById]
	@Id int,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@Surname nvarchar(30),
	@Username nvarchar(30),
	@Attendance BIT

AS
BEGIN

UPDATE dbo.[Student]
SET FirstName = @FirstName,
    LastName = @LastName,
    SurName = @Surname,
    Username = @Username,
	Attendance = @Attendance
WHERE Id = @Id

END