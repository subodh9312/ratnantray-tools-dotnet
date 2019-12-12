USE [MyTemplate] 
GO

/****** Object:  Index [Comment_Milestone]    Script Date: 12/22/2012 10:51:46 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Comment]') AND name = N'Comment_Milestone')
DROP INDEX [Comment_Milestone] ON [dbo].[Comment] WITH ( ONLINE = OFF )
GO

USE [MyTemplate]
GO

/****** Object:  Index [Comment_Milestone]    Script Date: 12/22/2012 10:51:46 ******/
CREATE NONCLUSTERED INDEX [Comment_Milestone] ON [dbo].[Comment] 
(
	[Milestone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

COMMIT