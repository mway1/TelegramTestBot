CREATE PROCEDURE [dbo].[Testing_UpdateById]
	@Id int,
	@Date date,
	@TestId int	

AS
BEGIN

UPDATE dbo.[Testing]
SET [Date] = @Date,
	TestId = @TestId
WHERE Id = @Id

END