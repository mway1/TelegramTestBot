CREATE PROCEDURE [dbo].[Student_Add]
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@Username nvarchar(30)

AS
BEGIN
INSERT INTO [dbo].[Student](
	Firstname,
	Lastname,
	Surname,
	Username)
VALUES(
	@Firstname,
	@Lastname,
	@Surname,
	@Username)
SELECT @@IDENTITY
END
