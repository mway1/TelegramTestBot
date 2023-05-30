CREATE TABLE [dbo].[Testing] (
    [Id]      INT      IDENTITY (1, 1) NOT NULL,
    [TestId]  INT      NOT NULL,
    [Date]    DATETIME     NOT NULL,
    [GroupId] INT NOT NULL,
    [isActive] BIT NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([Id]),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id])
);

