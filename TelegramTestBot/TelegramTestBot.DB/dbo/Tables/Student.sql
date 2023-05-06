CREATE TABLE [dbo].[Student] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [UserChatId]  BIGINT NOT NULL,
    [Firstname]  VARCHAR (30) NOT NULL,
    [Lastname]   VARCHAR (30) NULL,
    [Surname]    VARCHAR (30) NOT NULL,
    [Username]   VARCHAR (30) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

