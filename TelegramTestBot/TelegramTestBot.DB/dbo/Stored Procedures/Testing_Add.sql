﻿CREATE PROCEDURE [dbo].[Testing_Add]
	@Date date,
	@TestId int
AS
BEGIN
INSERT INTO dbo.[Testing](
	[Date],
	TestId)
VALUES(
	@Date,
	@TestId)
SELECT @@IDENTITY
END