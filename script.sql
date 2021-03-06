USE [master]
GO
/****** Object:  Database [TrungNgaApp]    Script Date: 6/14/2017 9:03:58 AM ******/
CREATE DATABASE [TrungNgaApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrungNgaApp', FILENAME = N'D:\SQL Server DB\TrungNgaApp.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TrungNgaApp_log', FILENAME = N'D:\SQL Server DB\TrungNgaApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TrungNgaApp] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrungNgaApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrungNgaApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrungNgaApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrungNgaApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrungNgaApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrungNgaApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrungNgaApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrungNgaApp] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TrungNgaApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrungNgaApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrungNgaApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrungNgaApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrungNgaApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrungNgaApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrungNgaApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrungNgaApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrungNgaApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrungNgaApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrungNgaApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrungNgaApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrungNgaApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrungNgaApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrungNgaApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrungNgaApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrungNgaApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrungNgaApp] SET  MULTI_USER 
GO
ALTER DATABASE [TrungNgaApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrungNgaApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrungNgaApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrungNgaApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TrungNgaApp]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransportId] [int] NOT NULL,
	[SeatId] [int] NOT NULL,
	[BookInfoId] [int] NULL,
	[CreatedById] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsCancelled] [bit] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookInfo]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PassengerName] [nvarchar](100) NULL,
	[PassengerPhoneNo] [nvarchar](100) NULL,
	[PickUpLocation] [nvarchar](max) NULL,
	[NbOfSeats] [int] NOT NULL,
	[PaymentStatusId] [int] NOT NULL,
 CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookLog]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
	[LogContent] [ntext] NULL,
 CONSTRAINT [PK_BookLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Coach]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coach](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CoachTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Coach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoachType]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoachType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_CoachType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[EmployeeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_EmployeeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seat]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CoachType] [int] NOT NULL CONSTRAINT [DF_Seat_CoachType]  DEFAULT ((1)),
	[IsOnLeftSide] [bit] NOT NULL CONSTRAINT [DF_Seat_IsOnLeftSide]  DEFAULT ((1)),
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transport]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoachId] [int] NOT NULL,
	[DriverId] [int] NOT NULL,
	[AssistantId] [int] NULL,
	[Day] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Hour] [int] NOT NULL,
	[Minute] [int] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[TransportDirectionId] [int] NOT NULL,
	[RunDate] [datetime2](7) NOT NULL CONSTRAINT [DF_Transport_RunDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransportDirection]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportDirection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_TransportDirection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/14/2017 9:03:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Coach] ON 

INSERT [dbo].[Coach] ([Id], [Name], [CoachTypeId]) VALUES (1, N'86B-009.96', 1)
INSERT [dbo].[Coach] ([Id], [Name], [CoachTypeId]) VALUES (2, N'86B-007.83', 1)
INSERT [dbo].[Coach] ([Id], [Name], [CoachTypeId]) VALUES (3, N'86B-010.04', 1)
INSERT [dbo].[Coach] ([Id], [Name], [CoachTypeId]) VALUES (4, N'86B-010.09', 1)
INSERT [dbo].[Coach] ([Id], [Name], [CoachTypeId]) VALUES (5, N'86B-008.41', 1)
SET IDENTITY_INSERT [dbo].[Coach] OFF
SET IDENTITY_INSERT [dbo].[CoachType] ON 

INSERT [dbo].[CoachType] ([Id], [Name]) VALUES (1, N'Xe giường nằm 40 chỗ')
SET IDENTITY_INSERT [dbo].[CoachType] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [EmployeeTypeId]) VALUES (1, N'Tài', 1)
INSERT [dbo].[Employee] ([Id], [Name], [EmployeeTypeId]) VALUES (2, N'Hậu', 2)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeType] ON 

INSERT [dbo].[EmployeeType] ([Id], [Name]) VALUES (1, N'Tài xế')
INSERT [dbo].[EmployeeType] ([Id], [Name]) VALUES (2, N'Lơ xe')
SET IDENTITY_INSERT [dbo].[EmployeeType] OFF
SET IDENTITY_INSERT [dbo].[Seat] ON 

INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (1, N'A1', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (2, N'A2', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (3, N'A3', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (4, N'A4', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (5, N'A5', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (6, N'A6', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (7, N'A7', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (8, N'A8', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (9, N'A9', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (10, N'A10', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (11, N'A11', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (12, N'A12', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (13, N'A13', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (14, N'A14', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (15, N'A15', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (16, N'A16', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (17, N'A17', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (18, N'A18', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (19, N'A19', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (20, N'A20', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (21, N'S1', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (22, N'S2', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (23, N'S3', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (24, N'S4', 1, 1)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (25, N'B1', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (26, N'B2', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (27, N'B3', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (28, N'B4', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (29, N'B5', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (30, N'B6', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (31, N'B7', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (32, N'B8', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (33, N'B9', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (34, N'B10', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (35, N'B11', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (36, N'B12', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (37, N'B13', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (38, N'B14', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (39, N'B15', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (40, N'B16', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (41, N'B17', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (42, N'B18', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (43, N'B19', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (44, N'B20', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (45, N'S5', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (46, N'S6', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (47, N'S7', 1, 0)
INSERT [dbo].[Seat] ([Id], [Name], [CoachType], [IsOnLeftSide]) VALUES (48, N'S8', 1, 0)
SET IDENTITY_INSERT [dbo].[Seat] OFF
SET IDENTITY_INSERT [dbo].[Transport] ON 

INSERT [dbo].[Transport] ([Id], [CoachId], [DriverId], [AssistantId], [Day], [Month], [Year], [Hour], [Minute], [IsCompleted], [TransportDirectionId], [RunDate]) VALUES (1, 1, 1, 2, 14, 6, 2017, 0, 0, 0, 1, CAST(N'2017-06-14 00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Transport] OFF
SET IDENTITY_INSERT [dbo].[TransportDirection] ON 

INSERT [dbo].[TransportDirection] ([Id], [Name]) VALUES (1, N'Phan Thiết - Sài Gòn')
INSERT [dbo].[TransportDirection] ([Id], [Name]) VALUES (2, N'Sài Gòn - Phan Thiết')
SET IDENTITY_INSERT [dbo].[TransportDirection] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [DisplayName], [Username], [Password]) VALUES (1, N'Admin', N'admin', N'123456')
INSERT [dbo].[User] ([Id], [DisplayName], [Username], [Password]) VALUES (2, N'Hiền', N'hien.trungnga', N'123456')
INSERT [dbo].[User] ([Id], [DisplayName], [Username], [Password]) VALUES (3, N'Pon', N'pon.trungnga', N'123456')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_IsCancelled]  DEFAULT ((0)) FOR [IsCancelled]
GO
ALTER TABLE [dbo].[BookInfo] ADD  CONSTRAINT [DF_BookInfo_NbOfSeats]  DEFAULT ((0)) FOR [NbOfSeats]
GO
ALTER TABLE [dbo].[BookInfo] ADD  CONSTRAINT [DF_BookInfo_PaymentStatusId]  DEFAULT ((1)) FOR [PaymentStatusId]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookInfo] FOREIGN KEY([BookInfoId])
REFERENCES [dbo].[BookInfo] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookInfo]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Seat] FOREIGN KEY([SeatId])
REFERENCES [dbo].[Seat] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Seat]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Transport] FOREIGN KEY([TransportId])
REFERENCES [dbo].[Transport] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Transport]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_User] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_User]
GO
ALTER TABLE [dbo].[BookLog]  WITH CHECK ADD  CONSTRAINT [FK_BookLog_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[BookLog] CHECK CONSTRAINT [FK_BookLog_Book]
GO
ALTER TABLE [dbo].[BookLog]  WITH CHECK ADD  CONSTRAINT [FK_BookLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[BookLog] CHECK CONSTRAINT [FK_BookLog_User]
GO
ALTER TABLE [dbo].[Coach]  WITH CHECK ADD  CONSTRAINT [FK_Coach_CoachType] FOREIGN KEY([CoachTypeId])
REFERENCES [dbo].[CoachType] ([Id])
GO
ALTER TABLE [dbo].[Coach] CHECK CONSTRAINT [FK_Coach_CoachType]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeType] FOREIGN KEY([EmployeeTypeId])
REFERENCES [dbo].[EmployeeType] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeType]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK_Seat_CoachType] FOREIGN KEY([CoachType])
REFERENCES [dbo].[CoachType] ([Id])
GO
ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK_Seat_CoachType]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_Coach] FOREIGN KEY([CoachId])
REFERENCES [dbo].[Coach] ([Id])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_Coach]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_Employee_Assistant] FOREIGN KEY([AssistantId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_Employee_Assistant]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_Employee_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_Employee_Driver]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_TransportDirection] FOREIGN KEY([TransportDirectionId])
REFERENCES [dbo].[TransportDirection] ([Id])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_TransportDirection]
GO
USE [master]
GO
ALTER DATABASE [TrungNgaApp] SET  READ_WRITE 
GO
