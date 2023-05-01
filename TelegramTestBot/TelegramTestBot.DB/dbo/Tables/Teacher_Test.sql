CREATE TABLE [dbo].[Teacher_Test] (
    [Id]          INT  IDENTITY (1, 1) NOT NULL,
    [TestId]   INT  NOT NULL,
    [TeacherId] INT  NOT NULL,
    [isDeleted] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([Id]),
    FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([Id]),
  );
