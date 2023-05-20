CREATE TABLE [dbo].[Group] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (10) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

