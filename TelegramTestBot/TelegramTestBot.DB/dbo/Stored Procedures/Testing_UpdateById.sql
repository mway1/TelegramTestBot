CREATE PROCEDURE [dbo].[Testing_UpdateById]
	@Id int,
	@Date date,
	@Start time,
	@End time,
	@GroupId int,
	@TestId int	

AS
BEGIN

UPDATE dbo.[Testing]
SET [Date] = @Date,
	[Start] = @Start,
	[End] = @End,
	GroupId = @GroupId,
	TestId = @TestId
WHERE Id = @Id

END