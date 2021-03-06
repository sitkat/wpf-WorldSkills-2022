USE [master]
GO
/****** Object:  Database [Karting]    Script Date: 21.04.2022 20:00:19 ******/
CREATE DATABASE [Karting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Karting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Karting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Karting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Karting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Karting] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Karting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Karting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Karting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Karting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Karting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Karting] SET ARITHABORT OFF 
GO
ALTER DATABASE [Karting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Karting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Karting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Karting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Karting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Karting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Karting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Karting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Karting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Karting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Karting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Karting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Karting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Karting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Karting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Karting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Karting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Karting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Karting] SET  MULTI_USER 
GO
ALTER DATABASE [Karting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Karting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Karting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Karting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Karting] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Karting] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Karting] SET QUERY_STORE = OFF
GO
USE [Karting]
GO
/****** Object:  Table [dbo].[Event_Type]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_Type](
	[ID_Event_type] [nchar](5) NOT NULL,
	[Event_Type_Name] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Event_Type_1] PRIMARY KEY CLUSTERED 
(
	[ID_Event_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[ID_Registration] [int] IDENTITY(1,1) NOT NULL,
	[ID_Racer] [int] NOT NULL,
	[Registration_Date] [date] NOT NULL,
	[ID_Registration_Status] [int] NOT NULL,
	[Cost] [decimal](10, 2) NOT NULL,
	[ID_Charity] [int] NOT NULL,
	[SponsorshipTarget] [decimal](10, 2) NOT NULL,
	[ID_Event_Type] [nchar](5) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[ID_Registration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration_Status]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration_Status](
	[ID_Registration_Status] [int] IDENTITY(1,1) NOT NULL,
	[Statu_Name] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Registration_Status] PRIMARY KEY CLUSTERED 
(
	[ID_Registration_Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racer]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racer](
	[ID_Racer] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](50) NOT NULL,
	[Gender] [nchar](1) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[ID_Country] [nchar](3) NOT NULL,
	[ID_User] [int] NOT NULL,
	[Photo] [nvarchar](250) NULL,
 CONSTRAINT [PK_Racer] PRIMARY KEY CLUSTERED 
(
	[ID_Racer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID_User] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[First_Name] [nvarchar](30) NULL,
	[Last_Name] [nvarchar](30) NULL,
	[ID_Role] [nchar](1) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewRacers]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewRacers]
AS
SELECT dbo.Racer.First_Name, dbo.Racer.Last_Name, dbo.[User].Email, dbo.Registration_Status.Statu_Name, dbo.Event_Type.Event_Type_Name
FROM   dbo.Racer INNER JOIN
             dbo.Registration ON dbo.Racer.ID_Racer = dbo.Registration.ID_Racer INNER JOIN
             dbo.Registration_Status ON dbo.Registration.ID_Registration_Status = dbo.Registration_Status.ID_Registration_Status INNER JOIN
             dbo.[User] ON dbo.Racer.ID_User = dbo.[User].ID_User INNER JOIN
             dbo.Event_Type ON dbo.Registration.ID_Event_Type = dbo.Event_Type.ID_Event_type
GO
/****** Object:  Table [dbo].[Country]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[ID_Country] [nchar](3) NOT NULL,
	[Country_Name] [varchar](50) NOT NULL,
	[Country_Flag] [varchar](50) NOT NULL,
 CONSTRAINT [PK_contry] PRIMARY KEY CLUSTERED 
(
	[ID_Country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Racer_View]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Racer_View]
AS
SELECT dbo.Racer.ID_Racer, SUBSTRING(dbo.Racer.First_Name, 0, { fn LENGTH(dbo.Racer.First_Name) } + 1) + ' ' + SUBSTRING(dbo.Racer.Last_Name, 0, { fn LENGTH(dbo.Racer.Last_Name) } + 1) + ' -' + ' ' + '(' + SUBSTRING(dbo.Country.Country_Name, 0, 
             { fn LENGTH(dbo.Country.Country_Name) } + 1) + ')' AS AllInformation
FROM   dbo.Racer INNER JOIN
             dbo.Country ON dbo.Racer.ID_Country = dbo.Country.ID_Country
GO
/****** Object:  Table [dbo].[Charity]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charity](
	[ID_Сharity] [int] IDENTITY(1,1) NOT NULL,
	[Charity_Name] [nvarchar](100) NOT NULL,
	[Charity_Description] [nvarchar](3000) NULL,
	[Charity_Logo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Charity] PRIMARY KEY CLUSTERED 
(
	[ID_Сharity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sponsorship]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsorship](
	[ID_Sponsorship] [int] IDENTITY(1,1) NOT NULL,
	[SponsorName] [nvarchar](150) NOT NULL,
	[Amount] [decimal](10, 2) NULL,
	[ID_Racer] [int] NULL,
 CONSTRAINT [PK_Sponsorship] PRIMARY KEY CLUSTERED 
(
	[ID_Sponsorship] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MySponsorView]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MySponsorView]
AS
SELECT dbo.Charity.Charity_Name, dbo.Charity.Charity_Logo, dbo.Charity.Charity_Description, dbo.Sponsorship.SponsorName, dbo.Sponsorship.Amount, dbo.Sponsorship.ID_Racer
FROM   dbo.Sponsorship INNER JOIN
             dbo.Racer ON dbo.Sponsorship.ID_Racer = dbo.Racer.ID_Racer INNER JOIN
             dbo.Registration ON dbo.Racer.ID_Racer = dbo.Registration.ID_Racer INNER JOIN
             dbo.Charity ON dbo.Registration.ID_Charity = dbo.Charity.ID_Сharity
GO
/****** Object:  Table [dbo].[Event]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[ID_Event] [int] IDENTITY(1,1) NOT NULL,
	[Event_Name] [nvarchar](50) NOT NULL,
	[ID_EventType] [nchar](5) NOT NULL,
	[ID_Race] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[Cost] [decimal](10, 2) NOT NULL,
	[MaxParticipants] [smallint] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID_Event] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Race]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Race](
	[ID_Race] [int] IDENTITY(1,1) NOT NULL,
	[Race_Name] [varchar](80) NOT NULL,
	[Sity] [varchar](50) NOT NULL,
	[ID_Country] [nchar](3) NOT NULL,
	[Year_Held] [smallint] NOT NULL,
 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED 
(
	[ID_Race] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ID_Result] [int] IDENTITY(1,1) NOT NULL,
	[ID_Registration] [int] NOT NULL,
	[ID_Event] [int] NOT NULL,
	[BidNumber] [smallint] NOT NULL,
	[RaceTime] [time](7) NOT NULL,
	[CommonPlace] [nvarchar](5) NULL,
 CONSTRAINT [PK_RegistrationEvent] PRIMARY KEY CLUSTERED 
(
	[ID_Result] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MyResultsView]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MyResultsView]
AS
SELECT dbo.Race.Race_Name, dbo.Event_Type.Event_Type_Name, dbo.Result.RaceTime, dbo.Result.CommonPlace, dbo.Result.BidNumber, dbo.Result.ID_Registration
FROM   dbo.Event INNER JOIN
             dbo.Race ON dbo.Event.ID_Race = dbo.Race.ID_Race INNER JOIN
             dbo.Event_Type ON dbo.Event.ID_EventType = dbo.Event_Type.ID_Event_type INNER JOIN
             dbo.Result ON dbo.Event.ID_Event = dbo.Result.ID_Event
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[ID_Gender] [nchar](1) NOT NULL,
	[Gender_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[ID_Gender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteer]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer](
	[ID_Volunteer] [nchar](3) NOT NULL,
	[First_Name] [nvarchar](80) NOT NULL,
	[Last_Name] [nvarchar](80) NOT NULL,
	[ID_Country] [nchar](3) NOT NULL,
	[Gender_ID] [nchar](1) NULL,
 CONSTRAINT [PK_Volunteer] PRIMARY KEY CLUSTERED 
(
	[ID_Volunteer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Volunteer_View]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Volunteer_View]
AS
SELECT dbo.Volunteer.First_Name, dbo.Volunteer.Last_Name, dbo.Country.Country_Name, dbo.Gender.Gender_Name
FROM   dbo.Country INNER JOIN
             dbo.Volunteer ON dbo.Country.ID_Country = dbo.Volunteer.ID_Country INNER JOIN
             dbo.Gender ON dbo.Volunteer.Gender_ID = dbo.Gender.ID_Gender
GO
/****** Object:  View [dbo].[ViewSponsors]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewSponsors]
AS
SELECT dbo.Charity.Charity_Logo, dbo.Charity.Charity_Name, dbo.Sponsorship.Amount
FROM   dbo.Charity INNER JOIN
             dbo.Registration ON dbo.Charity.ID_Сharity = dbo.Registration.ID_Charity INNER JOIN
             dbo.Racer ON dbo.Registration.ID_Racer = dbo.Racer.ID_Racer INNER JOIN
             dbo.Sponsorship ON dbo.Racer.ID_Racer = dbo.Sponsorship.ID_Racer
GO
/****** Object:  Table [dbo].[Position]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Positionid] [int] NOT NULL,
	[PositionName] [varchar](100) NOT NULL,
	[PositionDescription] [varchar](100) NULL,
	[PayPeriod] [varchar](10) NOT NULL,
	[PayRate] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Positionn] PRIMARY KEY CLUSTERED 
(
	[Positionid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID_Role] [nchar](1) NOT NULL,
	[Role_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Staffid] [int] NOT NULL,
	[FirstName] [varchar](80) NOT NULL,
	[LastName] [varchar](80) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Positionid] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Staffid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timesheet]    Script Date: 21.04.2022 20:00:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timesheet](
	[Timesheetid] [int] NOT NULL,
	[Staffid] [int] NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[PayAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Timesheet] PRIMARY KEY CLUSTERED 
(
	[Timesheetid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Event_Type1] FOREIGN KEY([ID_EventType])
REFERENCES [dbo].[Event_Type] ([ID_Event_type])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Event_Type1]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Race] FOREIGN KEY([ID_Race])
REFERENCES [dbo].[Race] ([ID_Race])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Race]
GO
ALTER TABLE [dbo].[Race]  WITH CHECK ADD  CONSTRAINT [FK_Race_Country] FOREIGN KEY([ID_Country])
REFERENCES [dbo].[Country] ([ID_Country])
GO
ALTER TABLE [dbo].[Race] CHECK CONSTRAINT [FK_Race_Country]
GO
ALTER TABLE [dbo].[Racer]  WITH CHECK ADD  CONSTRAINT [FK_Racer_Country_User] FOREIGN KEY([ID_Country])
REFERENCES [dbo].[Country] ([ID_Country])
GO
ALTER TABLE [dbo].[Racer] CHECK CONSTRAINT [FK_Racer_Country_User]
GO
ALTER TABLE [dbo].[Racer]  WITH CHECK ADD  CONSTRAINT [FK_Racer_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Gender] ([ID_Gender])
GO
ALTER TABLE [dbo].[Racer] CHECK CONSTRAINT [FK_Racer_Gender]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Charity] FOREIGN KEY([ID_Charity])
REFERENCES [dbo].[Charity] ([ID_Сharity])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Charity]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Racer] FOREIGN KEY([ID_Racer])
REFERENCES [dbo].[Racer] ([ID_Racer])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Racer]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Registration_Event_Type] FOREIGN KEY([ID_Event_Type])
REFERENCES [dbo].[Event_Type] ([ID_Event_type])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Registration_Event_Type]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Event_Event] FOREIGN KEY([ID_Event])
REFERENCES [dbo].[Event] ([ID_Event])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Registration_Event_Event]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Event_Registration] FOREIGN KEY([ID_Registration])
REFERENCES [dbo].[Registration] ([ID_Registration])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Registration_Event_Registration]
GO
ALTER TABLE [dbo].[Sponsorship]  WITH CHECK ADD  CONSTRAINT [FK_Sponsorship_Sponsorship_Racer] FOREIGN KEY([ID_Racer])
REFERENCES [dbo].[Racer] ([ID_Racer])
GO
ALTER TABLE [dbo].[Sponsorship] CHECK CONSTRAINT [FK_Sponsorship_Sponsorship_Racer]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Staff_PosionId] FOREIGN KEY([Positionid])
REFERENCES [dbo].[Position] ([Positionid])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Staff_PosionId]
GO
ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_Timesheet_Staffid] FOREIGN KEY([Staffid])
REFERENCES [dbo].[Staff] ([Staffid])
GO
ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_Timesheet_Staffid]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Role] ([ID_Role])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Country] FOREIGN KEY([ID_Country])
REFERENCES [dbo].[Country] ([ID_Country])
GO
ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Country]
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Gender] FOREIGN KEY([Gender_ID])
REFERENCES [dbo].[Gender] ([ID_Gender])
GO
ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Gender]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[2] 2[23] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Event"
            Begin Extent = 
               Top = 14
               Left = 306
               Bottom = 292
               Right = 534
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Race"
            Begin Extent = 
               Top = 8
               Left = 51
               Bottom = 205
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Event_Type"
            Begin Extent = 
               Top = 222
               Left = 35
               Bottom = 365
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Result"
            Begin Extent = 
               Top = 8
               Left = 584
               Bottom = 205
               Right = 812
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1840
         Width = 1490
         Width = 1130
         Width = 1460
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MyResultsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MyResultsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MyResultsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[1] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Racer"
            Begin Extent = 
               Top = 19
               Left = 619
               Bottom = 216
               Right = 847
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sponsorship"
            Begin Extent = 
               Top = 17
               Left = 881
               Bottom = 214
               Right = 1110
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Registration"
            Begin Extent = 
               Top = 18
               Left = 298
               Bottom = 215
               Right = 578
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Charity"
            Begin Extent = 
               Top = 9
               Left = 12
               Bottom = 206
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1890
         Width = 1830
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      E' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MySponsorView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'nd
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MySponsorView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MySponsorView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Country"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 179
               Right = 285
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Racer"
            Begin Extent = 
               Top = 9
               Left = 342
               Bottom = 206
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 2990
         Width = 1580
         Width = 1720
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Racer_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Racer_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[47] 4[3] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Racer"
            Begin Extent = 
               Top = 16
               Left = 500
               Bottom = 213
               Right = 728
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Registration"
            Begin Extent = 
               Top = 15
               Left = 781
               Bottom = 280
               Right = 1061
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Registration_Status"
            Begin Extent = 
               Top = 23
               Left = 1109
               Bottom = 166
               Right = 1389
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 16
               Left = 222
               Bottom = 213
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Event_Type"
            Begin Extent = 
               Top = 154
               Left = 1110
               Bottom = 297
               Right = 1356
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1540
         Width = 2040
         Width = 2780
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewRacers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewRacers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewRacers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[3] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Charity"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 313
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sponsorship"
            Begin Extent = 
               Top = 19
               Left = 935
               Bottom = 216
               Right = 1164
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Registration"
            Begin Extent = 
               Top = 5
               Left = 357
               Bottom = 202
               Right = 637
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Racer"
            Begin Extent = 
               Top = 6
               Left = 671
               Bottom = 203
               Right = 899
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 2640
         Width = 1370
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      En' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSponsors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'd
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSponsors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewSponsors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Country"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 179
               Right = 285
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Gender"
            Begin Extent = 
               Top = 9
               Left = 342
               Bottom = 152
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Volunteer"
            Begin Extent = 
               Top = 9
               Left = 627
               Bottom = 206
               Right = 855
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Volunteer_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Volunteer_View'
GO
USE [master]
GO
ALTER DATABASE [Karting] SET  READ_WRITE 
GO
