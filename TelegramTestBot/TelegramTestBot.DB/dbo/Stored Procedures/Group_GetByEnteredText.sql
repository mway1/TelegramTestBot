CREATE PROCEDURE [dbo].[Group_GetByEnteredText]
	@Text nvarchar(10)

AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.[Group]
	WHERE [Name] LIKE @Text + '%'

END
