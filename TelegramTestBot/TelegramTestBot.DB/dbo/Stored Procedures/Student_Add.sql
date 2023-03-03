CREATE PROCEDURE [dbo].[Student_Add]
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@SurName nvarchar(30),
	@Username nvarchar(30),
	@IsAttendance BIT
AS
BEGIN
INSERT INTO [dbo].[Student](
	FirstName,
	LastName,
	SurName,
	Username,
	IsAttendance)
VALUES(
	@FirstName,
	@LastName,
	@SurName,
	@Username,
	@IsAttendance)
SELECT @@IDENTITY
END
