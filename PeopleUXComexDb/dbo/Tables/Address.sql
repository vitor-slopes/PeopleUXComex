CREATE TABLE [dbo].[Address] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [PersonId] INT            NOT NULL,
    [Street]   NVARCHAR (200) NOT NULL,
    [CEP]      NVARCHAR (8)   NOT NULL,
    [City]     NVARCHAR (100) NOT NULL,
    [State]    NVARCHAR (2)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Persons] ([Id])
);

