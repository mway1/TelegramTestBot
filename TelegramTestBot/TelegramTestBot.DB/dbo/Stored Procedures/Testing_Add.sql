CREATE PROCEDURE [dbo].[Testing_Add]
	@Date datetime,
	@TestId int,
    @GroupId int 
AS
BEGIN
INSERT INTO dbo.[Testing](
	[Date],
	TestId,GroupId)
VALUES(
	@Date,
	@TestId,@GroupId)
SELECT @@IDENTITY
END