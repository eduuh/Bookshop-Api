CREATE TABLE [dbo].[Reviewers] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Firstname] NVARCHAR (100) NOT NULL,
    [Lastname]  NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Reviewers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

