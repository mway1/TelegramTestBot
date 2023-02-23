CREATE TABLE [dbo].[Testing] (
    [Id]      INT      IDENTITY (1, 1) NOT NULL,
    [Date]    DATE     NOT NULL,
    [Start]   TIME (7) NOT NULL,
    [End]     TIME (7) NOT NULL,
    [GroupId] INT      NOT NULL,
    [TestId]  INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([Id])
);

