CREATE PROCEDURE [dbo].[Question_Add]
	@Content nvarchar(100),
	@TypeOfQuestion nvarchar(50),
	@TestId int
AS
BEGIN
INSERT INTO dbo.[Question](
	Content,
	TypeOfQuestion,
	TestId)
VALUES(
	@Content,
	@TypeOfQuestion,
	@TestId)
SELECT @@IDENTITY
END