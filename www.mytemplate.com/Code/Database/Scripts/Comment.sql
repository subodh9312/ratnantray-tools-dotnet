USE [MyTemplate]
GO

/****** Object:  Table [dbo].[Comment]    Script Date: 11/04/2012 11:52:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comment]') AND type in (N'U'))
DROP TABLE [dbo].[Comment]
GO

USE [MyTemplate]
GO

/****** Object:  Table [dbo].[Comment]    Script Date: 11/04/2012 11:52:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommentText] [varchar](200) NOT NULL,
	[EntityId] [int] NOT NULL,
	[EntityType] [int] NOT NULL,
	[SubmitDate] [date] NOT NULL,
	[SubmitterName] [varchar](80) NOT NULL,
	[SubmitterEmail] [varchar](200) NOT NULL,
	[SubmitterWebsite] [varchar](120) NULL,
	[CreatedBy] [varchar](80) NULL,
	[CreatedOn] [date] NULL,
	[LastModeratedBy] [varchar](80) NULL,
	[LastModeratedOn] [date] NULL,
	[Milestone] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

COMMIT