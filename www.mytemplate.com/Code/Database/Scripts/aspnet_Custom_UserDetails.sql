USE [MyTemplate]
GO

/****** Object:  Table [dbo].[aspnet_Custom_UserDetails]    Script Date: 11/03/2012 11:52:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Custom_UserDetails]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Custom_UserDetails]
GO

USE [MyTemplate]
GO

/****** Object:  Table [dbo].[aspnet_Custom_UserDetails]    Script Date: 11/03/2012 11:52:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[aspnet_Custom_UserDetails](
	[UserId] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](80) NULL,
	[LastName] [varchar](80) NULL,
	[Education] [varchar](200) NULL,
	[Organisation] [varchar](200) NULL,
	[ProfilePicture] [image] NULL,
	[CellNo1] [varchar](20) NULL,
	[CellNo2] [varchar](20) NULL,
	[DirectNo] [varchar](20) NULL,
	[SwitchBoardNo] [varchar](20) NULL,
	[Extension] [varchar](20) NULL,
	[City] [varchar](80) NULL
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

COMMIT