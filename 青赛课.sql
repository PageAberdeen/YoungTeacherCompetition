USE [YoungTeacherCompetition]
GO
/****** Object:  Table [dbo].[TUserInfo]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TUserInfo](
	[UserNo] [int] IDENTITY(1,1) NOT NULL,
	[UserAccountID] [nvarchar](50) NOT NULL,
	[UserID] [nchar](200) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[UserRole] [nchar](50) NOT NULL,
	[SchoolInfoID] [int] NULL,
	[ReviewID] [int] NULL,
 CONSTRAINT [PK_TUserInfo] PRIMARY KEY CLUSTERED 
(
	[UserNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TUserInfo] ON
INSERT [dbo].[TUserInfo] ([UserNo], [UserAccountID], [UserID], [UserName], [UserRole], [SchoolInfoID], [ReviewID]) VALUES (1, N'zhangshuo2', N'zhangshuo2                                                                                                                                                                                              ', N'张硕', N'申报人                                               ', 1, 0)
SET IDENTITY_INSERT [dbo].[TUserInfo] OFF
/****** Object:  Table [dbo].[TSubject]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSubject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nchar](200) NULL,
 CONSTRAINT [PK_TSubject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TSubject] ON
INSERT [dbo].[TSubject] ([SubjectID], [SubjectName]) VALUES (1, N'数学                                                                                                                                                                                                      ')
INSERT [dbo].[TSubject] ([SubjectID], [SubjectName]) VALUES (2, N'物理                                                                                                                                                                                                      ')
INSERT [dbo].[TSubject] ([SubjectID], [SubjectName]) VALUES (3, N'化学                                                                                                                                                                                                      ')
INSERT [dbo].[TSubject] ([SubjectID], [SubjectName]) VALUES (4, N'地理                                                                                                                                                                                                      ')
SET IDENTITY_INSERT [dbo].[TSubject] OFF
/****** Object:  Table [dbo].[TSchoolInfo]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSchoolInfo](
	[SchoolID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictID] [int] NULL,
	[SchoolGroupID] [int] NULL,
	[SchoolName] [nchar](400) NOT NULL,
 CONSTRAINT [PK_TSchoolInfo] PRIMARY KEY CLUSTERED 
(
	[SchoolID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TSchoolInfo] ON
INSERT [dbo].[TSchoolInfo] ([SchoolID], [DistrictID], [SchoolGroupID], [SchoolName]) VALUES (1, 1, 1, N'鱼峰区第一小学                                                                                                                                                                                                                                                                                                                                                                                                         ')
INSERT [dbo].[TSchoolInfo] ([SchoolID], [DistrictID], [SchoolGroupID], [SchoolName]) VALUES (2, 1, 2, N'鱼峰区第二中学                                                                                                                                                                                                                                                                                                                                                                                                         ')
INSERT [dbo].[TSchoolInfo] ([SchoolID], [DistrictID], [SchoolGroupID], [SchoolName]) VALUES (3, 2, 2, N'柳北区第二中学                                                                                                                                                                                                                                                                                                                                                                                                         ')
SET IDENTITY_INSERT [dbo].[TSchoolInfo] OFF
/****** Object:  Table [dbo].[TSchoolGroup]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TSchoolGroup](
	[SchoolGroupID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolGroupName] [nchar](200) NULL,
 CONSTRAINT [PK_TSchoolGroupInfo] PRIMARY KEY CLUSTERED 
(
	[SchoolGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TSchoolGroup] ON
INSERT [dbo].[TSchoolGroup] ([SchoolGroupID], [SchoolGroupName]) VALUES (1, N'小学                                                                                                                                                                                                      ')
INSERT [dbo].[TSchoolGroup] ([SchoolGroupID], [SchoolGroupName]) VALUES (2, N'初中                                                                                                                                                                                                      ')
INSERT [dbo].[TSchoolGroup] ([SchoolGroupID], [SchoolGroupName]) VALUES (3, N'高中                                                                                                                                                                                                      ')
INSERT [dbo].[TSchoolGroup] ([SchoolGroupID], [SchoolGroupName]) VALUES (4, N'高职                                                                                                                                                                                                      ')
SET IDENTITY_INSERT [dbo].[TSchoolGroup] OFF
/****** Object:  Table [dbo].[TReview]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TReview](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[ReviewMode] [nchar](100) NULL,
	[AllIDstr] [nvarchar](max) NULL,
 CONSTRAINT [PK_TReview] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEntriesInfo]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEntriesInfo](
	[EntriesID] [int] IDENTITY(1,1) NOT NULL,
	[EnrolInfoID] [int] NOT NULL,
	[UserID] [int] NULL,
	[EnrolScore] [nchar](10) NULL,
	[EnrolComment] [ntext] NULL,
 CONSTRAINT [PK_TEntriesInfo] PRIMARY KEY CLUSTERED 
(
	[EntriesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEnrolInfo]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEnrolInfo](
	[EnrollID] [int] IDENTITY(1,1) NOT NULL,
	[EnrolName] [nchar](10) NOT NULL,
	[EnrolSex] [nchar](10) NULL,
	[EnrolBirthday] [nchar](50) NULL,
	[EnrolWorkYear] [nchar](10) NULL,
	[EnrolTel] [nchar](100) NULL,
	[EnrolTeacherTitle] [nchar](100) NULL,
	[EnrolSubject] [int] NULL,
	[SchoolID] [int] NULL,
	[EntriesName] [nchar](200) NULL,
	[EntriesURL] [nchar](200) NULL,
 CONSTRAINT [PK_TEnrolInfo] PRIMARY KEY CLUSTERED 
(
	[EnrollID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TEnrolInfo] ON
INSERT [dbo].[TEnrolInfo] ([EnrollID], [EnrolName], [EnrolSex], [EnrolBirthday], [EnrolWorkYear], [EnrolTel], [EnrolTeacherTitle], [EnrolSubject], [SchoolID], [EntriesName], [EntriesURL]) VALUES (1, N'姓名        ', N'女         ', N'1988                                              ', N'6         ', N'18778823951                                                                                         ', N'中教一级                                                                                                ', 1, 1, NULL, NULL)
INSERT [dbo].[TEnrolInfo] ([EnrollID], [EnrolName], [EnrolSex], [EnrolBirthday], [EnrolWorkYear], [EnrolTel], [EnrolTeacherTitle], [EnrolSubject], [SchoolID], [EntriesName], [EntriesURL]) VALUES (2, N'111       ', N'男         ', N'11                                                ', N'22        ', N'222                                                                                                 ', N'222                                                                                                 ', 1, 1, NULL, NULL)
INSERT [dbo].[TEnrolInfo] ([EnrollID], [EnrolName], [EnrolSex], [EnrolBirthday], [EnrolWorkYear], [EnrolTel], [EnrolTeacherTitle], [EnrolSubject], [SchoolID], [EntriesName], [EntriesURL]) VALUES (3, N'          ', N'男         ', N'                                                  ', N'          ', N'                                                                                                    ', N'                                                                                                    ', 1, 1, NULL, NULL)
INSERT [dbo].[TEnrolInfo] ([EnrollID], [EnrolName], [EnrolSex], [EnrolBirthday], [EnrolWorkYear], [EnrolTel], [EnrolTeacherTitle], [EnrolSubject], [SchoolID], [EntriesName], [EntriesURL]) VALUES (4, N'3333      ', N'男         ', N'                                                  ', N'          ', N'                                                                                                    ', N'                                                                                                    ', 1, 1, NULL, NULL)
INSERT [dbo].[TEnrolInfo] ([EnrollID], [EnrolName], [EnrolSex], [EnrolBirthday], [EnrolWorkYear], [EnrolTel], [EnrolTeacherTitle], [EnrolSubject], [SchoolID], [EntriesName], [EntriesURL]) VALUES (5, N'55555     ', N'男         ', N'                                                  ', N'          ', N'                                                                                                    ', N'                                                                                                    ', 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TEnrolInfo] OFF
/****** Object:  Table [dbo].[TDistrictInfo]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDistrictInfo](
	[DistrictID] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [nchar](400) NULL,
 CONSTRAINT [PK_TDistrictInfo] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TDistrictInfo] ON
INSERT [dbo].[TDistrictInfo] ([DistrictID], [DistrictName]) VALUES (1, N'柳州鱼峰区                                                                                                                                                                                                                                                                                                                                                                                                           ')
INSERT [dbo].[TDistrictInfo] ([DistrictID], [DistrictName]) VALUES (2, N'柳州柳北区                                                                                                                                                                                                                                                                                                                                                                                                           ')
SET IDENTITY_INSERT [dbo].[TDistrictInfo] OFF
/****** Object:  Table [dbo].[TDeclare]    Script Date: 05/31/2017 10:12:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDeclare](
	[DeclareID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolID] [int] NULL,
	[DeclareNum] [int] NULL,
 CONSTRAINT [PK_TDeclare] PRIMARY KEY CLUSTERED 
(
	[DeclareID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
