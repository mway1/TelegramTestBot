﻿CREATE PROCEDURE [dbo].[Student_GetAll]
	
AS
BEGIN

	SELECT Id, UserChatId, Firstname, Lastname, Surname, Username
	FROM dbo.[Student]
	WHERE (IsDeleted = 0)

END
