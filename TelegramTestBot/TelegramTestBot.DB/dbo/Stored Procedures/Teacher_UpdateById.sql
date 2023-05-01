CREATE PROCEDURE [dbo].[Teacher_UpdateById]
	@Id int,
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@Email nvarchar(30),
	@Login nvarchar(30),
	@Password nvarchar(30)

AS
BEGIN

UPDATE dbo.[Teacher]
SET Firstname = @Firstname,
	Lastname = @Lastname,
	Surname = @Surname,
	Email = @Email,
	[Login] = @Login,
	[Password] = @Password 
WHERE Id = @Id

END