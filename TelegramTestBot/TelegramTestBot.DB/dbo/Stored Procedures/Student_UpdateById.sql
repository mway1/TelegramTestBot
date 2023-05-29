CREATE PROCEDURE [dbo].[Student_UpdateById]
	@Id int,
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@GroupId int

AS
BEGIN

UPDATE dbo.[Student]
SET Firstname = @Firstname,
    Lastname = @Lastname,
    Surname = @Surname,
	GroupId = @GroupId

WHERE Id = @Id

END