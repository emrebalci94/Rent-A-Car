USE [master]
GO
/****** Object:  Database [rentAcar]    Script Date: 22.04.2015 15:59:39 ******/
CREATE DATABASE [rentAcar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'rentAcar', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\rentAcar.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'rentAcar_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\rentAcar_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [rentAcar] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [rentAcar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [rentAcar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [rentAcar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [rentAcar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [rentAcar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [rentAcar] SET ARITHABORT OFF 
GO
ALTER DATABASE [rentAcar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [rentAcar] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [rentAcar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [rentAcar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [rentAcar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [rentAcar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [rentAcar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [rentAcar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [rentAcar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [rentAcar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [rentAcar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [rentAcar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [rentAcar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [rentAcar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [rentAcar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [rentAcar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [rentAcar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [rentAcar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [rentAcar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [rentAcar] SET  MULTI_USER 
GO
ALTER DATABASE [rentAcar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [rentAcar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [rentAcar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [rentAcar] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [rentAcar]
GO
/****** Object:  Table [dbo].[araba]    Script Date: 22.04.2015 15:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[araba](
	[plakaNo] [nchar](9) NOT NULL,
	[ruhsatNo] [nchar](6) NULL,
	[markaNo] [int] NULL,
	[cins] [varchar](50) NULL,
	[model] [nchar](4) NULL,
	[yakit] [varchar](50) NULL,
	[sase] [nchar](20) NULL,
	[sigortaTarih] [date] NULL,
	[kaskoTarih] [date] NULL,
	[vizeTarih] [date] NULL,
	[band] [nchar](15) NULL,
	[aciklama] [varchar](250) NULL,
 CONSTRAINT [PK_araba] PRIMARY KEY CLUSTERED 
(
	[plakaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kira]    Script Date: 22.04.2015 15:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kira](
	[kiraNo] [int] IDENTITY(1,1) NOT NULL,
	[plakaNo] [nchar](9) NULL,
	[kimlikNo] [nchar](11) NULL,
	[kiraTarih] [date] NULL,
	[gelisTarih] [date] NULL,
	[hasarDurum] [varchar](150) NULL,
	[durum] [nvarchar](1) NULL,
 CONSTRAINT [PK_kira] PRIMARY KEY CLUSTERED 
(
	[kiraNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[marka]    Script Date: 22.04.2015 15:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[marka](
	[markaNo] [int] IDENTITY(1,1) NOT NULL,
	[markaAdi] [varchar](50) NULL,
 CONSTRAINT [PK_marka] PRIMARY KEY CLUSTERED 
(
	[markaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[musteri]    Script Date: 22.04.2015 15:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[musteri](
	[kimlikNo] [nchar](11) NOT NULL,
	[adSoyad] [varchar](250) NULL,
	[dogumTarih] [date] NULL,
	[adres] [varchar](250) NULL,
	[email] [varchar](100) NULL,
	[babaAdi] [varchar](70) NULL,
	[kanGrup] [varchar](5) NULL,
	[ehliyetNo] [nchar](5) NULL,
	[ehliyetTip] [varchar](2) NULL,
	[ehliyetTarih] [date] NULL,
	[telefon] [varchar](15) NULL,
 CONSTRAINT [PK_musteri] PRIMARY KEY CLUSTERED 
(
	[kimlikNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[odeme]    Script Date: 22.04.2015 15:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[odeme](
	[odemeNo] [int] IDENTITY(1,1) NOT NULL,
	[kiraNo] [int] NULL,
	[kimlikNo] [nchar](11) NULL,
	[odemeTutar] [money] NULL,
	[odemeSekli] [nchar](1) NULL,
 CONSTRAINT [PK_odeme] PRIMARY KEY CLUSTERED 
(
	[odemeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[araba]  WITH CHECK ADD  CONSTRAINT [FK_araba_marka] FOREIGN KEY([markaNo])
REFERENCES [dbo].[marka] ([markaNo])
GO
ALTER TABLE [dbo].[araba] CHECK CONSTRAINT [FK_araba_marka]
GO
ALTER TABLE [dbo].[kira]  WITH CHECK ADD  CONSTRAINT [FK_kira_araba] FOREIGN KEY([plakaNo])
REFERENCES [dbo].[araba] ([plakaNo])
GO
ALTER TABLE [dbo].[kira] CHECK CONSTRAINT [FK_kira_araba]
GO
ALTER TABLE [dbo].[kira]  WITH CHECK ADD  CONSTRAINT [FK_kira_musteri] FOREIGN KEY([kimlikNo])
REFERENCES [dbo].[musteri] ([kimlikNo])
GO
ALTER TABLE [dbo].[kira] CHECK CONSTRAINT [FK_kira_musteri]
GO
ALTER TABLE [dbo].[odeme]  WITH CHECK ADD  CONSTRAINT [FK_odeme_kira] FOREIGN KEY([kiraNo])
REFERENCES [dbo].[kira] ([kiraNo])
GO
ALTER TABLE [dbo].[odeme] CHECK CONSTRAINT [FK_odeme_kira]
GO
ALTER TABLE [dbo].[odeme]  WITH CHECK ADD  CONSTRAINT [FK_odeme_musteri] FOREIGN KEY([kimlikNo])
REFERENCES [dbo].[musteri] ([kimlikNo])
GO
ALTER TABLE [dbo].[odeme] CHECK CONSTRAINT [FK_odeme_musteri]
GO
USE [master]
GO
ALTER DATABASE [rentAcar] SET  READ_WRITE 
GO
