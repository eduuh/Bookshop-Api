CREATE TABLE [dbo].[BookCategories] (
    [BooKId]     INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT [PK_BookCategories] PRIMARY KEY CLUSTERED ([BooKId] ASC, [CategoryId] ASC),
    CONSTRAINT [FK_BookCategories_Books_BooKId] FOREIGN KEY ([BooKId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookCategories_CategoryId]
    ON [dbo].[BookCategories]([CategoryId] ASC);

