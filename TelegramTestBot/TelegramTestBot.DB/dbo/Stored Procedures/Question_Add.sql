CREATE PROCEDURE [dbo].[Question_Add]
	@Content nvarchar(100),
	@TestId int
AS
BEGIN
INSERT INTO dbo.[Question](
	Content,
	TestId)
VALUES(
	@Content,
	@TestId)
SELECT @@IDENTITY
END