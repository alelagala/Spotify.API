USE [master]
GO
/****** Object:  Database [Spotify]    Script Date: 18-Dec-22 0:22:20 ******/
CREATE DATABASE [Spotify]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Spotify', FILENAME = N'/var/opt/mssql/data/Spotify.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Spotify_log', FILENAME = N'/var/opt/mssql/data/Spotify_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Spotify] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Spotify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Spotify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Spotify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Spotify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Spotify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Spotify] SET ARITHABORT OFF 
GO
ALTER DATABASE [Spotify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Spotify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Spotify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Spotify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Spotify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Spotify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Spotify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Spotify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Spotify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Spotify] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Spotify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Spotify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Spotify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Spotify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Spotify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Spotify] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Spotify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Spotify] SET RECOVERY FULL 
GO
ALTER DATABASE [Spotify] SET  MULTI_USER 
GO
ALTER DATABASE [Spotify] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Spotify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Spotify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Spotify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Spotify] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Spotify', N'ON'
GO
ALTER DATABASE [Spotify] SET QUERY_STORE = OFF
GO
USE [Spotify]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[pw] [varchar](64) NOT NULL,
	[SubscriptionName] [varchar](50) NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[GenreID] [int] NULL,
	[ArtistID] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[AccountID] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist_song]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist_song](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SongID] [int] NULL,
	[PlaylistID] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Radio]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Radio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[GenreID] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Song]    Script Date: 18-Dec-22 0:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Song](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[Popularity] [int] NOT NULL,
	[ArtistID] [int] NULL,
	[AlbumID] [int] NULL,
	[GenreID] [int] NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Artist] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Genre] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Playlist] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Playlist_song] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Radio] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Song] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([id])
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([id])
GO
ALTER TABLE [dbo].[Playlist]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Radio]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([id])
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Album] ([id])
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([id])
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([id])
GO
USE [master]
GO
ALTER DATABASE [Spotify] SET  READ_WRITE 
GO