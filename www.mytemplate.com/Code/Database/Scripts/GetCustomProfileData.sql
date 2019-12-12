USE [MyTemplate]
GO

/****** Object:  StoredProcedure [dbo].[getCustomProfileData]    Script Date: 11/03/2012 11:49:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getCustomProfileData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[getCustomProfileData]
GO

USE [MyTemplate]
GO

/****** Object:  StoredProcedure [dbo].[getCustomProfileData]    Script Date: 11/03/2012 11:49:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getCustomProfileData]
    @ApplicationName      nvarchar(256),
    @UserName             varchar(256),
	@FirstName			  varchar(80)		OUTPUT,
	@LastName			  varchar(80)		OUTPUT,
	@Education			  varchar(200)		OUTPUT,
	@Organisation		  varchar(200)		OUTPUT,
	@CellNo1			  varchar(20)		OUTPUT,
	@CellNo2			  varchar(20)		OUTPUT,
	@DirectNo			  varchar(20)		OUTPUT,
	@SwitchBoardNo		  varchar(20)		OUTPUT,
	@Extension			  varchar(20)		OUTPUT,
	@City				  varchar(80)		OUTPUT
AS
DECLARE	@ApplicationId uniqueidentifier
SET		@ApplicationId = NULL

-- Get the AppId
EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

-- Return data for the requested user in the application
SELECT
	@FirstName	= FirstName,
	@LastName	= LastName,
	@Organisation = Organisation,
	@Education = Education,
	@CellNo1 = CellNo1,
	@CellNo2 = CellNo2,
	@DirectNo = DirectNo,
	@SwitchBoardNo = SwitchBoardNo,
	@Extension = Extension,
	@City = City
FROM
	dbo.aspnet_Custom_UserDetails userDetails,
    dbo.vw_aspnet_Users users
WHERE
	users.ApplicationId	= @ApplicationId
AND
	users.UserName		= @UserName
AND
	users.UserId		= userDetails.UserId

GO

COMMIT