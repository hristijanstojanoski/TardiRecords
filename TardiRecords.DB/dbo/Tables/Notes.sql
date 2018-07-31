CREATE TABLE [dbo].[Notes] (
    [id]           UNIQUEIDENTIFIER NOT NULL,
    [noteText]     NVARCHAR (MAX)   NOT NULL,
    [isAlert]      BIT              NOT NULL,
    [createdBy]    NVARCHAR (128)   NOT NULL,
    [createdDate]  DATETIME         NOT NULL,
    [modifyBy]     NVARCHAR (128)   NOT NULL,
    [modifyDate]   DATETIME         NOT NULL,
    [recordListId] UNIQUEIDENTIFIER NULL,
    [machineId]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Notes_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Notes_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Notes_Machine] FOREIGN KEY ([machineId]) REFERENCES [dbo].[Machine] ([id]),
    CONSTRAINT [FK_Notes_RecordList] FOREIGN KEY ([recordListId]) REFERENCES [dbo].[RecordList] ([id])
);

