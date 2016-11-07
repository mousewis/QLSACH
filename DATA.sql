USE [QLSACH]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 11/7/2016 11:25:32 PM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[ctphieunhap]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctphieunhap](
	[maso] [nchar](128) NOT NULL,
	[masach] [nchar](128) NOT NULL,
	[soluong] [int] NOT NULL,
	[gia] [int] NOT NULL,
	[thanhtien] [int] NOT NULL,
 CONSTRAINT [PK_ctphieunhap] PRIMARY KEY CLUSTERED 
(
	[maso] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ctphieuxuat]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctphieuxuat](
	[maso] [nchar](128) NOT NULL,
	[masach] [nchar](128) NOT NULL,
	[soluong] [int] NOT NULL,
	[gia] [int] NOT NULL,
	[thanhtien] [int] NOT NULL,
 CONSTRAINT [PK_ctphieuxuat] PRIMARY KEY CLUSTERED 
(
	[maso] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cttkdl]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cttkdl](
	[maso] [nchar](128) NOT NULL,
	[masach] [nchar](128) NOT NULL,
	[sluong] [int] NOT NULL,
 CONSTRAINT [PK_cttkdl] PRIMARY KEY CLUSTERED 
(
	[maso] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[daily]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[daily](
	[madl] [nchar](128) NOT NULL,
	[tendl] [nvarchar](256) NOT NULL,
	[dchi] [nvarchar](256) NOT NULL,
	[sdt] [nchar](32) NOT NULL,
	[tonkho] [int] NOT NULL,
 CONSTRAINT [PK_daily_1] PRIMARY KEY CLUSTERED 
(
	[madl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hdondl]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hdondl](
	[maso] [nchar](128) NOT NULL,
	[madl] [nchar](128) NOT NULL,
	[ngay] [date] NOT NULL,
	[sotien] [int] NOT NULL,
 CONSTRAINT [PK_hdondl] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hdonnxb]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hdonnxb](
	[maso] [nchar](128) NOT NULL,
	[manxb] [nchar](128) NOT NULL,
	[ngay] [date] NOT NULL,
	[sotien] [int] NOT NULL,
 CONSTRAINT [PK_hdonnxb] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[linhvuc]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linhvuc](
	[malv] [nchar](128) NOT NULL,
	[tenlv] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_linhvuc] PRIMARY KEY CLUSTERED 
(
	[malv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nxb]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nxb](
	[manxb] [nchar](128) NOT NULL,
	[tennxb] [nvarchar](256) NOT NULL,
	[dchi] [nvarchar](256) NOT NULL,
	[sdt] [nchar](32) NOT NULL,
	[tonkho] [int] NOT NULL,
 CONSTRAINT [PK_nxb] PRIMARY KEY CLUSTERED 
(
	[manxb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[phieunhap]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieunhap](
	[maso] [nchar](128) NOT NULL,
	[manxb] [nchar](128) NOT NULL,
	[nguoigiao] [nvarchar](256) NOT NULL,
	[tgian] [date] NOT NULL,
	[tongtien] [int] NOT NULL,
 CONSTRAINT [PK_phieunhap] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[phieuxuat]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieuxuat](
	[maso] [nchar](128) NOT NULL,
	[madl] [nchar](128) NOT NULL,
	[nguoinhan] [nvarchar](256) NOT NULL,
	[tgian] [date] NOT NULL,
	[tongtien] [int] NOT NULL,
 CONSTRAINT [PK_phieuxuat] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sach]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sach](
	[masach] [nchar](128) NOT NULL,
	[tensach] [nvarchar](256) NOT NULL,
	[linhvuc] [nchar](128) NOT NULL,
	[sluong] [int] NOT NULL,
 CONSTRAINT [PK_sach] PRIMARY KEY CLUSTERED 
(
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tkdl]    Script Date: 11/7/2016 11:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tkdl](
	[maso] [nchar](128) NOT NULL,
	[madl] [nchar](128) NOT NULL,
	[ngay] [date] NOT NULL,
 CONSTRAINT [PK_tkdl] PRIMARY KEY CLUSTERED 
(
	[maso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien]) VALUES (N'201611050732                                                                                                                    ', N'8934974135593                                                                                                                   ', 0, 75000, 225000)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien]) VALUES (N'201611050803                                                                                                                    ', N'8934974135593                                                                                                                   ', 4, 75000, 300000)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien]) VALUES (N'201611050803                                                                                                                    ', N'8935201510381                                                                                                                   ', 4, 85000, 340000)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien]) VALUES (N'201611061003                                                                                                                    ', N'8935201510381                                                                                                                   ', 4, 3, 12)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien]) VALUES (N'201611061014                                                                                                                    ', N'8934974135593                                                                                                                   ', 2, 20000, 40000)
