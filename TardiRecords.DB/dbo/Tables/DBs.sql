CREATE TABLE [dbo].[DBs] (
    [id]           UNIQUEIDENTIFIER NOT NULL,
    [recordListId] UNIQUEIDENTIFIER NOT NULL,
    [isActive]     BIT              NOT NULL,
    [isBackup]     BIT              NOT NULL,
    [isArchived]   BIT              NOT NULL,
    [phisicalPath] NVARCHAR (250)   NOT NULL,
    [sqlType]      INT              NOT NULL,
    [sqlVersion]   INT              NOT NULL,
    [createdBy]    NVARCHAR (128)   NOT NULL,
    [createdDate]  DATETIME         NOT NULL,
    [modifyBy]     NVARCHAR (128)   NOT NULL,
    [modifyDate]   DATETIME         NOT NULL,
    CONSTRAINT [PK_DBs] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_DBs_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_DBs_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

