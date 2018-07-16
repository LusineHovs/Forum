CREATE TABLE [dbo].[Topic] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [TopicName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED ([Id] ASC)
);

