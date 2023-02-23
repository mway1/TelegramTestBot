CREATE TABLE [dbo].[Teacher] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (30) NOT NULL,
    [LastName]  VARCHAR (30) NULL,
    [SurName]   VARCHAR (30) NOT NULL,
    [Email]     VARCHAR (30) NOT NULL,
    [Login]     VARCHAR (30) NOT NULL,
    [Password]  VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

