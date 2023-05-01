CREATE PROCEDURE [dbo].[Teacher_Test_UpdateById]
	@Id int,
	@TestId int,
	@TeacherId int

AS
BEGIN

UPDATE dbo.[Teacher_Test]
SET TestId = @TestId,
	TeacherId = @TeacherId

WHERE Id = @Id

END
