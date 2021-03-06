USE [master]
GO
/****** Object:  Database [QLSACH]    Script Date: 23/12/2016 11:47:52 PM ******/
CREATE DATABASE [QLSACH] ON  PRIMARY 
( NAME = N'QLSACH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\QLSACH.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLSACH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\QLSACH_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLSACH] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSACH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLSACH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLSACH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLSACH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLSACH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLSACH] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLSACH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLSACH] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLSACH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLSACH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLSACH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLSACH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLSACH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLSACH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLSACH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLSACH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLSACH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLSACH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLSACH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLSACH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLSACH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLSACH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLSACH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLSACH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLSACH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLSACH] SET  MULTI_USER 
GO
ALTER DATABASE [QLSACH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLSACH] SET DB_CHAINING OFF 
GO
USE [QLSACH]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 23/12/2016 11:47:52 PM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[db_owner]
GO
/****** Object:  StoredProcedure [dbo].[TimkiemDaily]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TimkiemDaily]
@s nvarchar(256)
as
begin
select * from daily where madl like '%'+@s+'%';
end

GO
/****** Object:  StoredProcedure [dbo].[TimkiemNXB]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TimkiemNXB]
@s nvarchar(256)
as
begin
select * from nxb where manxb like '%'+@s+'%';
end


GO
/****** Object:  StoredProcedure [dbo].[TimkiemSach]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TimkiemSach]
@s nvarchar(256)
as
begin
select * from sach where masach like '%'+@s+'%';
end

GO
/****** Object:  Table [dbo].[ctphieunhap]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctphieunhap](
	[maso] [nvarchar](128) NOT NULL,
	[masach] [nvarchar](128) NOT NULL,
	[soluong] [int] NOT NULL,
	[gia] [int] NOT NULL,
	[thanhtien] [int] NOT NULL,
	[tienno] [int] NULL,
	[ton] [int] NULL,
 CONSTRAINT [PK_ctphieunhap] PRIMARY KEY CLUSTERED 
(
	[maso] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ctphieuxuat]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctphieuxuat](
	[maso] [nvarchar](128) NOT NULL,
	[masach] [nvarchar](128) NOT NULL,
	[soluong] [int] NOT NULL,
	[gia] [int] NOT NULL,
	[thanhtien] [int] NOT NULL,
	[maphieunhap] [nvarchar](128) NULL,
	[tienno] [int] NULL,
 CONSTRAINT [PK_ctphieuxuat] PRIMARY KEY CLUSTERED 
(
	[maso] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cttkdl]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cttkdl](
	[maso] [nvarchar](128) NOT NULL,
	[masach] [nvarchar](128) NOT NULL,
	[sluong] [int] NOT NULL,
 CONSTRAINT [PK_cttkdl] PRIMARY KEY CLUSTERED 
(
	[maso] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[daily]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[daily](
	[madl] [nvarchar](128) NOT NULL,
	[tendl] [nvarchar](256) NOT NULL,
	[dchi] [nvarchar](256) NOT NULL,
	[sdt] [nvarchar](32) NOT NULL,
	[tonkho] [int] NOT NULL,
 CONSTRAINT [PK_daily_1] PRIMARY KEY CLUSTERED 
(
	[madl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hdondl]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hdondl](
	[maso] [nvarchar](128) NOT NULL,
	[madl] [nvarchar](128) NOT NULL,
	[ngay] [date] NOT NULL,
	[sotien] [int] NOT NULL,
 CONSTRAINT [PK_hdondl] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hdonnxb]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hdonnxb](
	[maso] [nvarchar](128) NOT NULL,
	[manxb] [nvarchar](128) NOT NULL,
	[ngay] [date] NOT NULL,
	[sotien] [int] NOT NULL,
 CONSTRAINT [PK_hdonnxb] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[linhvuc]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linhvuc](
	[malv] [nvarchar](128) NOT NULL,
	[tenlv] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_linhvuc] PRIMARY KEY CLUSTERED 
(
	[malv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nxb]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nxb](
	[manxb] [nvarchar](128) NOT NULL,
	[tennxb] [nvarchar](256) NOT NULL,
	[dchi] [nvarchar](256) NOT NULL,
	[sdt] [nvarchar](32) NOT NULL,
	[tonkho] [int] NOT NULL,
 CONSTRAINT [PK_nxb] PRIMARY KEY CLUSTERED 
(
	[manxb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[phieunhap]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieunhap](
	[maso] [nvarchar](128) NOT NULL,
	[manxb] [nvarchar](128) NOT NULL,
	[nguoigiao] [nvarchar](256) NOT NULL,
	[tgian] [date] NOT NULL,
	[tongtien] [int] NOT NULL,
 CONSTRAINT [PK_phieunhap] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[phieuxuat]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieuxuat](
	[maso] [nvarchar](128) NOT NULL,
	[madl] [nvarchar](128) NOT NULL,
	[nguoinhan] [nvarchar](256) NOT NULL,
	[tgian] [date] NOT NULL,
	[tongtien] [int] NOT NULL,
 CONSTRAINT [PK_phieuxuat] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sach]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sach](
	[masach] [nvarchar](128) NOT NULL,
	[tensach] [nvarchar](256) NOT NULL,
	[linhvuc] [nvarchar](128) NOT NULL,
	[sluong] [int] NOT NULL,
 CONSTRAINT [PK_sach] PRIMARY KEY CLUSTERED 
(
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tkdl]    Script Date: 23/12/2016 11:47:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tkdl](
	[maso] [nvarchar](128) NOT NULL,
	[madl] [nvarchar](128) NOT NULL,
	[ngay] [date] NOT NULL,
 CONSTRAINT [PK_tkdl] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201611050732', N'8934974135593', 3, 75000, 225000, 225000, 3)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201611050803', N'8934974135593', 4, 75000, 300000, 300000, 4)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201611050803', N'8935201510381', 4, 85000, 340000, 340000, 2)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201611061014', N'8934974135593', 2, 20000, 40000, 40000, 2)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201611061247', N'8934974135593', 3, 15000, 45000, 45000, 3)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201612050856', N'5555555', 50, 100000, 5000000, 5000000, 50)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien], [tienno], [ton]) VALUES (N'201612160255', N'777777', 6, 10000, 60000, 60000, 2)
INSERT [dbo].[ctphieuxuat] ([maso], [masach], [soluong], [gia], [thanhtien], [maphieunhap], [tienno]) VALUES (N'123', N'8934974135593', 1, 30000, 30000, N'201611061247', 3000)
INSERT [dbo].[ctphieuxuat] ([maso], [masach], [soluong], [gia], [thanhtien], [maphieunhap], [tienno]) VALUES (N'123', N'8935201510381', 2, 100000, 200000, N'201611050803', 200000)
INSERT [dbo].[ctphieuxuat] ([maso], [masach], [soluong], [gia], [thanhtien], [maphieunhap], [tienno]) VALUES (N'201612160250', N'8935201510381', 2, 88000, 176000, N'201611050803', 176000)
INSERT [dbo].[ctphieuxuat] ([maso], [masach], [soluong], [gia], [thanhtien], [maphieunhap], [tienno]) VALUES (N'201612160321', N'777777', 4, 16000, 64000, N'201612160255', 64000)
INSERT [dbo].[daily] ([madl], [tendl], [dchi], [sdt], [tonkho]) VALUES (N'KOKOk', N'Không Ông Khá Ô Kị', N'neiwufuiehduiw', N'0123456789', 64000)
INSERT [dbo].[daily] ([madl], [tendl], [dchi], [sdt], [tonkho]) VALUES (N'THANGA', N'Thà Ngã', N'288 An Dương Vương, 4, Quận 5, Hồ Chí Minh', N'08 3835 3875', 0)
INSERT [dbo].[daily] ([madl], [tendl], [dchi], [sdt], [tonkho]) VALUES (N'THANHNGHIA', N'Nhà sách Thành Nghĩa', N'288 An Dương Vương, 4, Quận 5, Hồ Chí Minh', N'08 3835 3875', 406000)
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'KHOAHOC', N'Khoa học')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'KINANGSONG', N'Kĩ năng sống')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'SGK', N'Sách giáo khoa')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'TAMLY', N'Tâm lý')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'THIEUNHI', N'Thiếu nhi')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'TRINHTHAM', N'Trinh thám')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'VANHOC', N'Văn học')
INSERT [dbo].[nxb] ([manxb], [tennxb], [dchi], [sdt], [tonkho]) VALUES (N'KOKO', N'Khách Ông Không Ó', N'ugiwugjuierjfui', N'123456897', 60000)
INSERT [dbo].[nxb] ([manxb], [tennxb], [dchi], [sdt], [tonkho]) VALUES (N'TRE', N'Nhà xuất bản Trẻ', N'161B, phường 7, Lý Chính Thắng, Quận 3, tp Hồ Chí Minh', N'0838444289', 5610000)
INSERT [dbo].[nxb] ([manxb], [tennxb], [dchi], [sdt], [tonkho]) VALUES (N'VHSG', N'Văn Hóa Sài Gòn', N'90 Ký Con, Nguyễn Thái Bình, Quận 1, Hồ Chí Minh', N'0838216009', 640000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611050732', N'TRE', N'Nguyễn Văn C', CAST(0x1A3C0B00 AS Date), 225000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611050803', N'VHSG', N'Nguyễn Văn D', CAST(0x1B3C0B00 AS Date), 640000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611061014', N'TRE', N'Nguyễn Văn Hai', CAST(0x123C0B00 AS Date), 40000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611061247', N'TRE', N'Nguyễn Văn C', CAST(0x133C0B00 AS Date), 45000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201612050856', N'TRE', N'L6e Hoa hòng', CAST(0x2E3C0B00 AS Date), 5000000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201612160255', N'KOKO', N'Hồng Lụn', CAST(0x2F3C0B00 AS Date), 60000)
INSERT [dbo].[phieuxuat] ([maso], [madl], [nguoinhan], [tgian], [tongtien]) VALUES (N'123', N'THANHNGHIA', N'Hoàng Thanh', CAST(0x1D3C0B00 AS Date), 230000)
INSERT [dbo].[phieuxuat] ([maso], [madl], [nguoinhan], [tgian], [tongtien]) VALUES (N'201612160250', N'THANHNGHIA', N'dsadasda', CAST(0x393C0B00 AS Date), 176000)
INSERT [dbo].[phieuxuat] ([maso], [madl], [nguoinhan], [tgian], [tongtien]) VALUES (N'201612160321', N'KOKOk', N'mpndiqnd', CAST(0x403C0B00 AS Date), 64000)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'123456789', N'Hàn Quốc', N'SGK', 0)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'123456790', N'Việt Nam', N'THIEUNHI', 0)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'5555555', N'Hoàng Hiu', N'TAMLY', 50)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'777777', N'Hoàng ', N'SGK', 2)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'8934974135593', N'Tony Buổi Sáng', N'TRINHTHAM', 11)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'8935201510381', N'Trốn chạy', N'THIEUNHI', 0)
ALTER TABLE [dbo].[ctphieunhap]  WITH CHECK ADD  CONSTRAINT [FK_ctphieunhap_phieunhap] FOREIGN KEY([maso])
REFERENCES [dbo].[phieunhap] ([maso])
GO
ALTER TABLE [dbo].[ctphieunhap] CHECK CONSTRAINT [FK_ctphieunhap_phieunhap]
GO
ALTER TABLE [dbo].[ctphieunhap]  WITH CHECK ADD  CONSTRAINT [FK_ctphieunhap_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[ctphieunhap] CHECK CONSTRAINT [FK_ctphieunhap_sach]
GO
ALTER TABLE [dbo].[ctphieuxuat]  WITH CHECK ADD  CONSTRAINT [FK_ctphieuxuat_ctphieunhap] FOREIGN KEY([maphieunhap])
REFERENCES [dbo].[phieunhap] ([maso])
GO
ALTER TABLE [dbo].[ctphieuxuat] CHECK CONSTRAINT [FK_ctphieuxuat_ctphieunhap]
GO
ALTER TABLE [dbo].[ctphieuxuat]  WITH CHECK ADD  CONSTRAINT [FK_ctphieuxuat_phieuxuat] FOREIGN KEY([maso])
REFERENCES [dbo].[phieuxuat] ([maso])
GO
ALTER TABLE [dbo].[ctphieuxuat] CHECK CONSTRAINT [FK_ctphieuxuat_phieuxuat]
GO
ALTER TABLE [dbo].[ctphieuxuat]  WITH CHECK ADD  CONSTRAINT [FK_ctphieuxuat_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[ctphieuxuat] CHECK CONSTRAINT [FK_ctphieuxuat_sach]
GO
ALTER TABLE [dbo].[cttkdl]  WITH CHECK ADD  CONSTRAINT [FK_cttkdl_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[cttkdl] CHECK CONSTRAINT [FK_cttkdl_sach]
GO
ALTER TABLE [dbo].[cttkdl]  WITH CHECK ADD  CONSTRAINT [FK_cttkdl_tkdl] FOREIGN KEY([maso])
REFERENCES [dbo].[tkdl] ([maso])
GO
ALTER TABLE [dbo].[cttkdl] CHECK CONSTRAINT [FK_cttkdl_tkdl]
GO
ALTER TABLE [dbo].[hdondl]  WITH CHECK ADD  CONSTRAINT [FK_hdondl_daily] FOREIGN KEY([madl])
REFERENCES [dbo].[daily] ([madl])
GO
ALTER TABLE [dbo].[hdondl] CHECK CONSTRAINT [FK_hdondl_daily]
GO
ALTER TABLE [dbo].[hdonnxb]  WITH CHECK ADD  CONSTRAINT [FK_hdonnxb_nxb] FOREIGN KEY([manxb])
REFERENCES [dbo].[nxb] ([manxb])
GO
ALTER TABLE [dbo].[hdonnxb] CHECK CONSTRAINT [FK_hdonnxb_nxb]
GO
ALTER TABLE [dbo].[phieunhap]  WITH CHECK ADD  CONSTRAINT [FK_phieunhap_nxb] FOREIGN KEY([manxb])
REFERENCES [dbo].[nxb] ([manxb])
GO
ALTER TABLE [dbo].[phieunhap] CHECK CONSTRAINT [FK_phieunhap_nxb]
GO
ALTER TABLE [dbo].[phieuxuat]  WITH CHECK ADD  CONSTRAINT [FK_phieuxuat_daily] FOREIGN KEY([madl])
REFERENCES [dbo].[daily] ([madl])
GO
ALTER TABLE [dbo].[phieuxuat] CHECK CONSTRAINT [FK_phieuxuat_daily]
GO
ALTER TABLE [dbo].[sach]  WITH CHECK ADD  CONSTRAINT [FK_sach_linhvuc] FOREIGN KEY([linhvuc])
REFERENCES [dbo].[linhvuc] ([malv])
GO
ALTER TABLE [dbo].[sach] CHECK CONSTRAINT [FK_sach_linhvuc]
GO
ALTER TABLE [dbo].[tkdl]  WITH CHECK ADD  CONSTRAINT [FK_daily_tkdl] FOREIGN KEY([madl])
REFERENCES [dbo].[daily] ([madl])
GO
ALTER TABLE [dbo].[tkdl] CHECK CONSTRAINT [FK_daily_tkdl]
GO
USE [master]
GO
ALTER DATABASE [QLSACH] SET  READ_WRITE 
GO
