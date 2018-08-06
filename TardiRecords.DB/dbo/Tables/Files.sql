CREATE TABLE [dbo].[Files] (
    [id]            UNIQUEIDENTIFIER NOT NULL,
    [fullName]      NVARCHAR (100)   NOT NULL,
    [path]          NVARCHAR (250)   NOT NULL,
    [createdBy]     NVARCHAR (128)   NOT NULL,
    [createdDate]   DATETIME         NOT NULL,
    [modifyBy]      NVARCHAR (128)   NOT NULL,
    [modifyDate]    DATETIME         NOT NULL,
    [recordsListId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Files_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Files_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Files_RecordList] FOREIGN KEY ([recordsListId]) REFERENCES [dbo].[RecordList] ([id])
);

