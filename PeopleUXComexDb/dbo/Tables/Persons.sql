CREATE TABLE [dbo].[Persons] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (100) NOT NULL,
    [Phone] NVARCHAR (15)  NULL,
    [CPF]   NVARCHAR (11)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

