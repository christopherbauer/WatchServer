CREATE TABLE [dbo].[Server] (
    [ServerID]    INT           NOT NULL,
    [Name]        VARCHAR (100) NULL,
    [Description] VARCHAR (500) NULL,
    CONSTRAINT [PK_Server] PRIMARY KEY CLUSTERED ([ServerID] ASC)
);

