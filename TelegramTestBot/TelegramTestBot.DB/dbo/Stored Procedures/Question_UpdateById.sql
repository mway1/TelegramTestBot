CREATE PROCEDURE [dbo].[Question_UpdateById]
	@Id int,
	@Content nvarchar(100),
	@TestId int,
	@TypeOfQuestionId int

AS
BEGIN

UPDATE dbo.[Question]
SET Content = @Content,
    TestId = @TestId,
	TypeOfQuestionId = @TypeOfQuestionId

WHERE Id = @Id

END