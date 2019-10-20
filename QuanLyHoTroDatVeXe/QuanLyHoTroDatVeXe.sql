CREATE DATABASE QuanLyHoTroDatVe
GO
USE QuanLyHoTroDatVe
GO

--Các bảng
CREATE TABLE Xe
(
	bienSo VARCHAR(10) PRIMARY KEY,
	taiXe NVARCHAR(50) NOT NULL,
	sdtTaiXe INT,
	tenXe NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE ChuyenDi
(
	maCD INT IDENTITY(10078,1) PRIMARY KEY,
	gioDi INT NOT NULL,
	ngayDi DATETIME NOT NULL,
	diemDi NVARCHAR(50) NOT NULL,
	diemDen NVARCHAR(50) NOT NULL,
	giaVe FLOAT NOT NULL,
	bienSo VARCHAR(10) NOT NULL,
	FOREIGN KEY (bienSo) REFERENCES dbo.Xe (bienSo)
)
GO

CREATE TABLE TaiKhoan
(
	tenDangNhap VARCHAR(10) PRIMARY KEY,
	matKhau VARCHAR(20) NOT NULL,
	loaiTaiKhoan INT NOT NULL	--tài khoản KH: 0, nhân viên: 1
)
GO

CREATE TABLE NhanVien
(
	maNV INT IDENTITY(10078,1) PRIMARY KEY,
	hoTen NVARCHAR(50) NOT NULL,
	gioiTinh BIT,
	soDienThoai INT NOT NULL,
	luong FLOAT,
	diaChi NVARCHAR(100),
	email VARCHAR(50),
	tenDangNhap VARCHAR(10) NOT NULL,
	FOREIGN KEY (tenDangNhap) REFERENCES dbo.TaiKhoan (tenDangNhap)
)
GO

CREATE TABLE KhachHang
(
	soDienThoai INT PRIMARY KEY,
	CMND int NOT NULL,
	hoTen NVARCHAR(50) NOT NULL,
	gioiTinh BIT,
	diaChi NVARCHAR(100),
	email VARCHAR(50),
	tenDangNhap VARCHAR(10) NOT NULL,
	FOREIGN KEY (tenDangNhap) REFERENCES dbo.TaiKhoan (tenDangNhap)
)
GO          

CREATE TABLE Ve
(
	maVe INT IDENTITY(1098,2),
	soDienThoai INT,
	maCD INT,
	thoiGianDat DATETIME NOT NULL,
	maNV INT NOT NULL,
	PRIMARY KEY (maVe, soDienThoai, maCD), 
	FOREIGN KEY (soDienThoai) REFERENCES dbo.KhachHang (soDienThoai),
	FOREIGN KEY (maCD) REFERENCES dbo.ChuyenDi (maCD),
	FOREIGN KEY (maNV) REFERENCES dbo.NhanVien (maNV)
)
GO

