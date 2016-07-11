CREATE TABLE [dbo].[Districts] (
    [id]   BIGINT           IDENTITY (1, 1) NOT NULL,
    [uid]  UNIQUEIDENTIFIER CONSTRAINT [DF_Districts_uid] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED ([id] ASC)
);

