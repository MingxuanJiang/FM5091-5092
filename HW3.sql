USE [master]
GO

/****** Object:  Database [MFM_MonteCarloSims]    Script Date: 3/15/2020 7:18:57 PM ******/
CREATE DATABASE [MFM_MonteCarloSims]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MFM_MonteCarloSims', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MFM_MonteCarloSims.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MFM_MonteCarloSims_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MFM_MonteCarloSims_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MFM_MonteCarloSims].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MFM_MonteCarloSims] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET ARITHABORT OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET RECOVERY FULL 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET  MULTI_USER 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MFM_MonteCarloSims] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MFM_MonteCarloSims] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MFM_MonteCarloSims] SET  READ_WRITE 
GO

--Create Company Table
CREATE TABLE [dbo].[Company](
	[ID] [int] NOT NULL,
	[Companyname] [varchar](max) NOT NULL,
	[Ticker] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


--Create Instrument Table
CREATE TABLE [dbo].[Instrument](
	[ID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Exchange] [varchar](max) NOT NULL,
	[Underlying] [float] NOT NULL,
	[Strike] [float] NOT NULL,
	[Tenor] [float] NOT NULL,
	[IsCall] [bit] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO

ALTER TABLE [dbo].[Instrument] CHECK CONSTRAINT [FK_Instrument_Company]
GO

ALTER TABLE [dbo].[Instrument]  WITH CHECK ADD  CONSTRAINT [FK_Instrument_InstType] FOREIGN KEY([TypeID])
REFERENCES [dbo].[InstType] ([ID])
GO

ALTER TABLE [dbo].[Instrument] CHECK CONSTRAINT [FK_Instrument_InstType]
GO

--Create InstType Table
CREATE TABLE [dbo].[InstType](
	[ID] [int] NOT NULL,
	[Typename] [varchar](max) NOT NULL,
 CONSTRAINT [PK_InstType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


--Create InterestRate Table
CREATE TABLE [dbo].[InterestRate](
	[RateID] [int] NOT NULL,
	[Time] [date] NOT NULL,
	[Tenor] [float] NOT NULL,
	[Rate] [float] NOT NULL,
 CONSTRAINT [PK_InterestRate] PRIMARY KEY CLUSTERED 
(
	[RateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--Create StockPrice Table
CREATE TABLE [dbo].[StockPrice](
	[ID] [int] NOT NULL,
	[Time] [date] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_StockPrice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockPrice]  WITH CHECK ADD  CONSTRAINT [FK_StockPrice_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO

ALTER TABLE [dbo].[StockPrice] CHECK CONSTRAINT [FK_StockPrice_Company]
GO

--Create Trade Table
CREATE TABLE [dbo].[Trade](
	[TradeID] [int] NOT NULL,
	[IsBuy] [bit] NOT NULL,
	[Quantity] [float] NOT NULL,
	[InstrumentID] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[RateID] [int] NOT NULL,
	[StockID] [int] NOT NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_Instrument] FOREIGN KEY([InstrumentID])
REFERENCES [dbo].[Instrument] ([ID])
GO

ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_Instrument]
GO

ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_InterestRate] FOREIGN KEY([RateID])
REFERENCES [dbo].[InterestRate] ([RateID])
GO

ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_InterestRate]
GO

ALTER TABLE [dbo].[Trade]  WITH CHECK ADD  CONSTRAINT [FK_Trade_StockPrice] FOREIGN KEY([StockID])
REFERENCES [dbo].[StockPrice] ([ID])
GO

ALTER TABLE [dbo].[Trade] CHECK CONSTRAINT [FK_Trade_StockPrice]
GO

