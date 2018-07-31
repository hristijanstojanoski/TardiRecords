CREATE TABLE [dbo].[RecordList] (
    [id]           UNIQUEIDENTIFIER NOT NULL,
    [title]        NVARCHAR (150)   NOT NULL,
    [createdBy]    NVARCHAR (128)   NOT NULL,
    [createdDate]  DATETIME         NOT NULL,
    [modifyBy]     NVARCHAR (128)   NOT NULL,
    [modifyDate]   DATETIME         NOT NULL,
    [recordTypeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_RecordList] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_RecordList_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_RecordList_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

