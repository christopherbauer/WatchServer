CREATE TABLE [dbo].[ServerHistory] (
    [ServerHistoryID] INT           NOT NULL,
    [ServerID]        INT           NOT NULL,
    [Description]     XML           NOT NULL,
    [ChangeDate]      DATETIME      NOT NULL,
    [ChangeBy]        VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ServerHistory] PRIMARY KEY NONCLUSTERED ([ServerHistoryID] ASC),
    CONSTRAINT [FK_ServerHistory_Server] FOREIGN KEY ([ServerID]) REFERENCES [dbo].[Server] ([ServerID]),
    CONSTRAINT [UQ_ServerHistory] UNIQUE CLUSTERED ([ServerID] ASC, [ChangeDate] DESC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ServerHistory]
    ON [dbo].[ServerHistory]([ServerID] ASC);

