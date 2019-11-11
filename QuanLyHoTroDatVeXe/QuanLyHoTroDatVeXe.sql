CREATE DATABASE QuanLyHoTroDatVe
GO
USE QuanLyHoTroDatVe
GO

SELECT * FROM dbo.ChuyenDi

---Table
--Xe
CREATE TABLE Xe
(
	bienSo VARCHAR(10) PRIMARY KEY,
	taiXe NVARCHAR(50) NOT NULL,
	sdtTaiXe INT,
	tenXe NVARCHAR(50) NOT NULL
)
GO
--Chuyến đi
CREATE TABLE ChuyenDi
(
	maCD INT IDENTITY(102,1) PRIMARY KEY,
	gioDi VARCHAR(5),
	ngayDi DATETIME NOT NULL,
	diemDi NVARCHAR(20) ,
	diemDen NVARCHAR(20) ,
	giaVe FLOAT NOT NULL,
	bienSo VARCHAR(10),
	FOREIGN KEY (bienSo) REFERENCES dbo.Xe (bienSo)
)
GO
--Khách hàng
CREATE TABLE KhachHang
(
	soDienThoai INT PRIMARY KEY,
	CMND INT NOT NULL,
	hoTen NVARCHAR(50) NOT NULL,
	gioiTinh NVARCHAR(10),
	diaChi NVARCHAR(100),
	email VARCHAR(50),
)
GO
--Tài khoản
CREATE TABLE TaiKhoan
(
	tenDangNhap VARCHAR(10) PRIMARY KEY,
	matKhau VARCHAR(20) NOT NULL,
	loaiTaiKhoan INT NOT NULL,	--tài khoản KH: 0, nhân viên: 1
	soDienThoai INT
)
GO
--Khách hàng đặt vé xe
CREATE TABLE VeXe
(
	soDienThoai INT,
	maCD INT,
	maGhe VARCHAR(3),
	thoiGianDat DATETIME NOT NULL,
	PRIMARY KEY( soDienThoai, maCD, maGhe),
	FOREIGN KEY (soDienThoai) REFERENCES dbo.KhachHang (soDienThoai),
	FOREIGN KEY (maCD) REFERENCES dbo.ChuyenDi (maCD)
)
GO
---STORE  PROC
--Thêm xe
CREATE PROC themXe 
(@bienSo VARCHAR(10),@taiXe NVARCHAR(50), @sdtTaiXe int, @tenXe NVARCHAR(50))
AS
BEGIN
	INSERT dbo.Xe ( bienSo, taiXe, sdtTaiXe, tenXe)
	VALUES  ( @bienSo, @taiXe, @sdtTaiXe, @tenXe)
END
GO
--Thêm chuyến đi
CREATE PROC themChuyenDi 
(@gioDi VARCHAR(5), @ngayDi DATETIME, @diemDi NVARCHAR(20), @diemDen NVARCHAR(20), @giaVe FLOAT, @bienSo VARCHAR(10))
AS
BEGIN
	INSERT dbo.ChuyenDi(gioDi, ngayDi, diemDi, diemDen, giaVe, bienSo)
	VALUES  (@gioDi, @ngayDi, @diemDi, @diemDen, @giaVe, @bienSo)
END
GO
--Thêm khách hàng
CREATE PROC themKH (@soDienThoai INT, @CMND int, @hoTen NVARCHAR(50), @gioiTinh NVARCHAR(10), @diaChi NVARCHAR(100), @email VARCHAR(50))
AS
BEGIN
	INSERT dbo.KhachHang(soDienThoai, CMND, hoTen, gioiTinh, diaChi, email)
	VALUES (@soDienThoai, @CMND, @hoTen, @gioiTinh, @diaChi, @email)
END
GO
--Thêm vé xe
CREATE PROC themVeXe (@soDienThoai INT, @maCD INT, @maGhe VARCHAR(3), @thoiGianDat DATETIME)
AS
BEGIN
	INSERT dbo.VeXe(soDienThoai, maCD, maGhe, thoiGianDat )
	VALUES  (@soDienThoai, @maCD, @maGhe, @thoiGianDat)
END
GO
---Dữ liệu
--Xe
themXe '59F-61792', N'Lê Quốc Hoàng', 328893485, N'KIA'
GO
themXe '39F-81792', N'Trần Nam Thương', 123457890, N'Toyota'
GO
themXe '62M-53012', N'Nguyễn Quốc Vương', 102458079, N'Limouse'
GO
themXe '48K-10054', N'Vũ Hoàng Nam', 112589774, N'Limouse Phương Trang'
GO
themXe '66T-10054', N'Cao Bá Đạt', 857493050, N'KIA'
GO
themXe '62L-10054', N'Trần Văn Anh', 205793240, N'Limouse'
GO
themXe '74L-98754', N'nguyễn Kim Thiện', 971528030, N'Toyota'
GO
--Chuyến đi
themChuyenDi '5h00', '11-19-2019' , N'Đồng Nai', 'LongAn', 180000, '39F-81792' 
GO
themChuyenDi '6h00', '11-19-2019' , N'tp.HCM', 'LongAn', 125000, '62M-53012' 
GO
themChuyenDi '7h00', '11-20-2019' , N'Long An', N'Đồng Tháp', 125000, '48K-10054' 
GO
themChuyenDi '8h00', '11-20-2019' , N'Đồng Tháp', N'Bảo Lộc', 250000, '66T-10054' 
GO
themChuyenDi '14h00', '11-18-2019' , N'Long An', N'Bảo Lộc', 100000, '62L-10054' 
GO
themChuyenDi '15h00', '11-18-2019' , N'Bảo Lộc', N'Đồng Tháp', 200000, '74L-98754' 
GO
--Khách hàng
themKH 918236031, 251123456, N'Phan Anh Khoa', 'Nam', 'tp.HCM', 'khoa.pa@gmail.com'
GO
themKH 123456789, 251123456, N'Hoàng Huy Nguyễn', 'Nam', 'tp.HCM', 'huy.nh@gmail.com'
GO
themKH 912839740, 251123456, N'Trịnh Hoàng Yến', N'Nũ', 'tp.HCM', 'yen.th@gmail.com'
GO
--Tài khoản nhân viên
INSERT INTO TaiKhoan VALUES( 'tu', '1', 1, 912839742),
							( 'yen', '1', 0, 912839740)
GO

--Vé xe
dbo.themVeXe 918236031, 102, 'A01', '11-17-2019'
GO
dbo.themVeXe 912839740, 102, 'A02', '11-17-2019'
GO
dbo.themVeXe 123456789, 103, 'A07', '11-17-2019'
GO
dbo.themVeXe 918236031, 103, 'A12', '11-17-2019'
GO
