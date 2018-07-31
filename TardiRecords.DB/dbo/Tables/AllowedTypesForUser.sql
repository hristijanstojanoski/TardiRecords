CREATE TABLE [dbo].[AllowedTypesForUser] (
    [id]           UNIQUEIDENTIFIER NOT NULL,
    [recordTypeId] UNIQUEIDENTIFIER NOT NULL,
    [userId]       UNIQUEIDENTIFIER NOT NULL,
    [createdBy]    UNIQUEIDENTIFIER NOT NULL,
    [createdDate]  DATETIME         NOT NULL,
    [modifyBy]     UNIQUEIDENTIFIER NOT NULL,
    [modifyDate]   DATETIME         NOT NULL,
    CONSTRAINT [PK_AllowedTypesForUser] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_AllowedTypesForUser_RecordType] FOREIGN KEY ([recordTypeId]) REFERENCES [dbo].[RecordType] ([id])
);

