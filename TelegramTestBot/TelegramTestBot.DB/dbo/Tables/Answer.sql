CREATE TABLE [dbo].[Answer] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Content]       VARCHAR (50) NOT NULL,
    [QuestionId]    INT          NOT NULL,
    [IsCorrect] BIT NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

