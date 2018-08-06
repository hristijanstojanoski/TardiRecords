CREATE TABLE [dbo].[MachinesInUse] (
    [id]          UNIQUEIDENTIFIER NOT NULL,
    [machineId]   UNIQUEIDENTIFIER NOT NULL,
    [userid]      NVARCHAR (128)   NOT NULL,
    [dateFrom]    DATETIME         NOT NULL,
    [dateTo]      DATETIME         NULL,
    [notes]       NVARCHAR (500)   NULL,
    [createdBy]   NVARCHAR (128)   NOT NULL,
    [createdDate] DATETIME         NOT NULL,
    [modifyBy]    NVARCHAR (128)   NOT NULL,
    [modifyDate]  DATETIME         NOT NULL,
    CONSTRAINT [PK_MachinesInUse] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_MachinesInUse_AspNetUsers] FOREIGN KEY ([userid]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_MachinesInUse_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_MachinesInUse_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_MachinesInUse_Machine] FOREIGN KEY ([machineId]) REFERENCES [dbo].[Machine] ([id])
);

