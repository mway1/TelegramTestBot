CREATE TABLE [dbo].[TypeOfQuestion] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (25) NOT NULL,
    [IsDeleted] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

