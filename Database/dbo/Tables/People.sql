CREATE TABLE [dbo].[People] (
    [id]         BIGINT                                                         IDENTITY (1, 1) NOT NULL,
    [uid]        UNIQUEIDENTIFIER                                               CONSTRAINT [DF_People_uid] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [first_name] NVARCHAR (50)                                                  NOT NULL,
    [last_name]  NVARCHAR (50)                                                  NOT NULL,
    [gender]     CHAR (1)                                                       NOT NULL,
    [email]      NVARCHAR (50) MASKED WITH (FUNCTION = 'email()')               NOT NULL,
    [ssn]        NCHAR (11) MASKED WITH (FUNCTION = 'partial(0, "XXX-XX-", 4)') NOT NULL,
    [race]       NVARCHAR (50)                                                  NOT NULL,
    [address]    NVARCHAR (50) MASKED WITH (FUNCTION = 'default()')             NOT NULL,
    [city]       NVARCHAR (50)                                                  NOT NULL,
    [state]      NVARCHAR (50)                                                  NOT NULL,
    [country]    CHAR (2)                                                       NOT NULL,
    [birthdate]  DATE                                                           NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([id] ASC)
);

