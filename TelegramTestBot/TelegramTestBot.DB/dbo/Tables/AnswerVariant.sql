CREATE TABLE [dbo].[AnswerVariant] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Content]       VARCHAR (50) NOT NULL,
    [QuestionId]    INT          NOT NULL,
    [IsCorrectAnswer] BIT          NULL,
    [IsDeleted] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

