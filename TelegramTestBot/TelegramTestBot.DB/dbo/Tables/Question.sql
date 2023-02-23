CREATE TABLE [dbo].[Question] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [TestId]           INT           NOT NULL,
    [TypeOfQuestionId] INT           NOT NULL,
    [Content]          VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([Id]),
    FOREIGN KEY ([TypeOfQuestionId]) REFERENCES [dbo].[TypeOfQuestion] ([Id])
);

