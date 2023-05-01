CREATE TABLE [dbo].[Test] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [TeacherId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC),   
    FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([Id])
);

