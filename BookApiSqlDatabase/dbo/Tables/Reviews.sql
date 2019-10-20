CREATE TABLE [dbo].[Reviews] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [HeadLine]   NVARCHAR (200)  NOT NULL,
    [ReviewText] NVARCHAR (2000) NOT NULL,
    [Ratings]    INT             NOT NULL,
    [ReviewerId] INT             NULL,
    [BookId]     INT             NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reviews_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
    CONSTRAINT [FK_Reviews_Reviewers_ReviewerId] FOREIGN KEY ([ReviewerId]) REFERENCES [dbo].[Reviewers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_BookId]
    ON [dbo].[Reviews]([BookId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_ReviewerId]
    ON [dbo].[Reviews]([ReviewerId] ASC);

