CREATE PROCEDURE [dbo].[Testing_UpdateById]
	@Id int,
	@Date datetime,
	@TestId int,
	@GroupId int

AS
BEGIN

UPDATE dbo.[Testing]
SET [Date] = @Date,
	TestId = @TestId,
	GroupId = @GroupId

WHERE Id = @Id

END