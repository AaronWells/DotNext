CREATE TABLE [dbo].[UserAuthorization] (
    [user_id]          BIGINT      NOT NULL,
    [authorization_id] BIGINT      NOT NULL,
    [permissions]      VARBINARY(50) CONSTRAINT [DF_UserAuthorization_permissions] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserAuthorization] PRIMARY KEY CLUSTERED ([user_id] ASC, [authorization_id] ASC),
    CONSTRAINT [FK_UserAuthorization_Authorization] FOREIGN KEY ([authorization_id]) REFERENCES [dbo].[Authorization] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserAuthorization_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id]) ON DELETE CASCADE
);

