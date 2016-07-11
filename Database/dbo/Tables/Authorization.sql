CREATE TABLE [dbo].[Authorization] (
    [id]   BIGINT              IDENTITY (1, 1) NOT NULL,
    [uid]  UNIQUEIDENTIFIER    CONSTRAINT [DF_Authorization_uid] DEFAULT (newid()) NOT NULL,
    [node] [sys].[hierarchyid] NOT NULL,
    [path] AS                  (CONVERT([nvarchar](max),[node])) PERSISTED,
    CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED ([id] ASC)
);





