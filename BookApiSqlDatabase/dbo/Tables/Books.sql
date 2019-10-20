CREATE TABLE [dbo].[Books] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [isbn]          NVARCHAR (10)  NOT NULL,
    [Title]         NVARCHAR (200) NOT NULL,
    [DatePublished] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);

