-- =============================================
-- Author:		chrisbauer.career@gmail.com
-- Create date: 2017-12-21
-- Description:	Insert record into server log
-- =============================================
CREATE PROCEDURE ServerLogInsert
	@ServerID			int
	, @MetricID			int
	, @LogDate			datetime
	, @Value			varchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[ServerLog] (
		[ServerID]
        ,[MetricID]
        ,[LogDate]
        ,[Value])
     VALUES (
        @ServerID
        ,@MetricID
        ,@LogDate
        ,@Value
	)

END