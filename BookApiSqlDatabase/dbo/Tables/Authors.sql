CREATE TABLE [dbo].[Authors] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (100) NOT NULL,
    [Lastname]  NVARCHAR (100) NOT NULL,
    [CountryId] INT            NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Authors_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Authors_CountryId]
    ON [dbo].[Authors]([CountryId] ASC);

