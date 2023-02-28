CREATE PROCEDURE [dbo].[Testing_Add]
	@Date date,
	@Start time,
	@End time,
	@GroupId int,
	@TestId int
AS
BEGIN
INSERT INTO dbo.[Testing](
	[Date],
	[Start],
	[End],
	GroupId,
	TestId)
VALUES(
	@Date,
	@Start,
	@End,
	@GroupId,
	@TestId)
SELECT @@IDENTITY
END