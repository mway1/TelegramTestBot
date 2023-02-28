CREATE PROCEDURE [dbo].[AnswerVariant_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[AnswerVariant]
SET IsDeleted = 1
WHERE Id=@Id

END