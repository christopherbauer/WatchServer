CREATE TABLE [dbo].[Metric] (
    [MetricID]  INT           NOT NULL,
    [ValueType] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Metric] PRIMARY KEY CLUSTERED ([MetricID] ASC)
);

