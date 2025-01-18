CREATE TABLE [dbo].[Comments] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Primary Key
    [TopicId] INT NOT NULL, -- Foreign Key to Topics table
    [UserId] NVARCHAR(450) NOT NULL, -- Foreign Key to AspNetUsers table
    [FullName] NVARCHAR(255) NOT NULL, -- Full name of the commenter
    [Text] NVARCHAR(MAX) NOT NULL, -- Body of the comment
    [CreatedOnUtc] DATETIME NOT NULL DEFAULT (GETUTCDATE()), -- Timestamp of creation
    [UpdatedOnUtc] DATETIME NOT NULL DEFAULT (GETUTCDATE()), -- Timestamp of last update
    CONSTRAINT [FK_Comments_Topics] FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topics]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Comments_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id]) ON DELETE CASCADE
);
GO
