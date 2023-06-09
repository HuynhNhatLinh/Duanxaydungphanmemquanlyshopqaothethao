
/****** Object:  User [hh]    Script Date: 5/19/2023 2:47:30 PM ******/
CREATE USER [hh] FOR LOGIN [hh] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [huynhhoc]    Script Date: 5/19/2023 2:47:30 PM ******/
CREATE USER [huynhhoc] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [hh]
GO
ALTER ROLE [db_owner] ADD MEMBER [huynhhoc]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [varchar](5) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [nchar](10) NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaPhieuNhap] [varchar](5) NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[TenDangNhap] [nchar](50) NULL,
	[MatKhau] [nchar](50) NULL,
	[Email] [nchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](5) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaNhanVien] [int] NULL,
	[MaKhachHang] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[DienThoai] [varchar](15) NULL,
	[NgaySinh] [date] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaCungCap] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[DienThoai] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DienThoai] [varchar](15) NULL,
	[GioiTinh] [nvarchar](100) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [varchar](5) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaNhanVien] [int] NULL,
	[MaNhaCungCap] [int] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[GiaNhap] [decimal](18, 0) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[SoLuong] [int] NULL,
	[LoaiSanPham] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD011', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD011', 42, N'2         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD012', 38, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD013', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD014', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD014', 38, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD014', 39, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD015', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD016', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD017', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD018', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD019', 38, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD020', 40, N'2         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD020', 42, N'2         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD021', 38, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD021', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD022', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD023', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD023', 42, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD024', 39, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD025', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD026', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD027', 39, N'23        ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD028', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD028', 39, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD029', 39, N'6         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD030', 40, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD031', 39, N'4         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD032', 41, N'4         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD033', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD034', 37, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD034', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD035', 39, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD036', 42, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD037', 42, N'100       ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD038', 38, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD038', 40, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD039', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD040', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD040', 42, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD041', 42, N'2         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD042', 40, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD042', 41, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD043', 37, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD043', 39, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD044', 38, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD044', 42, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD045', 39, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD045', 40, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD046', 36, N'1         ')
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong]) VALUES (N'HD047', 36, N'1         ')
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN001', 36, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN002', 37, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN003', 38, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN004', 39, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN005', 40, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN006', 41, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN007', 42, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN008', 39, 9)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN009', 37, 8)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN009', 39, 1)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN010', 36, 1)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN010', 40, 5)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN011', 36, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN012', 36, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN013', 42, 100)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN014', 38, 33)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN015', 42, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN016', 41, 10)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN017', 39, 30)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuong]) VALUES (N'PN018', 39, 1)
GO
INSERT [dbo].[DangNhap] ([TenDangNhap], [MatKhau], [Email]) VALUES (N'admin                                             ', N'1                                                 ', N'huynhhoc1405@gmail.com                            ')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD001', CAST(N'2022-03-20T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD002', CAST(N'2022-03-20T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD003', CAST(N'2022-03-20T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD004', CAST(N'2022-05-15T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD005', CAST(N'2022-05-15T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD006', CAST(N'2022-05-15T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD007', CAST(N'2022-05-15T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD008', CAST(N'2022-05-20T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD009', CAST(N'2022-05-20T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD010', CAST(N'2022-05-20T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD011', CAST(N'2023-04-06T00:00:00.000' AS DateTime), 31, 4)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD012', CAST(N'2023-04-07T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD013', CAST(N'2023-04-07T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD014', CAST(N'2023-04-10T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD015', CAST(N'2023-04-10T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD016', CAST(N'2023-04-10T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD017', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD018', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD019', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD020', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD021', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD022', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD023', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD024', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD025', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD026', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD027', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD028', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD029', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD030', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD031', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD032', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD033', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD034', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD035', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 39, 4)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD036', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 5)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD037', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD038', CAST(N'2023-05-01T00:00:00.000' AS DateTime), 39, 6)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD039', CAST(N'2023-05-02T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD040', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD041', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 39, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD042', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD043', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD044', CAST(N'2023-05-03T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD045', CAST(N'2023-05-06T00:00:00.000' AS DateTime), 31, 5)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD046', CAST(N'2023-05-13T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [MaNhanVien], [MaKhachHang]) VALUES (N'HD047', CAST(N'2023-05-13T00:00:00.000' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [DiaChi], [DienThoai], [NgaySinh]) VALUES (1, N'Huỳnh Học', N'Bình Thuận', N'0345321123', CAST(N'2003-09-19' AS Date))
INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [DiaChi], [DienThoai], [NgaySinh]) VALUES (2, N'Trần Thị Hoa', N'Bình Thuận', N'0345321553', CAST(N'1995-03-20' AS Date))
INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [DiaChi], [DienThoai], [NgaySinh]) VALUES (4, N'Anh Kha', N'HTN', N'34343434', CAST(N'2020-09-06' AS Date))
INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [DiaChi], [DienThoai], [NgaySinh]) VALUES (5, N'Ronaldo', N'Bồ Đào Nha', N'048473722', CAST(N'2023-02-28' AS Date))
INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [DiaChi], [DienThoai], [NgaySinh]) VALUES (6, N'Harry Kane', N'English ', N'114', CAST(N'1995-03-20' AS Date))
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (11, N'Tee', 0)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (12, N'T-Shirt', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (13, N'Hoodie ', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (14, N'Polo', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (15, N'Pants', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (16, N'Dép', 0)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (17, N'SLIPPER', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (18, N'Phụ kiện', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (19, N'Giày', 1)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (21, N'Áo Sweater', 0)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (22, NULL, NULL)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (23, N'', 0)
INSERT [dbo].[LoaiSanPham] ([ID], [TenLoai], [Status]) VALUES (24, N'', 0)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([ID], [TenNhaCungCap], [DiaChi], [DienThoai], [Status]) VALUES (1, N'HADES', N'Quận 1, Thành Phố HCM', 1234567324, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNhaCungCap], [DiaChi], [DienThoai], [Status]) VALUES (2, N'HADES', N'Quận 1, Thành Phố HCM', 1234567324, 0)
INSERT [dbo].[NhaCungCap] ([ID], [TenNhaCungCap], [DiaChi], [DienThoai], [Status]) VALUES (3, N'Levent', N'Quận 2, Thành Phố HCM', 29738273, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNhaCungCap], [DiaChi], [DienThoai], [Status]) VALUES (4, N'Sly', N'Quận 3,Thành Phố HCM', 13863223, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNhaCungCap], [DiaChi], [DienThoai], [Status]) VALUES (6, N'Dirty coins !', N'Quận 5, Thành Phố HCM', 168273623, 1)
INSERT [dbo].[NhaCungCap] ([ID], [TenNhaCungCap], [DiaChi], [DienThoai], [Status]) VALUES (8, N'', N'', 0, 0)
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [NgaySinh], [DienThoai], [GioiTinh], [Status]) VALUES (1, N'Nguyễn Văn A', CAST(N'1995-02-03' AS Date), N'0123456789', N'Nam       ', 1)
INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [NgaySinh], [DienThoai], [GioiTinh], [Status]) VALUES (31, N'Dalot', CAST(N'1990-09-07' AS Date), N'0396406672', N'Nam       ', 1)
INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [NgaySinh], [DienThoai], [GioiTinh], [Status]) VALUES (35, N'Huỳnh Ngọc Thái Học', CAST(N'2003-09-19' AS Date), N'0396406672', N'Nam       ', 1)
INSERT [dbo].[NhanVien] ([ID], [TenNhanVien], [NgaySinh], [DienThoai], [GioiTinh], [Status]) VALUES (39, N'Messi', CAST(N'2023-10-12' AS Date), N'113', N'Nữ        ', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN001', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN002', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN003', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN004', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN005', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN006', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN007', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN008', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN009', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN010', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN011', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN012', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN013', CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN014', CAST(N'2023-05-01T00:00:00.000' AS DateTime), 39, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN015', CAST(N'2023-05-01T00:00:00.000' AS DateTime), 35, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN016', CAST(N'2023-05-05T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN017', CAST(N'2023-05-05T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhanVien], [MaNhaCungCap]) VALUES (N'PN018', CAST(N'2023-05-06T00:00:00.000' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (36, N'Chonky Kittens T-shirt', CAST(200000 AS Decimal(18, 0)), CAST(400000 AS Decimal(18, 0)), 999, 12, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (37, N'Club Wash Polo - Grey', CAST(250000 AS Decimal(18, 0)), CAST(500000 AS Decimal(18, 0)), 999, 14, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (38, N'Chingu Hoodie - Grey', CAST(350000 AS Decimal(18, 0)), CAST(700000 AS Decimal(18, 0)), 999, 13, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (39, N'Gothic Double Knee Pants - Green', CAST(400000 AS Decimal(18, 0)), CAST(800000 AS Decimal(18, 0)), 999, 15, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (40, N' ESSENTIAL 2.0 SLIPPER', CAST(20000 AS Decimal(18, 0)), CAST(500000 AS Decimal(18, 0)), 99, 17, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (41, N'Dây chuyền Luivuiton', CAST(200000 AS Decimal(18, 0)), CAST(1000000 AS Decimal(18, 0)), 9999, 18, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (42, N'Jordan 1 cổ điển cao', CAST(100000 AS Decimal(18, 0)), CAST(1000000 AS Decimal(18, 0)), 2222, 19, 1)
INSERT [dbo].[SanPham] ([ID], [TenSanPham], [GiaNhap], [GiaBan], [SoLuong], [LoaiSanPham], [Status]) VALUES (44, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([ID])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([ID])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([LoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
/****** Object:  StoredProcedure [dbo].[sp.InHoaDoanByMaHD]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp.InHoaDoanByMaHD]
@mahd varchar(5)
as
Select a.MaHoaDon,a.NgayLap,d.TenNhanVien,c.TenKhachHang, e.TenSanPham,b.SoLuong,e.GiaBan,b.SoLuong*e.GiaBan as ThanhTien
from HoaDon a, ChiTietHoaDon b,KhachHang c,NhanVien d,SanPham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and a.MaHoaDon=@mahd
GO
/****** Object:  StoredProcedure [dbo].[sp.InPhieuNhapByMaHD]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp.InPhieuNhapByMaHD]
@mapn varchar(5)
as

Select a.MaPhieuNhap,a.NgayLap,d.TenNhanVien,c.TenKhachHang, e.TenSanPham,b.SoLuong,e.GiaNhap,b.SoLuong*e.GiaNhap as ThanhTien
from PhieuNhap a, ChiTietPhieuNhap b,KhachHang c,NhanVien d,SanPham e
where a.MaPhieuNhap=b.MaPhieuNhap and a.MaNhanVien=d.ID and a.MaNhaCungCap=c.ID
and b.MaSanPham=e.ID and a.MaPhieuNhap=@mapn
GO
/****** Object:  StoredProcedure [dbo].[sp_BaoCaoHangTon]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BaoCaoHangTon]
AS
SELECT 
    s.TenSanPham, 
    s.GiaNhap, 
    s.GiaBan, 
    ISNULL(q.SoLuongNhap, 0) - ISNULL(t.SoLuongBan, 0) AS HANGTON
FROM 
    sanpham s
    LEFT JOIN (
        SELECT 
            b.MaSanPham, 
            SUM(CAST(b.SoLuong AS INT)) AS SoLuongNhap
        FROM 
            ChiTietPhieuNhap b
            INNER JOIN PhieuNhap a ON a.MaPhieuNhap = b.MaPhieuNhap
        GROUP BY 
            b.MaSanPham
    ) q ON s.ID = q.MaSanPham
    LEFT JOIN (
        SELECT 
            c.MaSanPham, 
            SUM(CAST(c.SoLuong AS INT)) AS SoLuongBan
        FROM 
            ChiTietHoaDon c
            INNER JOIN HoaDon d ON d.MaHoaDon = c.MaHoaDon
        GROUP BY 
            c.MaSanPham
    ) t ON s.ID = t.MaSanPham

GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietHoaDonByMaHD]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ChiTietHoaDonByMaHD] 
@mahd varchar(5)
as
select a.MaHoaDon, b.TenSanPham,a.SoLuong, b.GiaBan
from ChiTietHoaDon a, SanPham b
where a.MaSanPham=b.ID and a.MaHoaDon=@mahd

GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietHoaDonInsert]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ChiTietHoaDonInsert]
@mahd varchar(5),
@masp int,
@soluong int
as
insert ChiTietHoaDon values (@mahd,@masp,@soluong)

GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietPhieuNhapByMaHD]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ChiTietPhieuNhapByMaHD] 
@mapn varchar(5)
as
select a.MaPhieuNhap, b.TenSanPham,a.SoLuong, b.GiaNhap
from ChiTietPhieuNhap a, SanPham b
where a.MaSanPham=b.ID and a.MaPhieuNhap=@mapn

GO
/****** Object:  StoredProcedure [dbo].[sp_ChiTietPhieuNhapInsert]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ChiTietPhieuNhapInsert]
@mapn varchar(5),
@masp int,
@soluong int
as
insert ChiTietPhieuNhap values (@mapn,@masp,@soluong)

GO
/****** Object:  StoredProcedure [dbo].[sp_DangNhapChangePassword]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DangNhapChangePassword]
@tendn varchar(100),
@mkcu varchar(100),
@mkmoi varchar(100),
@xnmkmoi varchar(100)
as
update DangNhap set MatKhau=@mkmoi where TenDangNhap=@tendn and MatKhau=@mkcu  and @xnmkmoi=@mkmoi
if @@ROWCOUNT >0
select errcode=1, errmsg=N'Đổi mật khẩu thành công'
else
select errcode=0, errmsg=N'Tên đăng nhập hoặc mật khẩu trước đó bị sai hoặc mật khẩu mới không trùng khớp với nhau'
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhThuDay]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DoanhThuDay]
AS
select a.MaHoaDon, a. NgayLap, d.TenNhanVien, c.TenKhachHang, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from HoaDon a, ChiTietHoaDon b, khachhang c, nhanvien d, sanpham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and  a.NgayLap = CAST(GETDATE() AS DATE);
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhThuDayandThang]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_DoanhThuDayandThang]
    @day INT
AS
if
@day=0
select a.MaHoaDon, a. NgayLap, d.TenNhanVien, c.TenKhachHang, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from HoaDon a, Chitiethoadon b, khachhang c, nhanvien d, sanpham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and  a.NgayLap = CAST(GETDATE() AS DATE);
else
BEGIN
select a.MaHoaDon, a. NgayLap, d.TenNhanVien, c.TenKhachHang, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from HoaDon a, Chitiethoadon b, khachhang c, nhanvien d, sanpham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and a.NgayLap >= CAST(DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AS DATETIME)
AND a.NgayLap < CAST(DATEADD(DAY, -1, DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))) AS DATETIME);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhThuThang]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DoanhThuThang]
AS
select a.MaHoaDon, a. NgayLap, d.TenNhanVien, c.TenKhachHang, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from HoaDon a, ChiTietHoaDon b, khachhang c, nhanvien d, sanpham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and a.NgayLap >= CAST(DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AS DATETIME)
AND a.NgayLap < CAST(DATEADD(DAY, -1, DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))) AS DATETIME);
GO
/****** Object:  StoredProcedure [dbo].[sp_HoaDonInsert]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_HoaDonInsert]
@mahd varchar(5),
@ngaylap date,
@manv int,
@makh int
as
insert HoaDon values (@mahd,@ngaylap,@manv,@makh)

GO
/****** Object:  StoredProcedure [dbo].[sp_HoaDonSelectAll]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_HoaDonSelectAll]
as
select a.MaHoaDon, a.NgayLap,c.TenNhanVien,b.TenKhachHang
from HoaDon a, KhachHang b, NhanVien c
where a.MaNhanVien=c.ID and a.MaKhachHang=b.ID


GO
/****** Object:  StoredProcedure [dbo].[sp_HoaDonSelectID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_HoaDonSelectID]
as
select top 1 MaHoaDon from HoaDon order by MaHoaDon desc

GO
/****** Object:  StoredProcedure [dbo].[sp_InHoaDonByDay]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InHoaDonByDay] 
@tungay date,
@denngay date
as
select a.MaHoaDon, a. NgayLap, d.TenNhanVien, c.TenKhachHang, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from HoaDon a, ChiTietHoaDon b, khachhang c, nhanvien d, sanpham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and a.NgayLap between @tungay and @denngay
GO
/****** Object:  StoredProcedure [dbo].[sp_InHoaDonByMaHD]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InHoaDonByMaHD]
@mahd varchar(5)
as
select a.MaHoaDon, a. NgayLap, d.TenNhanVien, c.TenKhachHang, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from HoaDon a, ChiTietHoaDon b, khachhang c, nhanvien d, sanpham e
where a.MaHoaDon=b.MaHoaDon and a.MaNhanVien=d.ID and a.MaKhachHang=c.ID
and b.MaSanPham=e.ID and a.MaHoaDon=@mahd
GO
/****** Object:  StoredProcedure [dbo].[sp_InHoaDonByNhanVien]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InHoaDonByNhanVien]
    @nhanvien INT
AS
if
@nhanvien=0
SELECT 
        a.MaHoaDon, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenKhachHang, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaBan, 
        b.SoLuong * e.GiaBan AS ThanhTien
    FROM 
        HoaDon a 
        JOIN ChiTietHoaDon b ON a.MaHoaDon = b.MaHoaDon -- Sử dụng JOIN ON để tránh kết quả lặp lại
        JOIN khachhang c ON a.MaKhachHang = c.ID 
        JOIN nhanvien d ON a.MaNhanVien = d.ID -- Thay vì sử dụng "." thì sử dụng "=" để tránh kết quả lặp lại
        JOIN sanpham e ON b.MaSanPham = e.ID 
    GROUP BY 
        a.MaHoaDon, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenKhachHang, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaBan
else
BEGIN
    SELECT 
        a.MaHoaDon, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenKhachHang, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaBan, 
        b.SoLuong * e.GiaBan AS ThanhTien
    FROM 
        HoaDon a 
        JOIN ChiTietHoaDon b ON a.MaHoaDon = b.MaHoaDon -- Sử dụng JOIN ON để tránh kết quả lặp lại
        JOIN khachhang c ON a.MaKhachHang = c.ID 
        JOIN nhanvien d ON a.MaNhanVien = d.ID -- Thay vì sử dụng "." thì sử dụng "=" để tránh kết quả lặp lại
        JOIN sanpham e ON b.MaSanPham = e.ID 
    WHERE 
        a.MaNhanVien = @nhanvien 
    GROUP BY 
        a.MaHoaDon, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenKhachHang, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaBan
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InPhieuNhapByDay]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InPhieuNhapByDay] 
@tungay date,
@denngay date
as
select a.MaPhieuNhap, a. NgayLap, d.TenNhanVien, c.TenNhaCungCap, e.TenSanPham, b.SoLuong, e.GiaBan, b.SoLuong * e.GiaBan as ThanhTien
from PhieuNhap a, ChiTietPhieuNhap b, NhaCungCap c, nhanvien d, sanpham e
where a.MaPhieuNhap=b.MaPhieuNhap and a.MaNhanVien=d.ID and a.MaNhaCungCap=c.ID
and b.MaSanPham=e.ID and a.NgayLap between @tungay and @denngay
GO
/****** Object:  StoredProcedure [dbo].[sp_InPhieuNhapByNhanVien]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InPhieuNhapByNhanVien]
    @nhanvien INT
AS
if
@nhanvien=0
SELECT 
        a.MaPhieuNhap, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenNhaCungCap, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaNhap, 
        b.SoLuong * e.GiaNhap AS ThanhTien
    FROM 
        PhieuNhap a 
        JOIN ChiTietPhieuNhap b ON a.MaPhieuNhap = b.MaPhieuNhap -- Sử dụng JOIN ON để tránh kết quả lặp lại
        JOIN NhaCungCap c ON a.MaNhaCungCap = c.ID 
        JOIN nhanvien d ON a.MaNhanVien = d.ID -- Thay vì sử dụng "." thì sử dụng "=" để tránh kết quả lặp lại
        JOIN sanpham e ON b.MaSanPham = e.ID 
    GROUP BY 
        a.MaPhieuNhap, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenNhaCungCap, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaNhap
else
BEGIN
   SELECT 
        a.MaPhieuNhap, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenNhaCungCap, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaNhap, 
        b.SoLuong * e.GiaNhap AS ThanhTien
    FROM 
        PhieuNhap a 
        JOIN ChiTietPhieuNhap b ON a.MaPhieuNhap = b.MaPhieuNhap -- Sử dụng JOIN ON để tránh kết quả lặp lại
        JOIN NhaCungCap c ON a.MaNhaCungCap = c.ID 
        JOIN nhanvien d ON a.MaNhanVien = d.ID -- Thay vì sử dụng "." thì sử dụng "=" để tránh kết quả lặp lại
        JOIN sanpham e ON b.MaSanPham = e.ID 
		 WHERE 
        a.MaNhanVien = @nhanvien 
    GROUP BY 
        a.MaPhieuNhap, 
        a.NgayLap, 
        d.TenNhanVien, 
        c.TenNhaCungCap, 
        e.TenSanPham, 
        b.SoLuong, 
        e.GiaNhap
END
GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_KhachHangByID]
@id int
as

select * from KhachHang  where id=@id

GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangDeleteByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_KhachHangDeleteByID]
@id int
as 
delete KhachHang where id=@id
if @@ROWCOUNT >0
select errcode=1, errmsg=N'Xoá dữ liệu thành công'
else
select errcode=0, errmsg=N'Lỗi trong quá trình xoá'


GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangSelect]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_KhachHangSelect]
as

select * from KhachHang 


GO
/****** Object:  StoredProcedure [dbo].[sp_LoaiSanPham]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LoaiSanPham] 
@id int,
@ten nvarchar(50),
@status bit
as
if exists (select * from LoaiSanPham where id=@id)
begin
	update LoaiSanPham set TenLoai=@ten,Status=@status where id=@id
	if @@ROWCOUNT>0
select errcode=1, errmsg=N'Cập nhật dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình cập nhật'
end
else
begin
insert LoaiSanPham values (@ten,@status)

if @@ROWCOUNT>0
select errcode=1, errmsg=N'Thêm dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình thêm'
end

GO
/****** Object:  StoredProcedure [dbo].[sp_LoaiSanPhamDeleteByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LoaiSanPhamDeleteByID]
@id int
as 
delete LoaiSanPham where id=@id
if @@ROWCOUNT >0
select errcode=1, errmsg=N'Xoá dữ liệu thành công'
else
select errcode=0, errmsg=N'Lỗi trong quá trình xoá'


GO
/****** Object:  StoredProcedure [dbo].[sp_LoaiSanPhamInsert]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LoaiSanPhamInsert]
@id int,
@ten nvarchar(50),
@status bit
as
insert LoaiSanPham values (@ten,@status)

if @@ROWCOUNT>0
select errcode=1, errmsg=N'Thêm dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình thêm'




GO
/****** Object:  StoredProcedure [dbo].[sp_LoaiSanPhamSelect]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LoaiSanPhamSelect]
as
select * from LoaiSanPham where Status=1;
GO
/****** Object:  StoredProcedure [dbo].[sp_LoaiSanPhamUpdateByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LoaiSanPhamUpdateByID] 
@id int,
@ten nvarchar(50),
@status bit
as
insert LoaiSanPham values (@ten,@status)

if @@ROWCOUNT>0
select errcode=1, errmsg=N'Thêm dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình thêm'



GO
/****** Object:  StoredProcedure [dbo].[sp_LoaiSPSelect]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LoaiSPSelect]
as
select 0 as ID,N'Xem tất cả' as TenLoai 
from LoaiSanPham
union
select ID,TenLoai from LoaiSanPham where Status=1
GO
/****** Object:  StoredProcedure [dbo].[sp_NextID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NextID]
@tenbang varchar(50)
as
SELECT IDENT_CURRENT(@tenbang)+1 as ID


GO
/****** Object:  StoredProcedure [dbo].[sp_NhaCungCap]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NhaCungCap] 
@id int,
@tennhacc nvarchar(50),
@diachi nvarchar(50),
@phone nvarchar(50),
@status bit
as
if exists (select * from NhaCungCap where id=@id)
begin
	update NhaCungCap set TenNhaCungCap=@tennhacc, DiaChi=@diachi, DienThoai=@phone, Status=@status where id=@id
	if @@ROWCOUNT>0
select errcode=1, errmsg=N'Cập nhật dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình cập nhật'
end
else
begin
insert NhaCungCap values (@tennhacc,@diachi,@phone,@status)

if @@ROWCOUNT>0
select errcode=1, errmsg=N'Thêm dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình thêm'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_NhaCungCapByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_NhaCungCapByID]
@id int
as

select * from NhaCungCap  where id=@id

GO
/****** Object:  StoredProcedure [dbo].[sp_NhaCungCapDeleteByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_NhaCungCapDeleteByID]
@id int
as
delete NhaCungCap where id=@id
if @@ROWCOUNT>0
select errcode=1, errmsg=N'Xoá dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình xoá'
GO
/****** Object:  StoredProcedure [dbo].[sp_NhaCungCapSelect]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NhaCungCapSelect]
as

select * from NhaCungCap where Status=1;

GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienDangNhap]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NhanVienDangNhap]
@tendn varchar(50),
@matkhau varchar(50)
as
if exists (select * from DangNhap where TenDangNhap=@tendn and MatKhau=@matkhau)
select errcode=1, errmsg=N'Đăng nhập thành công'
else
select errcode=0, errmsg=N'Sai tên đăng nhập hoặc mật khẩu vui lòng nhập lại'
GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienDeleteByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_NhanVienDeleteByID]
@id int
as 
delete NhanVien where id=@id
if @@ROWCOUNT >0
select errcode=1, errmsg=N'Xoá dữ liệu thành công'
else
select errcode=0, errmsg=N'Lỗi trong quá trình xoá'


GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienLogin]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NhanVienLogin] 
@tendn varchar(50),
@matkhau varchar(50)
as
if exists (select * from DangNhap where TenDangNhap=@tendn and MatKhau=@matkhau)
select errcode=1, errmsg=N'Đăng nhập thành công', TenDangNhap,MatKhau  from DangNhap where tendangnhap=@tendn
else
select errcode= 0, errmsg=N'Sai tên đăng nhập hoặc mật khẩu'
GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienSelect]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[sp_NhanVienSelect]
as

select * from NhanVien where Status=1

GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienselectall]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NhanVienselectall]
as
select 0 as ID,N'Xem tất cả' as TenNhanVien
from NhanVien
union
select ID,TenNhanVien from NhanVien where Status=1
GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienSelectByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_NhanVienSelectByID] 
@id int,
@ten nvarchar(50)
as
select * from Nhanvien where id= @id and TenNhanVien=@ten




GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuNhapInsert]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_PhieuNhapInsert]
@mapn varchar(5),
@ngaylap date,
@manv int,
@mancc int
as
insert PhieuNhap values (@mapn,@ngaylap,@manv,@mancc)

GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuNhapSelectAll]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_PhieuNhapSelectAll]
as
select a.MaPhieuNhap, a.NgayLap,c.TenNhanVien,b.TenNhaCungCap
from PhieuNhap a, NhaCungCap b, NhanVien c
where a.MaNhanVien=c.ID and a.MaNhaCungCap=b.ID


GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuNhapSelectID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_PhieuNhapSelectID]
as
select top 1 MaPhieuNhap from PhieuNhap order by MaPhieuNhap desc

GO
/****** Object:  StoredProcedure [dbo].[sp_SanPham]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SanPham] 
@id int,
@tensp nvarchar(50),
@gianhap decimal(18,0),
@giaban decimal(18,0),
@soluong int,
@loaisp int,
@status bit
as
if exists (select * from SanPham where id=@id)
begin
	update SanPham set TenSanPham=@tensp, GiaNhap=@gianhap, GiaBan=@giaban,SoLuong=@soluong, LoaiSanPham=@loaisp, Status=@status where id=@id
	if @@ROWCOUNT>0
select errcode=1, errmsg=N'Cập nhật dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình cập nhật'
end
else
begin
insert SanPham values (@tensp,@gianhap,@giaban,@soluong,@loaisp,@status)

if @@ROWCOUNT>0
select errcode=1, errmsg=N'Thêm dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình thêm'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SanPhamAdd]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SanPhamAdd] 
@tensp nvarchar(50),
@gianhap decimal(18,0),
@giaban decimal(18,0),
@soluong int,
@loaisp int,
@status bit
as
insert SanPham values (@tensp,@gianhap,@giaban,@soluong,@loaisp,@status)

if @@ROWCOUNT>0
select errcode=1, errmsg=N'Thêm dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình thêm'
GO
/****** Object:  StoredProcedure [dbo].[sp_SanPhamByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_SanPhamByID] 
@id int
as

select * from SanPham  where id=@id and status=1

GO
/****** Object:  StoredProcedure [dbo].[sp_SanPhamDeleteByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SanPhamDeleteByID]
@id int
as
delete SanPham where id=@id
if @@ROWCOUNT>0
select errcode=1, errmsg=N'Xoá dữ liệu thành công'
else
select errcode=0, errmsg='Lỗi trong quá trình xoá'
GO
/****** Object:  StoredProcedure [dbo].[sp_SanPhamSelect]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SanPhamSelect]
as

select * from SanPham where Status=1

GO
/****** Object:  StoredProcedure [dbo].[sp_SanPhamSelectByID]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_SanPhamSelectByID]
@id int
as
select * from SanPham a
inner join LoaiSanPham b
on a.LoaiSanPham=b.ID 
where a.id=@id
GO
/****** Object:  StoredProcedure [dbo].[sp_SanPhamSelectByLoaiSP]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_SanPhamSelectByLoaiSP]
@loai int
as
if @loai=0
select * from SanPham a, LoaiSanPham b
where a.LoaiSanPham=b.ID
else
select * from SanPham a, LoaiSanPham b
where a.LoaiSanPham=b.ID and b.ID=@loai
GO
/****** Object:  StoredProcedure [dbo].[SP_SuaKhachHang]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_SuaKhachHang]
@ID int,
@HoTen nvarchar(50),
@DiaChi nvarchar(100),
@Phone nvarchar(15),
@NgaySinh date
as
begin
    update KhachHang set
    TenKhachHang = @HoTen,
    NgaySinh = @NgaySinh,
    DienThoai = @Phone,
	DiaChi=@DiaChi

    where ID = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_SuaNhanVien]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_SuaNhanVien]
@ID int,
@HoTen nvarchar(50),
@NgaySinh date,
@Phone nvarchar(20),
@GioiTinh nchar(10),
@status bit
as
begin
    update NhanVien set
    TenNhanVien = @HoTen,
    NgaySinh = @NgaySinh,
    DienThoai = @Phone,
	GioiTinh = @GioiTinh,
	Status=@status

    where ID = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[sp_taomkmoi]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_taomkmoi]
@tendn varchar(100),
@mkmoi varchar(100)
as
update DangNhap set MatKhau=@mkmoi where Email=@tendn
GO
/****** Object:  StoredProcedure [dbo].[SP_taotk]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_taotk] 
@email varchar(50),
@tendn varchar(50),
@mk varchar(50),
@mk2 varchar(50)
as
IF EXISTS(SELECT * FROM DangNhap WHERE TenDangNhap = @tendn)
BEGIN
    SELECT errcode=0, errmsg=N'Tên đăng nhập đã tồn tại'
END
ELSE
BEGIN
INSERT INTO DangNhap (TenDangNhap, MatKhau,Email) 
SELECT @tendn, @mk,@email
WHERE @mk = @mk2
if @@ROWCOUNT>0
select errcode=1, errmsg=N'Đăng kí thành công'
else
select errcode=0, errmsg=N'Lỗi vui lòng thử lại'
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ThemKhachHang]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_ThemKhachHang]
@HoTen nvarchar(50),
@DiaChi nvarchar(100),
@Phone nvarchar(15),
@NgaySinh date
as
begin
    insert into KhachHang values (@HoTen, @DiaChi, @Phone, @NgaySinh)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ThemNhanVien]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ThemNhanVien]
@HoTen nvarchar(50),
@NgaySinh date,
@Phone nvarchar(20),
@GioiTinh nchar(10),
@status bit
as
begin
    insert into NhanVien values (@HoTen, @NgaySinh, @Phone, @GioiTinh,@status)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_TraCuuDoanhThu]    Script Date: 5/19/2023 2:47:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TraCuuDoanhThu]
as
select 0 as ToDay,N'Hôm Nay' as ToDay
select 1 as ToDay,N'Tháng Này' as Today
GO
