﻿CREATE TABLE [dbo].[Teacher] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Firstname] VARCHAR (30) NOT NULL,
    [Lastname]  VARCHAR (30) NULL,
    [Surname]   VARCHAR (30) NOT NULL,
    [Email]     VARCHAR (30) NOT NULL,
    [Login]     VARCHAR (30) NOT NULL,
    [Password]  VARCHAR (256) NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT(0),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

