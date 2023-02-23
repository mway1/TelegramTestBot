CREATE TABLE [dbo].[Group] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (10) NOT NULL,
    [StudentId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id])
);

