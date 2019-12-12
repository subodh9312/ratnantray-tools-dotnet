USE [MyTemplate]
GO

/****** Object:  StoredProcedure [dbo].[setCustomProfileData]    Script Date: 11/03/2012 11:51:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[setCustomProfileData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[setCustomProfileData]
GO

USE [MyTemplate]
GO

/****** Object:  StoredProcedure [dbo].[setCustomProfileData]    Script Date: 11/03/2012 11:51:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[setCustomProfileData]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
	@IsUserAnonymous	  bit,
	@FirstName			  varchar(80),
	@LastName			  varchar(80),
	@Education			  varchar(200),
	@Organisation		  varchar(200),
	@ProfilePicture		  IMAGE,
	@CellNo1			  varchar(20),
	@CellNo2			  varchar(20),
	@DirectNo			  varchar(20),
	@SwitchBoardNo		  varchar(20),
	@Extension			  varchar(20),
	@City				  varchar(80)
AS

DECLARE	@ApplicationId uniqueidentifier
SET		@ApplicationId = NULL

DECLARE @CurrentUtcDate datetime
SET     @CurrentUtcDate = getutcdate()

-- Get the AppId
EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

-- Create user if needed
DECLARE @UserId uniqueidentifier

SELECT	
	@UserId = UserId
FROM	
	dbo.vw_aspnet_Users
WHERE	
	ApplicationId	= @ApplicationId
AND		
	LoweredUserName = LOWER(@UserName)

IF(@UserId IS NULL)
	EXEC dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, @IsUserAnonymous, @CurrentUtcDate, @UserId OUTPUT

-- Either insert a new row of data, or update a pre-existing row
IF EXISTS (SELECT 1 FROM dbo.aspnet_Custom_UserDetails WHERE UserId = @UserId) 
	BEGIN 
		UPDATE 
			dbo.aspnet_Custom_UserDetails
		SET	FirstName		= @FirstName,
			LastName		= @LastName,
			Organisation	= @Organisation,
			Education		= @Education,
			ProfilePicture	= @ProfilePicture,
			CellNo1			= @CellNo1,
			CellNo2			= @CellNo2,
			DirectNo		= @DirectNo,
			SwitchBoardNo	= @SwitchBoardNo,
			Extension		= @Extension,
			City			= @City
		WHERE 
			UserId = @UserId
	END
ELSE
	BEGIN
		INSERT INTO 
			dbo.aspnet_Custom_UserDetails (
			UserId, 
			FirstName, 
			LastName, 
			Organisation, 
			Education,
			ProfilePicture,
			CellNo1,
			CellNo2,
			DirectNo,
			SwitchBoardNo,
			Extension,
			City)
		VALUES (
			@UserId, 
			@FirstName, 
			@LastName, 
			@Organisation, 
			@Education,
			@ProfilePicture,
			@CellNo1,
			@CellNo2,
			@DirectNo,
			@SwitchBoardNo,
			@Extension,
			@City)
	END
GO

COMMIT