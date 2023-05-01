CREATE PROCEDURE [dbo].[Student_UpdateById]
	@Id int,
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@Username nvarchar(30)

AS
BEGIN

UPDATE dbo.[Student]
SET Firstname = @Firstname,
    Lastname = @Lastname,
    Surname = @Surname,
    Username = @Username

WHERE Id = @Id

END