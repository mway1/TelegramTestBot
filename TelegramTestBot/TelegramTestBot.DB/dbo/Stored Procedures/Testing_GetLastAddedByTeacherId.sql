CREATE PROCEDURE [dbo].[Testing_GetLastAddedByTeacherId]
	@TeacherId int

AS
BEGIN

  SELECT T.[Date],Test.[Name] as Testname, G.[Name] as Groupname 
  FROM dbo.[Testing] as T
  LEFT JOIN dbo.[Test] as Test on (T.TestId=Test.Id)
  LEFT JOIN dbo.[Group] as G on (T.GroupId = G.Id)
  WHERE (Test.TeacherId =@TeacherId)  AND (Test.IsDeleted = 0) AND (T.IsDeleted=0) AND (G.IsDeleted=0) AND (isActive = 1)
END