CREATE PROCEDURE [dbo].[Student_GetById]
	@Id int
AS
BEGIN

	SELECT Id, FirstName, LastName, SurName, Username, IsAttendance
	FROM dbo.[Student]
	WHERE Id=@Id

END