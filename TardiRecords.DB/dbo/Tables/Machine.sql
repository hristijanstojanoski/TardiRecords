CREATE TABLE [dbo].[Machine] (
    [id]             UNIQUEIDENTIFIER NOT NULL,
    [name]           NVARCHAR (150)   NOT NULL,
    [UID]            NVARCHAR (50)    NOT NULL,
    [purpose]        NVARCHAR (250)   NOT NULL,
    [isActive]       BIT              NOT NULL,
    [isBroken]       BIT              NOT NULL,
    [purchaseDate]   DATETIME         NOT NULL,
    [officeLocation] INT              NULL,
    [subType]        INT              NULL,
    [createdBy]      NVARCHAR (128)   NOT NULL,
    [createdDate]    DATETIME         NOT NULL,
    [modifyBy]       NVARCHAR (128)   NOT NULL,
    [modifyDate]     DATETIME         NOT NULL,
    CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Machine_AspNetUsers_CreatedBy] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Machine_AspNetUsers_ModifyBy] FOREIGN KEY ([modifyBy]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

