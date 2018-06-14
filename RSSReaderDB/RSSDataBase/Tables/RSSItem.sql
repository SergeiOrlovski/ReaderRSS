﻿CREATE TABLE [dbo].[RSSItem]
(
	[RSSItemId] INT NOT NULL IDENTITY,
	[Title] NVARCHAR(150) NOT NULL,
	[DateOfPublish] DATETIME NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[URL] NVARCHAR(MAX) NOT NULL,
	[SourceRSSId] INT NOT NULL

	CONSTRAINT [PK_RSSItem] PRIMARY KEY ([RSSItemID]),
	CONSTRAINT [FK_RSSItem_To_SourceRSS] FOREIGN KEY ([SourceRSSId]) REFERENCES [SourceRSS]([SourceRSSId]) ON DELETE CASCADE ON UPDATE CASCADE
)