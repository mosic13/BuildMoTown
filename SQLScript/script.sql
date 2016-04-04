USE [master]
GO
/****** Object:  Database [CitySimulationGame]    Script Date: 4/5/2016 1:42:50 AM ******/
CREATE DATABASE [CitySimulationGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CitySimulationGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CitySimulationGame.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CitySimulationGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CitySimulationGame_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CitySimulationGame] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CitySimulationGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CitySimulationGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CitySimulationGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CitySimulationGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CitySimulationGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CitySimulationGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [CitySimulationGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CitySimulationGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CitySimulationGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CitySimulationGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CitySimulationGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CitySimulationGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CitySimulationGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CitySimulationGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CitySimulationGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CitySimulationGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CitySimulationGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CitySimulationGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CitySimulationGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CitySimulationGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CitySimulationGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CitySimulationGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CitySimulationGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CitySimulationGame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CitySimulationGame] SET  MULTI_USER 
GO
ALTER DATABASE [CitySimulationGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CitySimulationGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CitySimulationGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CitySimulationGame] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CitySimulationGame] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CitySimulationGame]
GO
/****** Object:  Table [dbo].[BuildingType]    Script Date: 4/5/2016 1:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BuildingType](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[IsDefault] [bit] NOT NULL CONSTRAINT [DF_BuildingType_IsDefault]  DEFAULT ((1)),
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 4/5/2016 1:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[GoldCoins] [int] NOT NULL CONSTRAINT [DF_City_GoldCoins]  DEFAULT ((10)),
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL CONSTRAINT [DF_City_ModifyDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CityBuilding]    Script Date: 4/5/2016 1:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityBuilding](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[BuildingId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[Levels] [int] NULL,
 CONSTRAINT [PK_CityBuilding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 4/5/2016 1:42:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[BStatus] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BuildingType] ON 

INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (4, N'Town hall', CAST(N'2016-04-02 13:38:51.333' AS DateTime), CAST(N'2016-04-02 13:38:51.333' AS DateTime), 1)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (5, N'Supermarket', CAST(N'2016-04-02 13:38:51.367' AS DateTime), CAST(N'2016-04-02 13:38:51.367' AS DateTime), 1)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (6, N'Restaurant', CAST(N'2016-04-02 13:38:51.367' AS DateTime), CAST(N'2016-04-02 13:38:51.367' AS DateTime), 1)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (7, N'Expo center', CAST(N'2016-04-02 13:38:51.370' AS DateTime), CAST(N'2016-04-02 13:38:51.370' AS DateTime), 1)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (8, N'Train station', CAST(N'2016-04-02 13:38:51.370' AS DateTime), CAST(N'2016-04-02 13:38:51.370' AS DateTime), 1)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (9, N'NewBuildingType', CAST(N'2016-04-04 23:55:24.443' AS DateTime), CAST(N'2016-04-04 23:55:25.817' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (10, N'NewBuildingType1', CAST(N'2016-04-04 23:57:03.177' AS DateTime), CAST(N'2016-04-04 23:57:03.880' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (11, N'NewBuildingType1123', CAST(N'2016-04-05 00:30:58.977' AS DateTime), CAST(N'2016-04-05 00:30:59.593' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (12, N'MyBltdest', CAST(N'2016-04-05 01:12:52.773' AS DateTime), CAST(N'2016-04-05 01:12:52.773' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (13, N'Testtttt', CAST(N'2016-04-05 01:15:54.817' AS DateTime), CAST(N'2016-04-05 01:15:54.817' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (14, N'WowBuilding', CAST(N'2016-04-05 01:20:42.267' AS DateTime), CAST(N'2016-04-05 01:20:42.267' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (15, N'WowBuilding', CAST(N'2016-04-05 01:21:22.633' AS DateTime), CAST(N'2016-04-05 01:21:24.300' AS DateTime), 0)
INSERT [dbo].[BuildingType] ([BuildingId], [BuildingName], [CreateDate], [ModifyDate], [IsDefault]) VALUES (16, N'WowBuilding2', CAST(N'2016-04-05 01:25:15.510' AS DateTime), CAST(N'2016-04-05 01:25:15.510' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BuildingType] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (1, N'test', 10, CAST(N'2016-04-02 16:53:41.087' AS DateTime), CAST(N'2016-04-02 16:53:41.087' AS DateTime))
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (2, N'TestCity1', 10, NULL, NULL)
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (3, N'TestCity2', 10, CAST(N'2016-04-02 17:20:20.707' AS DateTime), CAST(N'2016-04-02 17:20:20.707' AS DateTime))
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (4, N'AwesomeCity', 10, CAST(N'2016-04-02 23:40:55.797' AS DateTime), CAST(N'2016-04-02 23:40:56.193' AS DateTime))
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (5, N'AwesomeCity1', 10, CAST(N'2016-04-02 23:53:45.227' AS DateTime), CAST(N'2016-04-02 23:53:45.227' AS DateTime))
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (6, N'AwesomeCity2', 10, CAST(N'2016-04-02 23:55:34.883' AS DateTime), CAST(N'2016-04-02 23:55:34.883' AS DateTime))
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (7, N'AwesomeCity', 500, CAST(N'2016-04-03 02:30:08.680' AS DateTime), CAST(N'2016-04-03 02:30:08.680' AS DateTime))
INSERT [dbo].[City] ([CityId], [CityName], [GoldCoins], [CreateDate], [ModifyDate]) VALUES (8, N'MyWorld', 10, CAST(N'2016-04-03 04:07:59.623' AS DateTime), CAST(N'2016-04-03 04:07:59.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[CityBuilding] ON 

INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (2, 4, 4, CAST(N'2016-04-02 23:41:16.890' AS DateTime), CAST(N'2016-04-02 23:41:16.890' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (3, 4, 5, CAST(N'2016-04-02 23:41:16.890' AS DateTime), CAST(N'2016-04-02 23:41:16.890' AS DateTime), 4)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (4, 4, 6, CAST(N'2016-04-02 23:41:16.890' AS DateTime), CAST(N'2016-04-02 23:41:16.890' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (5, 4, 7, CAST(N'2016-04-02 23:41:16.890' AS DateTime), CAST(N'2016-04-02 23:41:16.890' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (6, 4, 8, CAST(N'2016-04-02 23:41:16.890' AS DateTime), CAST(N'2016-04-02 23:41:16.890' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (7, 5, 4, CAST(N'2016-04-02 23:53:45.477' AS DateTime), CAST(N'2016-04-02 23:53:45.477' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (8, 5, 5, CAST(N'2016-04-02 23:53:45.477' AS DateTime), CAST(N'2016-04-02 23:53:45.477' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (9, 5, 6, CAST(N'2016-04-02 23:53:45.477' AS DateTime), CAST(N'2016-04-02 23:53:45.477' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (10, 5, 7, CAST(N'2016-04-02 23:53:45.477' AS DateTime), CAST(N'2016-04-02 23:53:45.477' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (11, 5, 8, CAST(N'2016-04-02 23:53:45.477' AS DateTime), CAST(N'2016-04-02 23:53:45.477' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (12, 6, 4, CAST(N'2016-04-02 23:55:35.733' AS DateTime), CAST(N'2016-04-02 23:55:35.733' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (13, 6, 5, CAST(N'2016-04-02 23:55:35.733' AS DateTime), CAST(N'2016-04-02 23:55:35.733' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (14, 6, 6, CAST(N'2016-04-02 23:55:35.733' AS DateTime), CAST(N'2016-04-02 23:55:35.733' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (15, 6, 7, CAST(N'2016-04-02 23:55:35.733' AS DateTime), CAST(N'2016-04-02 23:55:35.733' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (16, 6, 8, CAST(N'2016-04-02 23:55:35.733' AS DateTime), CAST(N'2016-04-02 23:55:35.733' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (17, 7, 4, CAST(N'2016-04-03 02:30:09.717' AS DateTime), CAST(N'2016-04-03 02:30:09.717' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (18, 7, 5, CAST(N'2016-04-03 02:30:09.717' AS DateTime), CAST(N'2016-04-03 02:30:09.717' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (19, 7, 6, CAST(N'2016-04-03 02:30:09.717' AS DateTime), CAST(N'2016-04-03 02:30:09.717' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (20, 7, 7, CAST(N'2016-04-03 02:30:09.717' AS DateTime), CAST(N'2016-04-03 02:30:09.717' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (21, 7, 8, CAST(N'2016-04-03 02:30:09.717' AS DateTime), CAST(N'2016-04-03 02:30:09.717' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (22, 8, 4, CAST(N'2016-04-03 04:07:59.977' AS DateTime), CAST(N'2016-04-03 04:07:59.977' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (23, 8, 5, CAST(N'2016-04-03 04:07:59.977' AS DateTime), CAST(N'2016-04-03 04:07:59.977' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (24, 8, 6, CAST(N'2016-04-03 04:07:59.977' AS DateTime), CAST(N'2016-04-03 04:07:59.977' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (25, 8, 7, CAST(N'2016-04-03 04:07:59.977' AS DateTime), CAST(N'2016-04-03 04:07:59.977' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (26, 8, 8, CAST(N'2016-04-03 04:07:59.977' AS DateTime), CAST(N'2016-04-03 04:07:59.977' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (27, 8, 9, CAST(N'2016-04-04 23:55:57.060' AS DateTime), CAST(N'2016-04-04 23:55:58.133' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (28, 8, 10, CAST(N'2016-04-04 23:57:30.150' AS DateTime), CAST(N'2016-04-04 23:57:30.150' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (31, 7, 13, CAST(N'2016-04-05 01:15:55.627' AS DateTime), CAST(N'2016-04-05 01:15:55.627' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (32, 7, 14, CAST(N'2016-04-05 01:20:42.390' AS DateTime), CAST(N'2016-04-05 01:20:42.390' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (33, 7, 15, CAST(N'2016-04-05 01:21:34.197' AS DateTime), CAST(N'2016-04-05 01:21:36.283' AS DateTime), 1)
INSERT [dbo].[CityBuilding] ([Id], [CityId], [BuildingId], [CreateDate], [ModifyDate], [Levels]) VALUES (34, 6, 16, CAST(N'2016-04-05 01:25:16.050' AS DateTime), CAST(N'2016-04-05 01:25:16.050' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CityBuilding] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusId], [BStatus], [Description]) VALUES (1, N'Built', N'Completed')
INSERT [dbo].[Status] ([StatusId], [BStatus], [Description]) VALUES (2, N'Building', N'Building New Building')
INSERT [dbo].[Status] ([StatusId], [BStatus], [Description]) VALUES (3, N'Upgrading', N'Upgrading built bulding')
SET IDENTITY_INSERT [dbo].[Status] OFF
ALTER TABLE [dbo].[CityBuilding]  WITH CHECK ADD  CONSTRAINT [FK_CityBuilding_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[BuildingType] ([BuildingId])
GO
ALTER TABLE [dbo].[CityBuilding] CHECK CONSTRAINT [FK_CityBuilding_Building]
GO
ALTER TABLE [dbo].[CityBuilding]  WITH CHECK ADD  CONSTRAINT [FK_CityBuilding_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[CityBuilding] CHECK CONSTRAINT [FK_CityBuilding_City]
GO
USE [master]
GO
ALTER DATABASE [CitySimulationGame] SET  READ_WRITE 
GO
