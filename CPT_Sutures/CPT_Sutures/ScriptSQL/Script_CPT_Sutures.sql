USE [CPT_Sutures]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 10/15/2022 10:03:02 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Type]') AND type in (N'U'))
DROP TABLE [dbo].[Type]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/15/2022 10:03:02 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/15/2022 10:03:02 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/15/2022 10:03:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/15/2022 10:03:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NULL,
	[Descrip] [nvarchar](max) NULL,
	[Image] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
	[TypeId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 10/15/2022 10:03:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Vật tư y tế')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [Descrip], [Image], [CategoryId], [TypeId], [Price]) VALUES (1, N'Dao mổ CPT Số 10', N'Có lưỡi cắt cong lớn, thường được sử dụng để tạo ra vết rạch kích thước lớn trên da và cơ, hoặc phẫu thuật chuyên biệt như lấy động mạch quay trong phẫu thuật bắc cầu động mạch vành, mở phế quản trong phẫu thuật lồng ngực, rạch tử cung trong sinh mổ (mổ lấy thai còn gọi là mổ bắt con hoặc mổ Cesar) và sửa chữa thoát vị bẹn.', N'https://cpt-medical.com/wp-content/uploads/2020/10/Dao-mo-CPT-So-10.jpg', 1, 1, CAST(0 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 
GO
INSERT [dbo].[Type] ([TypeId], [TypeName]) VALUES (1, N'Vật liệu cầm máu Carecel')
GO
INSERT [dbo].[Type] ([TypeId], [TypeName]) VALUES (2, N'Vật liệu cầm máu Carecel')
GO
INSERT [dbo].[Type] ([TypeId], [TypeName]) VALUES (3, N'Vật liệu cầm máu Carecel')
GO
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
