USE [MyTemplate]
GO

/****** Object:  Table [dbo].[Feedback]    Script Date: 11/15/2012 06:45:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedback]') AND type in (N'U'))
DROP TABLE [dbo].[Feedback]
GO

USE [MyTemplate]
GO

/****** Object:  Table [dbo].[Feedback]    Script Date: 11/15/2012 06:45:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Feedback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[City] [varchar](80) NOT NULL,
	[EmailAddress] [varchar](80) NOT NULL,
	[ContactNo] [varchar](20) NULL,
	[OverallExperience] [varchar](50) NULL,
	[DissatisfiedWith] [varchar](200) NULL,
	[CorrectIt] [varchar](500) NULL,
	[Rating] [varchar](50) NULL,
	[WebsiteComparison] [varchar](100) NULL,
	[Suggestions] [text] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


COMMIT