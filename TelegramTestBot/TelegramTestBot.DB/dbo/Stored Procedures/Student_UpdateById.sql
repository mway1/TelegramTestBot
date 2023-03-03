CREATE PROCEDURE [dbo].[Student_UpdateById]
	@Id int,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@SurName nvarchar(30),
	@Username nvarchar(30),
	@Attendance BIT

AS
BEGIN

UPDATE dbo.[Student]
SET FirstName = @FirstName,
    LastName = @LastName,
    SurName = @SurName,
    Username = @Username,
	Attendance = @Attendance
WHERE Id = @Id

END