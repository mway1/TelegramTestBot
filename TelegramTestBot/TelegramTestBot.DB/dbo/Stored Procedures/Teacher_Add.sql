CREATE PROCEDURE [dbo].[Teacher_Add]
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@SurName nvarchar(30),
	@Email nvarchar(30),
	@Login nvarchar(30),
	@Password nvarchar(30)
AS
BEGIN
INSERT INTO dbo.[Teacher](
	FirstName,
	LastName,
	SurName,
	Email,
	[Login],
	[Password])
VALUES(
	@FirstName,
	@LastName,
	@SurName,
	@Email,
	@Login,
	@Password)
SELECT @@IDENTITY
END