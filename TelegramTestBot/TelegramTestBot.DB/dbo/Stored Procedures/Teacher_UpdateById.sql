CREATE PROCEDURE [dbo].[Teacher_UpdateById]
	@Id int,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@SurName nvarchar(30),
	@Email nvarchar(30),
	@Login nvarchar(30),
	@Password nvarchar(30)

AS
BEGIN

UPDATE dbo.[Teacher]
SET FirstName = @FirstName,
	LastName = @LastName,
	SurName = @SurName,
	Email = @Email,
	[Login] = @Login,
	[Password] = @Password 
WHERE Id = @Id

END