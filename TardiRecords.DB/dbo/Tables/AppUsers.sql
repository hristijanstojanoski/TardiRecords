CREATE TABLE [dbo].[AppUsers] (
    [id]           UNIQUEIDENTIFIER NOT NULL,
    [aspNetUserId] NVARCHAR (128)   NOT NULL,
    [firstName]    NVARCHAR (150)   NOT NULL,
    [lastName]     NVARCHAR (250)   NOT NULL,
    [position]     NVARCHAR (250)   NULL,
    [createdBy]    NVARCHAR (128)   NOT NULL,
    [createdDate]  DATETIME         NOT NULL,
    [modifyBy]     NVARCHAR (128)   NOT NULL,
    [modifyDate]   DATETIME         NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_AppUsers_AspNetUsers] FOREIGN KEY ([aspNetUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

