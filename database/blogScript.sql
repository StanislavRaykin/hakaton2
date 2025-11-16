USE [Hakaton]
GO

/****** Object:  Table [dbo].[Blogs]    Script Date: 16.11.2025 ã. 11:34:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Blogs]') AND type in (N'U'))
DROP TABLE [dbo].[Blogs]
GO

/****** Object:  Table [dbo].[Blogs]    Script Date: 16.11.2025 ã. 11:34:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Blogs](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Published] [datetime] NULL,
	[Category] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Slug] [nvarchar](50) NULL,
	[ContentHtml] [nvarchar](350) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO