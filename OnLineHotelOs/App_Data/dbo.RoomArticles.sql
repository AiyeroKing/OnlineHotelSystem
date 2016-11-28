CREATE TABLE [dbo].[RoomArticles] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [RoomId]      INT            NOT NULL,
    [Subject]     NVARCHAR (MAX) NULL,
    [Body]        NVARCHAR (MAX) NULL,
    [DateCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.RoomArticles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

