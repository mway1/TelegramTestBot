CREATE PROCEDURE [dbo].[Question_UpdateById]
	@Id int,
	@Content nvarchar(100),
	@TypeOfQuestion nvarchar(50),
	@TestId int

AS
BEGIN

UPDATE dbo.[Question]
SET Content = @Content,
	TypeOfQuestion = @TypeOfQuestion,
    TestId = @TestId

WHERE Id = @Id

END