CREATE PROCEDURE [dbo].[Student_Add]
	@UserChatId bigint,
	@Firstname nvarchar(30),
	@Lastname nvarchar(30),
	@Surname nvarchar(30),
	@Username nvarchar(30)

AS
BEGIN
INSERT INTO [dbo].[Student](
	UserChatId,
	Firstname,
	Lastname,
	Surname,
	Username)
VALUES(
	@UserChatId,
	@Firstname,
	@Lastname,
	@Surname,
	@Username)
SELECT @@IDENTITY
END
