CREATE PROCEDURE [dbo].[Testing_GetStatusOfTestById]
	@Id int
AS
BEGIN

	SELECT isActive
	FROM dbo.[Testing]
	WHERE (Id = @Id) AND (IsDeleted = 0)

END
