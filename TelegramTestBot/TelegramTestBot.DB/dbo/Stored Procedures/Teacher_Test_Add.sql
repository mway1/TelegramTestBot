CREATE PROCEDURE [dbo].[Teacher_Test_Add]
	@TestId int,
	@TeacherId int
AS
BEGIN
INSERT INTO dbo.[Teacher_Test](
	TestId,
	TeacherId)
VALUES(
	@TestId,
	@TeacherId)
SELECT @@IDENTITY
END
