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
	tenTinh VARCHAR(20) PRIMARY KEY
)
GO 
CREATE TABLE DiemDen
(
	tenTinh VARCHAR(20) PRIMARY KEY
)
GO 
CREATE TABLE GioDi
(
	gioDi VARCHAR(5) PRIMARY KEY
)
GO
CREATE TABLE ChuyenDi
(
	maCD INT IDENTITY(101,1),
	gioDi VARCHAR(5),
	ngayDi DATETIME NOT NULL,
	diemDi VARCHAR(20) ,
	diemDen VARCHAR(20) ,
	giaVe FLOAT NOT NULL,
	bienSo VARCHAR(10),

	PRIMARY KEY (gioDi, bienSo),
	FOREIGN KEY (bienSo) REFERENCES dbo.Xe (bienSo),
	FOREIGN KEY (diemDi) REFERENCES dbo.DiemDi (tenTinh),
	FOREIGN KEY (diemDen) REFERENCES dbo.DiemDen (tenTinh),
	FOREIGN KEY (gioDi) REFERENCES dbo.GioDi (gioDi)
)
GO
CREATE TABLE TaiKhoan
(
	tenDangNhap VARCHAR(10) PRIMARY KEY,
	matKhau VARCHAR(20) NOT NULL,
	loaiTaiKhoan INT NOT NULL	--tài khoản KH: 0, nhân viên: 1
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
CREATE TABLE Ghe
(
	ghe VARCHAR(3) PRIMARY KEY
)
GO        
CREATE TABLE Ve
(
	maVe INT IDENTITY(201,2),
	soDienThoai INT,
	maCD INT,
	ghe VARCHAR(3),
	thoiGianDat DATETIME NOT NULL,

	PRIMARY KEY (soDienThoai, maCD, ghe), 
	FOREIGN KEY (soDienThoai) REFERENCES dbo.KhachHang (soDienThoai),
	FOREIGN KEY (maCD) REFERENCES dbo.ChuyenDi (maCD),
	FOREIGN KEY (ghe) REFERENCES dbo.Ghe (ghe)
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
(@gioDi VARCHAR(5), @ngayDi DATETIME, @diemDi VARCHAR(20), @diemDen VARCHAR(20), @giaVe FLOAT, @bienSo VARCHAR(10))
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
---Dữ liệu
--Giờ đi
INSERT INTO dbo.GioDi( gioDi ) VALUES  ('5h00'), ('6h00'), ('7h00'), ('8h00'), ('9h00'), ('10h00' )
GO
--Ghế
INSERT INTO dbo.Ghe( ghe ) 
VALUES  ('A01'),('A02'),('A03'),('A04'),('A05'),('A06'),('A07'),('A08'),('A09'),('A10'),('A11'),('A12'),('A13'),('A14'),('A15')
GO
--Điểm đi
INSERT INTO dbo.DiemDi( tenTinh )
VALUES  ( N'DongNai'),(N'HoChiMinh')
GO
--Điểm đến
INSERT INTO dbo.DiemDen(  tenTinh )
VALUES  (N'BaoLoc'),(N'DongThap'),(N'LongAn')
GO
--Xe
themXe '59F-61792', N'Lê Quốc Hoàng', 328893485, N'KIA', 0
GO
themXe '39F-81792', N'Trần Nam Thương', 123457890, N'Toyota', 1
GO
themXe '62M-53012', N'Nguyễn Quốc Vương', 102458079, N'Limouse', 1
GO
themXe '48K-10054', N'Vũ Hoàng Nam', 112589774, N'Limouse Phương Trang', 1
GO
themXe '66T-10054', N'Cao Bá Đạt', 857493050, N'KIA', 1
GO
themXe '62L-10054', N'Trần Văn Anh', 205793240, N'Limouse', 1
GO
themXe '74L-98754', N'nguyễn Kim Thiện', 971528030, N'Toyota', 1
GO
--Chuyến đi
themChuyenDi '5h00', '12-06-2019' , 'DongNai', 'LongAn', 125000, '39F-81792' 
GO
themChuyenDi '6h00', '11-5-2019' , 'HoChiMinh', 'LongAn', 125000, '62M-53012' 
GO
themChuyenDi '7h00', '11-3-2019' , 'HoChiMinh', 'DongThap', 125000, '48K-10054' 
GO
themChuyenDi '8h00', '11-7-2013' , 'HoChiMinh', 'BaoLoc', 125000, '66T-10054' 
GO
themChuyenDi '9h00', '11-7-2013' , 'DongNai', 'BaoLoc', 125000, '62L-10054' 
GO
themChuyenDi '10h00', '11-7-2013' , 'DongNai', 'DongThap', 125000, '74L-98754' 
GO
--Tài khoản
INSERT INTO TaiKhoan (tenDangNhap, matKhau, loaiTaiKhoan) VALUES ( '0', '0', 0),( '1', '1', 1)
GO
--Khách hàng
themKH 918236031, 251123456, N'Hoàng Yến', N'Nữ', 'tp.HCM', 'yen.th@gmail.com', '1'
GO
themKH 912839740, 251123456, N'Thanh Tú', 'Nam', 'tp.HCM', 'tu.nt@gmail.com', '0'
GO






