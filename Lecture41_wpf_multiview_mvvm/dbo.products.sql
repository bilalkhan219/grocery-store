CREATE TABLE [dbo].[products] (
    [Id]       INT        NOT NULL,
    [Name]     NCHAR (10) NULL,
    [Price]    INT        NULL,
    [Quantity] INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
