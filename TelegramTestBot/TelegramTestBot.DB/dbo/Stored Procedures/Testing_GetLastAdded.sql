CREATE PROCEDURE [dbo].[Testing_GetLastAddedByGroupId]
  @GroupId int

AS
BEGIN

  SELECT MAX(Id)
  FROM dbo.[Testing]
  WHERE (GroupId=@GroupId)  AND (IsDeleted = 0)
END