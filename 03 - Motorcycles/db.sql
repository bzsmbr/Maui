USE [master]
GO
/****** Object:  Database [MotorcycleDB]    Script Date: 2/17/2025 6:33:16 PM ******/
CREATE DATABASE [MotorcycleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MotorcycleDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MotorcycleDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MotorcycleDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MotorcycleDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MotorcycleDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MotorcycleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MotorcycleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MotorcycleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MotorcycleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MotorcycleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MotorcycleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MotorcycleDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MotorcycleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MotorcycleDB] SET AUTO_UPDATE_STATISTICS ON 
USE [MotorcycleDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/17/2025 6:33:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 2/17/2025 6:33:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motorcycle]    Script Date: 2/17/2025 6:33:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motorcycle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PublicId] [nvarchar](128) NOT NULL,
	[Model] [nvarchar](128) NOT NULL,
	[Cubic] [bigint] NOT NULL,
	[ReleaseYear] [bigint] NOT NULL,
	[Cylinders] [bigint] NOT NULL,
	[ManufacturerId] [bigint] NOT NULL,
	[ImageId] [nvarchar](128) NULL,
	[WebContentLink] [nvarchar](512) NULL,
	[TypeId] [bigint] NOT NULL,
 CONSTRAINT [PK_Motorcycle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 2/17/2025 6:33:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250116073519_init', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250122082125_manufacturers', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250216104727_MotorcycleEntity_add_image_support', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250217164306_MotorcycleTypeEntity', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250217164550_MotorcycleTypeEntity_data', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250217170103_MotorcycleTypeEntity_fix', N'9.0.0')
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (5, N'Harley-Davidson')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (1, N'Honda')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (6, N'Kawasaki')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (3, N'Suzuki')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (4, N'Triumph')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (2, N'Yamaha')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[Motorcycle] ON 

INSERT [dbo].[Motorcycle] ([Id], [PublicId], [Model], [Cubic], [ReleaseYear], [Cylinders], [ManufacturerId], [ImageId], [WebContentLink], [TypeId]) VALUES (1, N'c90d801f-e7ab-4e22-a5b7-32735abea16c', N'Tiger Sport 660', 660, 2024, 3, 4, N'1JmsG9rBTowUsCT5tzpY5Jn6aYeh5kOIT', N'https://drive.google.com/uc?id=1JmsG9rBTowUsCT5tzpY5Jn6aYeh5kOIT', 20)
SET IDENTITY_INSERT [dbo].[Motorcycle] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([Id], [Name]) VALUES (11, N'ATV')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (1, N'Chopper')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (3, N'Classic')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (5, N'Cross')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (2, N'Crusier')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (7, N'Enduro')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (8, N'Kidkmotor')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (16, N'Moped')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (21, N'Naked')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (6, N'Pitpike')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (10, N'Quad')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (12, N'RUV')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (15, N'Scooter')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (9, N'Sport')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (13, N'SSV')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (17, N'Supermoto')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (20, N'Tour')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (18, N'Trial')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (19, N'Trike')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (14, N'UTV')
INSERT [dbo].[Type] ([Id], [Name]) VALUES (4, N'Veteran')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Manufacturer_Name]    Script Date: 2/17/2025 6:33:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Manufacturer_Name] ON [dbo].[Manufacturer]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Motorcycle_ManufacturerId]    Script Date: 2/17/2025 6:33:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Motorcycle_ManufacturerId] ON [dbo].[Motorcycle]
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Motorcycle_TypeId]    Script Date: 2/17/2025 6:33:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Motorcycle_TypeId] ON [dbo].[Motorcycle]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Type_Name]    Script Date: 2/17/2025 6:33:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Type_Name] ON [dbo].[Type]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Motorcycle] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [TypeId]
GO
ALTER TABLE [dbo].[Motorcycle]  WITH CHECK ADD  CONSTRAINT [FK_Motorcycle_Manufacturer_ManufacturerId] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Motorcycle] CHECK CONSTRAINT [FK_Motorcycle_Manufacturer_ManufacturerId]
GO
ALTER TABLE [dbo].[Motorcycle]  WITH CHECK ADD  CONSTRAINT [FK_Motorcycle_Type_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Motorcycle] CHECK CONSTRAINT [FK_Motorcycle_Type_TypeId]
GO
USE [master]
GO
ALTER DATABASE [MotorcycleDB] SET  READ_WRITE 
GO
