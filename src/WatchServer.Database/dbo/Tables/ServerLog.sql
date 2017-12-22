CREATE TABLE [dbo].[ServerLog] (
    [LogID]    INT           IDENTITY (1, 1) NOT NULL,
    [ServerID] INT           NOT NULL,
    [MetricID] INT           NOT NULL,
    [LogDate]  DATETIME      NOT NULL,
    [Value]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ServerLog] PRIMARY KEY NONCLUSTERED ([LogID] ASC),
    CONSTRAINT [FK_ServerLog_Metric] FOREIGN KEY ([MetricID]) REFERENCES [dbo].[Metric] ([MetricID]),
    CONSTRAINT [FK_ServerLog_Server] FOREIGN KEY ([ServerID]) REFERENCES [dbo].[Server] ([ServerID]),
    CONSTRAINT [UQ_ServerLog] UNIQUE CLUSTERED ([ServerID] ASC, [MetricID] ASC, [LogDate] DESC)
);



