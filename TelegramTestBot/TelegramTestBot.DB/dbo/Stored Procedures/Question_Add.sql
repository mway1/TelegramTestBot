CREATE PROCEDURE [dbo].[Question_Add]
	@Content nvarchar(100),
	@TestId int,
	@TypeOfQuestionId int
AS
BEGIN
INSERT INTO dbo.[Question](
	Content,
	TestId,
	TypeOfQuestionId)
VALUES(
	@Content,
	@TestId,
	@TypeOfQuestionId)
SELECT @@IDENTITY
END