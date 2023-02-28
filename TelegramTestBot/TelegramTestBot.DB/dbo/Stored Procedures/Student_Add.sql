CREATE PROCEDURE [dbo].[Student_Add]
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@Surname nvarchar(30),
	@Username nvarchar(30),
	@Attendance BIT
AS
BEGIN
INSERT INTO [dbo].[Student](
	FirstName,
	LastName,
	Surname,
	Username,
	Attendance)
VALUES(
	@FirstName,
	@LastName,
	@Surname,
	@Username,
	@Attendance)
SELECT @@IDENTITY
END
