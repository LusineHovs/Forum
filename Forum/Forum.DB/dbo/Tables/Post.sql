CREATE TABLE [dbo].[Post] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [UserId]       NVARCHAR (128) NOT NULL,
    [ThreadId]    INT            NOT NULL,
	[Date] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ThreadId] FOREIGN KEY ([ThreadId]) REFERENCES [dbo].[Thread] ([Id]),
    CONSTRAINT [FK_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);
GO




