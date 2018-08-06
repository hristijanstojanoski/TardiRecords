CREATE TABLE [dbo].[RecordType] (
    [id]          UNIQUEIDENTIFIER NOT NULL,
    [name]        NVARCHAR (250)   NOT NULL,
    [subType]     INT              NOT NULL,
    [isEnabled]   BIT              NOT NULL,
    [isDeleted]   BIT              NOT NULL,
    [createdBy]   NVARCHAR (128)   NOT NULL,
    [createdDate] DATETIME         NOT NULL,
    [modifiedBy]  NVARCHAR (128)   NOT NULL,
    [modifyDate]  DATETIME         NOT NULL,
    CONSTRAINT [PK_RecordType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_RecordType_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_RecordType_AspNetUsers_ModifiedBy] FOREIGN KEY ([modifiedBy]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

