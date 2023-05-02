CREATE TABLE [dbo].[TelegramBot]
(
	[Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (30) NOT NULL,
    [HashToken]      VARCHAR (200) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC), 
);
