CREATE TABLE [dbo].[Schools] (
    [id]   BIGINT           IDENTITY (1, 1) NOT NULL,
    [uid]  UNIQUEIDENTIFIER CONSTRAINT [DF_Schools_uid] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED ([id] ASC)
);