INSERT [dbo].[ctphieunhap] ([maso], [masach], [soluong], [gia], [thanhtien]) VALUES (N'201611061247                                                                                                                    ', N'8934974135593                                                                                                                   ', 3, 15000, 45000)
INSERT [dbo].[daily] ([madl], [tendl], [dchi], [sdt], [tonkho]) VALUES (N'THANHNGHIA                                                                                                                      ', N'Nhà sách Thành Nghĩa', N'288 An Dương Vương, 4, Quận 5, Hồ Chí Minh', N'08 3835 3875                    ', 0)
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'KHOAHOC                                                                                                                         ', N'Khoa học')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'KINANGSONG                                                                                                                      ', N'Kĩ năng sống')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'SGK                                                                                                                             ', N'Sách giáo khoa')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'TAMLY                                                                                                                           ', N'Tâm lý')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'THIEUNHI                                                                                                                        ', N'Thiếu nhi')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'TRINHTHAM                                                                                                                       ', N'Trinh thám')
INSERT [dbo].[linhvuc] ([malv], [tenlv]) VALUES (N'VANHOC                                                                                                                          ', N'Văn học')
INSERT [dbo].[nxb] ([manxb], [tennxb], [dchi], [sdt], [tonkho]) VALUES (N'                                                                                                                                ', N'                 ', N'           ', N'                                ', 12)
INSERT [dbo].[nxb] ([manxb], [tennxb], [dchi], [sdt], [tonkho]) VALUES (N'TRE                                                                                                                             ', N'Nhà xuất bản Trẻ', N'161B, phường 7, Lý Chính Thắng, Quận 3, tp Hồ Chí Minh', N'0838444289                      ', 610000)
INSERT [dbo].[nxb] ([manxb], [tennxb], [dchi], [sdt], [tonkho]) VALUES (N'VHSG                                                                                                                            ', N'Văn Hóa Sài Gòn', N'90 Ký Con, Nguyễn Thái Bình, Quận 1, Hồ Chí Minh', N'0838216009                      ', 640000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201610310151                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn A', CAST(N'2016-10-31' AS Date), 200000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201610310155                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn B', CAST(N'2016-10-19' AS Date), 500000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201610310156                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn D', CAST(N'2016-10-19' AS Date), 580000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201610310349                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn E', CAST(N'2016-10-19' AS Date), 500000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'20161105                                                                                                                        ', N'TRE                                                                                                                             ', N'Nguyễn Văn A', CAST(N'2016-11-05' AS Date), 225000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611050635                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn B', CAST(N'2016-11-07' AS Date), 150000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611050719                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn C', CAST(N'2016-11-22' AS Date), 150000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611050732                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn C', CAST(N'2016-11-15' AS Date), 225000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611050803                                                                                                                    ', N'VHSG                                                                                                                            ', N'Nguyễn Văn D', CAST(N'2016-11-16' AS Date), 640000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611061003                                                                                                                    ', N'                                                                                                                                ', N'             ', CAST(N'2016-11-08' AS Date), 12)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611061014                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn Hai', CAST(N'2016-11-07' AS Date), 40000)
INSERT [dbo].[phieunhap] ([maso], [manxb], [nguoigiao], [tgian], [tongtien]) VALUES (N'201611061247                                                                                                                    ', N'TRE                                                                                                                             ', N'Nguyễn Văn C', CAST(N'2016-11-08' AS Date), 45000)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'8934974135593                                                                                                                   ', N'Tony Buổi Sáng', N'SGK                                                                                                                             ', 62)
INSERT [dbo].[sach] ([masach], [tensach], [linhvuc], [sluong]) VALUES (N'8935201510381                                                                                                                   ', N'Trốn chạy', N'KINANGSONG                                                                                                                      ', 8)
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
/****** Object:  StoredProcedure [dbo].[TimkiemDaily]    Script Date: 11/7/2016 11:25:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[TimkiemNXB]    Script Date: 11/7/2016 11:25:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[TimkiemSach]    Script Date: 11/7/2016 11:25:32 PM ******/
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
