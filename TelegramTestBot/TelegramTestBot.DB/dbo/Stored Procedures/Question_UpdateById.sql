CREATE PROCEDURE [dbo].[Question_UpdateById]
	@Id int,
	@Content nvarchar(100),
	@TestId int

AS
BEGIN

UPDATE dbo.[Question]
SET Content = @Content,
    TestId = @TestId

WHERE Id = @Id

END