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
	tenXe NVARCHAR(50) NOT NULL,
	trangThai INT
)
GO
CREATE TABLE DiemDi
(
	tenTinh NVARCHAR(20) PRIMARY KEY
)
GO 
CREATE TABLE DiemDen
(
	tenTinh NVARCHAR(20) PRIMARY KEY
)
GO 
CREATE TABLE ChuyenDi
(
	maCD INT IDENTITY(10078,1) PRIMARY KEY,
	gioDi VARCHAR(5) NOT NULL,
	ngayDi DATETIME NOT NULL,
	diemDi NVARCHAR(20) ,
	diemDen NVARCHAR(20) ,
	giaVe FLOAT NOT NULL,
	bienSo VARCHAR(10) NOT NULL,
	FOREIGN KEY (bienSo) REFERENCES dbo.Xe (bienSo),
	FOREIGN KEY (diemDi) REFERENCES dbo.DiemDi (tenTinh),
	FOREIGN KEY (diemDen) REFERENCES dbo.DiemDen (tenTinh)
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
	gioiTinh NVARCHAR(10),
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
	CMND INT NOT NULL,
	hoTen NVARCHAR(50) NOT NULL,
	gioiTinh NVARCHAR(10),
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
	PRIMARY KEY (maVe, soDienThoai, maCD), 
	FOREIGN KEY (soDienThoai) REFERENCES dbo.KhachHang (soDienThoai),
	FOREIGN KEY (maCD) REFERENCES dbo.ChuyenDi (maCD),
)
GO

--STORE  PROC
CREATE PROC themXe 
(@bienSo VARCHAR(10),@taiXe NVARCHAR(50), @sdtTaiXe int, @tenXe NVARCHAR(50), @trangThai INT)
AS
BEGIN
	INSERT dbo.Xe ( bienSo, taiXe, sdtTaiXe, tenXe , trangThai)
	VALUES  ( @bienSo, @taiXe, @sdtTaiXe, @tenXe, @trangThai)
END
GO
CREATE PROC themChuyenDi 
(
	@gioDi VARCHAR(5), 
	@ngayDi DATETIME, 
	@diemDi NVARCHAR(20), 
	@diemDen NVARCHAR(20), 
	@giaVe FLOAT, 
	@bienSo VARCHAR(10)
)
AS
BEGIN
	INSERT dbo.ChuyenDi(gioDi, ngayDi, diemDi, diemDen, giaVe, bienSo)
	VALUES  (@gioDi, @ngayDi, @diemDi, @diemDen, @giaVe, @bienSo)
END
GO
CREATE PROC themKH (@soDienThoai INT, @CMND int, @hoTen NVARCHAR(50), @gioiTinh NVARCHAR(10), @diaChi NVARCHAR(100), @email VARCHAR(50), @tenDangNhap VARCHAR(10) )
AS
BEGIN
	INSERT dbo.KhachHang(soDienThoai, CMND, hoTen, gioiTinh, diaChi, email, tenDangNhap)
	VALUES (@soDienThoai, @CMND, @hoTen, @gioiTinh, @diaChi, @email, @tenDangNhap)
END
GO
--Điểm đi
INSERT INTO dbo.DiemDi( tenTinh )
VALUES  ( N'DongNai')
GO
INSERT INTO dbo.DiemDi( tenTinh )
VALUES  (N'HoChiMinh')
GO
--điểm đến
INSERT INTO dbo.DiemDen(  tenTinh )
VALUES  (N'BaoLoc')
GO
INSERT INTO dbo.DiemDen( tenTinh )
VALUES  (N'DongThap')
GO
INSERT INTO dbo.DiemDen( tenTinh )
VALUES  (N'LongAn')
GO
--Xe
themXe '59F-61792', N'Lê Quốc Hoàng', 328893485, N'KIA', 0
GO
themXe '39F-81792', N'Trần Nam Thương', 184789253, N'Toyota', 1
GO
themXe '62K-53012', N'Nguyễn Quốc Vương', 184789253, N'Limouse', 1
GO
themXe '48K-10054', N'Lê Văn Hùng', 184789253, N'Toyota', 0
GO
--chuyến đi
themChuyenDi '5h30', '12-11-2013' , 'DongNai', 'LongAn', 125000, '62K-53012' 
GO
SELECT maCD, gioDi, ngayDi, di.tenTinh, den.tenTinh, bienSo, giaVe 
FROM dbo.ChuyenDi AS c, dbo.DiemDi AS di, dbo.DiemDen AS den
WHERE c.diemDi = di.tenTinh AND c.diemDen = den.tenTinh
--tài khoản
INSERT INTO TaiKhoan (tenDangNhap, matKhau, loaiTaiKhoan) VALUES ( '0', '0', 0)
GO
INSERT INTO TaiKhoan (tenDangNhap, matKhau, loaiTaiKhoan) VALUES ( '1', '1', 1)
GO

themKH 918236031, 251123456, N'Hoàng Yến', N'Nữ', 'tp.HCM', 'yen.th@gmail.com', '1'
GO
themKH 912839740, 251123456, N'Thanh Tú', 'Nam', 'tp.HCM', 'tu.nt@gmail.com', '0'
GO

SELECT * FROM dbo.DiemDi



