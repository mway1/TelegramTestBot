CREATE PROCEDURE [dbo].[Student_UpdateById]
	@Id int,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@SurName nvarchar(30),
	@Username nvarchar(30),
	@IsAttendance BIT

AS
BEGIN

UPDATE dbo.[Student]
SET FirstName = @FirstName,
    LastName = @LastName,
    SurName = @SurName,
    Username = @Username,
	IsAttendance = @IsAttendance
WHERE Id = @Id

END