CREATE PROCEDURE [dbo].[Student_Add]
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@SurName nvarchar(30),
	@Username nvarchar(30),
	@Attendance BIT
AS
BEGIN
INSERT INTO [dbo].[Student](
	FirstName,
	LastName,
	SurName,
	Username,
	Attendance)
VALUES(
	@FirstName,
	@LastName,
	@SurName,
	@Username,
	@Attendance)
SELECT @@IDENTITY
END
