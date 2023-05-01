CREATE PROCEDURE [dbo].[Teacher_Add]
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@Email nvarchar(30),
	@Login nvarchar(30),
	@Password nvarchar(30)
AS
BEGIN
INSERT INTO dbo.[Teacher](
	Firstname,
	Lastname,
	Surname,
	Email,
	[Login],
	[Password])
VALUES(
	@Firstname,
	@Lastname,
	@Surname,
	@Email,
	@Login,
	@Password)
SELECT @@IDENTITY
END