-- =============================================
-- Author:		chrisbauer.career@gmail.com
-- Create date: 2017-12-21
-- Description:	Insert or update server record
-- =============================================
CREATE PROCEDURE ServerInsertUpdate
	@ServerID				int=null
	, @Name					varchar(100)=null
	, @Description			varchar(500)=null
AS
BEGIN

	SET NOCOUNT ON;

	declare @ServerStatus int = (select (case when Name = @Name then 1 else 0 end) from [Server] where ServerID=@ServerID)

	if (@ServerID = null and @ServerStatus = null)
	begin

		begin transaction lock

		declare @NewServerID int = (select max(ServerID) from [Server]) + 1

		insert into [Server] (ServerID, Name, [Description])
		values (@NewServerID, @Name, @Description)

		commit transaction lock

	end

	if(@ServerID != null and @ServerStatus = 1)
	begin

		update [Server]
		set Name=@Name, [Description]=@Description
		where
			ServerID=@ServerID

	end

END