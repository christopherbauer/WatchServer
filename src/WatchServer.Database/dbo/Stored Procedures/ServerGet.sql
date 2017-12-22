-- =============================================
-- Author:		chrisbauer.career@gmail.com
-- Create date: 2017-12-21
-- Description:	Get server record
-- =============================================
CREATE PROCEDURE ServerGet
	@ServerID				int
AS
BEGIN

	SET NOCOUNT ON;
	
	select ServerID, Name, [Description]
	from [Server]
	where
		ServerID=@ServerID

END