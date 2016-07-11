CREATE TABLE [dbo].[Users] (
    [id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [identifier] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC)
);

