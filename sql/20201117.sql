USE [Test]
GO
/****** Object:  Table [dbo].[Qs_Category]    Script Date: 2020/11/14 9:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qs_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionType] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[SortNumber] [int] NULL,
	[RowStatus] [int] NOT NULL,
 CONSTRAINT [PK_qs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qs_QsInfo]    Script Date: 2020/11/14 9:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qs_QsInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[TypeId] [int] NULL,
	[Note] [nvarchar](max) NULL,
	[SortNumber] [int] NULL,
	[RowStatus] [int] NULL,
 CONSTRAINT [PK_Qs_QsInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qs_Record]    Script Date: 2020/11/14 9:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qs_Record](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QsInfoId] [int] NULL,
	[CategoryId] [int] NULL,
	[TypeId] [int] NULL,
	[Result] [nvarchar](50) NULL,
	[Note] [nvarchar](max) NULL,
	[BusinessName] [nvarchar](50) NULL,
	[BusinessTown] [nvarchar](50) NULL,
	[BusinessAddress] [nvarchar](200) NULL,
	[BusinessTel] [nvarchar](50) NULL,
	[BusinessMail] [nvarchar](200) NULL,
	[AddTime] [datetime] NULL,
	[AddMemberId] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateMemberId] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[RowStatus] [int] NULL,
 CONSTRAINT [PK_Qs_Record] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qs_RecordFile]    Script Date: 2020/11/14 9:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qs_RecordFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecordId] [int] NOT NULL,
	[FilePath] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Qs_RecordFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qs_Type]    Script Date: 2020/11/14 9:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qs_Type](
	[Id] [int] NULL,
	[TypeName] [nvarchar](50) NULL,
	[Note] [nvarchar](max) NULL,
	[SortNumber] [int] NULL,
	[RowStatus] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
