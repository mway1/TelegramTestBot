CREATE TABLE [dbo].[Testing_Student] (
    [Id]          INT  IDENTITY (1, 1) NOT NULL,
    [CountAnswers] INT NOT NULL DEFAULT(0),
    [StudentId] INT NOT NULL,
    [TestingId] INT NOT NULL,
    [IsAttendance] BIT NOT NULL DEFAULT(0),
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([TestingId]) REFERENCES [dbo].[Testing] ([Id]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id])
  );