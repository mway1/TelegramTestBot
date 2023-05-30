CREATE PROCEDURE [dbo].[Testing_UpdateById]
	@Id int,
	@Date datetime,
	@TestId int,
	@GroupId int,
	@isActive bit

AS
BEGIN

UPDATE dbo.[Testing]
SET [Date] = @Date,
	TestId = @TestId,
	GroupId = @GroupId,
	isActive = @isActive

WHERE Id = @Id

END