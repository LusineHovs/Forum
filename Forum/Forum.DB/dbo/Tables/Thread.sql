CREATE TABLE [dbo].[Thread] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ThreadName]  NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [TopicId]     INT            NOT NULL,
    CONSTRAINT [PK__Thread__3214EC07DD4F444A] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Thread__TopicId__3B75D760] FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topic] ([Id])
);

