﻿CREATE TABLE [dbo].[SourceRSS]
(
	[SourceRSSId] INT NOT NULL IDENTITY,
	[URL] NVARCHAR(MAX) NOT NULL,
	[NameOfSource] NVARCHAR(MAX)

	CONSTRAINT [PK_SourceRSS] PRIMARY KEY ([SourceRSSId])
)