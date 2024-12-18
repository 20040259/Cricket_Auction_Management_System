USE [master]
GO
/****** Object:  Database [CricketAuctionDB]    Script Date: 12/4/2024 2:55:10 PM ******/
CREATE DATABASE [CricketAuctionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CricketAuctionDB', FILENAME = N'C:\Users\AYANI ILANKA\CricketAuctionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CricketAuctionDB_log', FILENAME = N'C:\Users\AYANI ILANKA\CricketAuctionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CricketAuctionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CricketAuctionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CricketAuctionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CricketAuctionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CricketAuctionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CricketAuctionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CricketAuctionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CricketAuctionDB] SET  MULTI_USER 
GO
ALTER DATABASE [CricketAuctionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CricketAuctionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CricketAuctionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CricketAuctionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CricketAuctionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CricketAuctionDB] SET QUERY_STORE = OFF
GO
USE [CricketAuctionDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/4/2024 2:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountAccesses]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountAccesses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AccountAccesses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuctionPictures]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionPictures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuctionID] [int] NOT NULL,
	[PictureID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AuctionPictures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auctions]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auctions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ActualAmount] [nvarchar](max) NOT NULL,
	[StartingTime] [datetime] NULL,
	[EndingTime] [datetime] NULL,
	[CategoryID] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Auctions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](max) NULL,
	[TeamDescription] [nvarchar](max) NULL,
	[MaxPrice] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Pictures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[PlayerRole] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[TrophyID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamOwners]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamOwners](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TeamOwners] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trophies]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trophies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrophyName] [nvarchar](max) NULL,
	[TrophyDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Trophies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trophy]    Script Date: 12/4/2024 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trophy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrophyName] [nvarchar](100) NULL,
	[TrophyDescription] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_AuctionID]    Script Date: 12/4/2024 2:55:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AuctionID] ON [dbo].[AuctionPictures]
(
	[AuctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PictureID]    Script Date: 12/4/2024 2:55:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_PictureID] ON [dbo].[AuctionPictures]
(
	[PictureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryID]    Script Date: 12/4/2024 2:55:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryID] ON [dbo].[Auctions]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrophyID]    Script Date: 12/4/2024 2:55:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_TrophyID] ON [dbo].[Players]
(
	[TrophyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Auctions] ADD  DEFAULT ((0)) FOR [CategoryID]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [MaxPrice]
GO
ALTER TABLE [dbo].[Players] ADD  DEFAULT ((0)) FOR [TrophyID]
GO
ALTER TABLE [dbo].[AuctionPictures]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AuctionPictures_dbo.Auctions_AuctionID] FOREIGN KEY([AuctionID])
REFERENCES [dbo].[Auctions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuctionPictures] CHECK CONSTRAINT [FK_dbo.AuctionPictures_dbo.Auctions_AuctionID]
GO
ALTER TABLE [dbo].[AuctionPictures]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AuctionPictures_dbo.Pictures_PictureID] FOREIGN KEY([PictureID])
REFERENCES [dbo].[Pictures] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuctionPictures] CHECK CONSTRAINT [FK_dbo.AuctionPictures_dbo.Pictures_PictureID]
GO
ALTER TABLE [dbo].[Auctions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Auctions_dbo.Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Auctions] CHECK CONSTRAINT [FK_dbo.Auctions_dbo.Categories_CategoryID]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Players_dbo.Trophies_TrophyID] FOREIGN KEY([TrophyID])
REFERENCES [dbo].[Trophies] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_dbo.Players_dbo.Trophies_TrophyID]
GO
USE [master]
GO
ALTER DATABASE [CricketAuctionDB] SET  READ_WRITE 
GO
