CREATE TABLE [dbo].[Student] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (30) NOT NULL,
    [LastName]   VARCHAR (30) NULL,
    [SurName]    VARCHAR (30) NOT NULL,
    [Username]   VARCHAR (30) NOT NULL,
    [Attendance] BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

