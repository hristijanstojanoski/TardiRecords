CREATE TABLE [dbo].[BackupLocations] (
    [id]          UNIQUEIDENTIFIER NOT NULL,
    [machineId]   UNIQUEIDENTIFIER NOT NULL,
    [dbId]        UNIQUEIDENTIFIER NOT NULL,
    [createdBy]   NVARCHAR (128)   NOT NULL,
    [createdDate] DATETIME         NOT NULL,
    [modifyBy]    NVARCHAR (128)   NOT NULL,
    [modifyDate]  DATETIME         NOT NULL,
    CONSTRAINT [PK_BackupLocations] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_BackupLocations_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_BackupLocations_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_BackupLocations_DBs] FOREIGN KEY ([dbId]) REFERENCES [dbo].[DBs] ([id]),
    CONSTRAINT [FK_BackupLocations_Machine] FOREIGN KEY ([machineId]) REFERENCES [dbo].[Machine] ([id])
);

