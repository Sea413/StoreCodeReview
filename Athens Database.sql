create database shoe_stores
USE [shoe_stores]
GO
/****** Object:  Table [dbo].[brands]    Script Date: 3/4/2016 3:44:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stores]    Script Date: 3/4/2016 3:44:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stores_brands]    Script Date: 3/4/2016 3:44:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores_brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[store_id] [int] NULL,
	[brand_id] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[stores_brands] ON 

INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (1, 1, 3)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (2, 15, 5)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (3, 18, 6)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (4, 20, 8)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (5, 18, 8)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (6, 22, 10)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (7, 22, 10)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (8, 22, 15)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (9, 23, 11)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (10, 23, 10)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (11, 23, 15)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (12, 23, 11)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (13, 24, 16)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (14, 26, 16)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (15, 24, 17)
INSERT [dbo].[stores_brands] ([id], [store_id], [brand_id]) VALUES (16, 24, 17)
SET IDENTITY_INSERT [dbo].[stores_brands] OFF
