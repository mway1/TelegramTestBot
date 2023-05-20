CREATE PROCEDURE [dbo].[Student_UpdateById]
	@Id int,
	@UserChatId bigint,
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@Username nvarchar(30),
	@GroupId int

AS
BEGIN

UPDATE dbo.[Student]
SET UserChatId = @UserChatId,
	Firstname = @Firstname,
    Lastname = @Lastname,
    Surname = @Surname,
    Username = @Username,
	GroupId = @GroupId

WHERE Id = @Id

END