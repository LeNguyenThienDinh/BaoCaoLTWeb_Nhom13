select * from taikhoan
create database QL_CuaHangCayCanh
go
use QL_CuaHangCayCanh
go
-- Bảng danh sách loại sản phẩm
CREATE TABLE LoaiSanPham (
    MaLoai VARCHAR(20),
    TenLoai NVARCHAR(50),
	CONSTRAINT PK_LoaiSanPham PRIMARY KEY (MaLoai)
)

-- Bảng danh sách nhà sản xuất
CREATE TABLE NhaSanXuat (
    MaNhaSanXuat VARCHAR(20),
    TenNhaSanXuat NVARCHAR(50),
	SoDienThoai VARCHAR(20),
    DiaChi NVARCHAR(255),
    Email NVARCHAR(50),
	CONSTRAINT PK_MaNhaSanXuat PRIMARY KEY (MaNhaSanXuat)
)

-- Bảng danh sách sản phẩm
CREATE TABLE SanPham 
(
    MaSanPham VARCHAR(20),
    TenSanPham NVARCHAR(50),
    Gia float,
    MoTa NVARCHAR(255),
	Anh nvarchar(255),
	MaLoai VARCHAR(20),
	MaNhaSanXuat VARCHAR(20),
	SanPhamTon int,
	SanPhamDaBan int
	CONSTRAINT PK_SanPham  PRIMARY KEY (MaSanPham)
)


-- Bảng danh sách đơn hàng
CREATE TABLE DonHang 
(
    MaDonHang int IDENTITY(1,1),
    TenDN VARCHAR(20),
    NgayDat DATEtime,
	Email nvarchar(100),
	HoTen nvarchar(60),
	SoDienThoai varchar(11),
	ChiTietDiaChi NVARCHAR(255),
	TongGiaTri float,
	HinhThucThanhToan NVARCHAR(255),
	TrangThai NVARCHAR(20),
	CONSTRAINT PK_DonHang  PRIMARY KEY (MaDonHang)
)

-- Bảng chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    MaDonHang int IDENTITY(1,1),
    MaSanPham VARCHAR(20),
    SoLuong INT,
	ThanhTien float,
    CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (MaDonHang, MaSanPham)
)


CREATE TABLE TaiKhoan (
	
	VaiTro char(10),
    Email nvarchar(100) Unique,
	HoTen nvarchar(60),
	NgaySinh date,
	GioiTinh nchar(3),
	SoDienThoai varchar(11),
	TenDN varchar(20) Primary key,
	MatKhau varchar(100),
	AnhBiaUser nvarchar(255)
)

--Bảng Dịa chỉ
CREATE TABLE DiaChi
(
	MaDiaChi int IDENTITY(1,1) primary key,
	TenDN varchar(20),
	ChiTietDiaChi NVARCHAR(255),
	ChiTietDiaChi2 NVARCHAR(255),
	CONSTRAINT FK_DiaChi Foreign key (TenDN) references TaiKhoan(TenDN)
)

CREATE TABLE GioHang
(
	TenDN varchar(20),
	MaSanPham VARCHAR(20),
	TenSanPham NVARCHAR(50),
	Anh nvarchar(255),
	Gia float,
	SoLuong int,
	ThanhTien float,
	constraint PK_GioHang primary key(TenDN,MaSanPham),
	constraint FK_GioHang_TenDN foreign key (TenDN) references TaiKhoan(TenDN),
	constraint FK_GioHang_MaSanPham foreign key (MaSanPham) references SanPham(MaSanPham)
)

--
CREATE TABLE VanChuyen (
    MaVanChuyen VARCHAR(20),
	MaDonHang int,
	NgayVanChuyen DATEtime,
	ChiPhiVanChuyen	FLOAT
    CONSTRAINT PK_VanChuyen_DonHang PRIMARY KEY (MaVanChuyen)
)
-- Tạo khóa ngoại cho bảng SanPham
ALTER TABLE SanPham
ADD CONSTRAINT FK_SanPham_MaLoai FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
ALTER TABLE SanPham
ADD CONSTRAINT FK_SanPham_Nsx FOREIGN KEY (MaNhaSanXuat) REFERENCES NhaSanXuat(MaNhaSanXuat)


---- Tạo khóa ngoại cho bảng DonHang
ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_TenDN FOREIGN KEY (TenDN) REFERENCES TaiKhoan(TenDN)


-- Tạo khóa ngoại cho bảng ChiTietDonHang
ALTER TABLE ChiTietDonHang
ADD CONSTRAINT FK_ChiTietDonHang_MaDonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
ALTER TABLE ChiTietDonHang
ADD CONSTRAINT FK_ChiTietDonHang_MaSanPham FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)

---- Tạo khóa ngoại cho bảng DonHang
ALTER TABLE VanChuyen
ADD CONSTRAINT FK_VanChuyen_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)


set dateformat dmy
insert into TaiKhoan values	('Admin',N'admin@gmail.com',N'Nhóm 15','26/07/2003',N'Nam','0378857407','Admin','admin123','');
insert into TaiKhoan values	('User',N'khachhang1@gmail.com',N'Nhật Nga','06/01/2003',N'Nam','0902223337','nhatnga','123','');
insert into TaiKhoan values	('User',N'khachhang2@gmail.com',N'Thanh Ngân','03/07/2003',N'Nam','037654321','thanhngan','123','');
insert into TaiKhoan values	('User',N'khachhang3@gmail.com',N'Nhật Tú','16/12/2003',N'Nam','037886953','nhattu','123','');


------------------
INSERT INTO LoaiSanPham
VALUES	('LSP1', N'Cây cảnh trong nhà'),
		('LSP2', N'Cây cảnh ngoài trời'),
		('LSP3', N'Cây cảnh bonsai'),
		('LSP4', N'Cây hoa'),
		('LSP5', N'Cây xương rồng')
GO


INSERT INTO NhaSanXuat
VALUES	('NSX1',N'Cây Cảnh Hà Nội','0902256334',N'16 An Lạc, Hà Nội','hd09@gmail.com'),
		('NSX2',N'Cây Cảnh Sài Gòn','032323115',N'140 Lê Trọng Tấn, TP.HCM','bn03@gmail.com'),
		('NSX3',N'Cây Cảnh Miền Trung','0377297150',N'23 Nguyễn Văn An, Quảng Nam','hh99@gmail.com'),
		('NSX4',N'Cây Cảnh Kim Long','037956448',N'34 Âu Cơ, TP.HCM','kl882@gmail.com'),
		('NSX5',N'Cây Cảnh Thành Danh','0905774214',N'02 Tôn Đức Thắng, Hà Nội','td00@gmail.com')
GO

INSERT INTO SanPham 
VALUES  ('SP001', N'Cây Lan Ý',                  300000,  N'Cây trong nhà, dễ chăm sóc',           'caylany.jpg',         'LSP1', 'NSX1', 150, 100),
        ('SP002', N'Cây Kim Tiền',               400000,  N'Cây phong thủy, dễ chăm sóc',          'caykimtien.jpg',      'LSP1', 'NSX1', 130, 200),
        ('SP003', N'Cây Lưỡi Hổ',                250000,  N'Cây lọc không khí',                    'cayluoihp.jpg',       'LSP1', 'NSX1', 160, 300),
        ('SP004', N'Cây Trầu Bà',                200000,  N'Cây xanh mát, dễ chăm sóc',            'caytrauba.jpg',       'LSP1', 'NSX1', 120, 100),
        ('SP005', N'Cây Xương Rồng',             150000,  N'Cây chịu hạn tốt',                     'cayxuongrong.jpg',    'LSP1', 'NSX1', 110, 200),
        ('SP006', N'Cây Đa Búp Đỏ',              350000,  N'Cây trang trí trong nhà',              'caydabupdo.jpg',      'LSP1', 'NSX1', 170, 300),
        ('SP007', N'Cây Vạn Niên Thanh',         220000,  N'Cây lọc không khí',                    'cayvannienthanh.jpg', 'LSP1', 'NSX1', 130, 400),
        ('SP008', N'Cây Thường Xuân',            180000,  N'Cây xanh mát, dễ chăm sóc',            'caythuongxuan.jpg',   'LSP1', 'NSX1', 160, 500),
        ('SP009', N'Cây Hoa Hồng',               500000,  N'Cây hoa đẹp',                          'cayhoahong.jpg',      'LSP4', 'NSX1', 120, 100),
        ('SP010', N'Cây Hoa Lan',                600000,  N'Cây hoa sang trọng',                   'cayhoalan.jpg',       'LSP4', 'NSX1', 150, 200),
        ('SP011', N'Cây Cẩm Tú Cầu',             450000,  N'Cây hoa đẹp',                          'caycamtucau.jpg',     'LSP4', 'NSX1', 130, 300),
        ('SP012', N'Cây Hoa Cúc',                300000,  N'Cây hoa đẹp',                          'cayhoacuc.jpg',       'LSP4', 'NSX1', 160, 400),
        ('SP013', N'Cây Bonsai Tùng La Hán',     800000,  N'Cây bonsai đẹp',                       'caybonsai1.jpg',      'LSP3', 'NSX2', 180, 500),
        ('SP014', N'Cây Bonsai Mai Chiếu Thủy',  900000,  N'Cây bonsai nghệ thuật',                'caybonsai2.jpg',      'LSP3', 'NSX2', 190, 600),
        ('SP015', N'Cây Bonsai Sanh',            1000000, N'Cây bonsai nghệ thuật',                'caybonsai3.jpg',      'LSP3', 'NSX2', 100, 300),
        ('SP016', N'Cây Bonsai Trắc Bách Diệp',  950000,  N'Cây bonsai nghệ thuật',                'caybonsai4.jpg',      'LSP3', 'NSX3', 123, 100),
        ('SP017', N'Cây Bonsai Sam Hương',       1200000, N'Cây bonsai nghệ thuật',                'caybonsai5.jpg',      'LSP3', 'NSX3', 123, 100),
        ('SP018', N'Cây Bonsai Linh Sam',        1300000, N'Cây bonsai nghệ thuật',                'caybonsai6.jpg',      'LSP3', 'NSX3', 123, 100),
        ('SP019', N'Cây Cảnh Mini Sen Đá',       150000,  N'Cây mini dễ chăm sóc',                 'caysenda.jpg',        'LSP5', 'NSX3', 111, 100),
        ('SP020', N'Cây Cảnh Mini Nhất Mạt Hương',150000, N'Cây mini dễ chăm sóc',                 'caynhatmathuong.jpg', 'LSP5', 'NSX5', 111, 100),
        ('SP021', N'Cây Cảnh Mini Xương Rồng',   150000,  N'Cây mini dễ chăm sóc',                 'cayxuongrongmini.jpg','LSP5', 'NSX5', 111, 100)
GO
---------
select * from LoaiSanPham
select * from NhaSanXuat
select * from SanPham
select * from DonHang
select * from ChiTietDonHang
select * from VanChuyen


--select top 9 * from SanPham ORDER BY SanPhamDaBan desc
------------
--select * from NhaSanXuat
----delete from NhaSanXuat where MaNhaSanXuat='NSX1'
----update NhaSanXuat set MaNhaSanXuat='NSX7',TenNhaSanXuat=N'Mới Nhất',SoDienThoai='0902020202',DiaChi=N'dd',Email=N'haha@gmail.com' where MaNhaSanXuat='NSX7'
--Select * from SanPham ORDER BY Gia ASC

--select * from ChitietSP where MaSanPham='SP001'

------ràng buộc------------

set dateformat dmy
--Ràng buộc Giá nhập>0
alter table SanPham
add constraint CHK_Gia check (Gia>0)

--Ràng buộc Số lượng  >0
alter table ChiTietDonHang
add constraint CHK_SoLuong check (SoLuong>0)

--create proc UpdateTatCaDonHang 
--as
--	begin
--		update DonHang 
--		set Email = (select Email from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
--		HoTen =  (select HoTen from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
--		SoDienThoai= (select SoDienThoai from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
--		TongGiaTri = (select sum(SoLuong*ThanhTien) from ChiTietDonHang where ChiTietDonHang.MaDonHang=DonHang.MaDonHang)
--	end;
--go
--create proc Update1DonHang @MaDonHang int
--as
--	begin
--		update DonHang 
--		set Email = (select Email from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
--		HoTen =  (select HoTen from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
--		SoDienThoai= (select SoDienThoai from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
--		TongGiaTri = (select sum(SoLuong*ThanhTien) from ChiTietDonHang where ChiTietDonHang.MaDonHang=DonHang.MaDonHang)
--		where MaDonHang = @MaDonHang
--	end;
--go

--create proc updateThanhTien_CTDH @MaSanPham varchar(20)
--as
--	begin
--		update ChiTietDonHang
--		set ThanhTien=(select SoLuong*Gia from SanPham where ChiTietDonHang.MaSanPham=SanPham.MaSanPham)
--		where MaSanPham=@MaSanPham
--	end;
--go

--alter table DonHang
--add constraint DF_TrangThai default N'Đang xử lý' for TrangThai;


--create procedure UpdateGioHang @Masp VARCHAR(20),@TenDN VARCHAR(20)
--as
--	begin
--		update GioHang 
--		set Gia=(select Gia from SanPham where SanPham.MaSanPham=GioHang.MaSanPham),
--		Anh=(select Anh from SanPham where SanPham.MaSanPham=GioHang.MaSanPham),
--		TenSanPham=(select TenSanPham from SanPham where SanPham.MaSanPham=GioHang.MaSanPham),
--		ThanhTien=(select Gia*SoLuong from SanPham where SanPham.MaSanPham=GioHang.MaSanPham )
--		where TenDN=@TenDN and MaSanPham=@Masp
--	end;
--go

--create procedure TangSoLuong @Masp VARCHAR(20),@TenDN VARCHAR(20)
--as
--	begin
--		update GioHang 
--		set SoLuong =SoLuong+1
--		where TenDN=@TenDN and MaSanPham=@Masp
--	end;
--go

--create procedure ThemGioHang @Masp VARCHAR(20),@TenDN VARCHAR(20)
--as
--	begin
--		if EXISTS (select * from GioHang where MaSanPham=@Masp and TenDN=@TenDN)
--			begin
--				exec TangSoLuong @Masp,@TenDN;
--				exec UpdateGioHang @Masp,@TenDN
--			end;
--		else
--			begin
--				insert into GioHang(TenDN,MaSanPham,SoLuong) values(@TenDN,@Masp,1);
--				exec UpdateGioHang @Masp,@TenDN
--			end;
--	end;
--go

--create proc UpdateSoLuong @Masp VARCHAR(20),@TenDN VARCHAR(20),@SoLuong int
--as
--	begin
--		if @SoLuong <= 0
--			delete from GioHang where TenDN=@TenDN and MaSanPham=@Masp
--		else
--			begin 
--				update GioHang 
--				set SoLuong =@SoLuong
--				where TenDN=@TenDN and MaSanPham=@Masp
--				exec UpdateGioHang @Masp,@TenDN
--			end;
--	end;
--go

--update ChitietSP 
--set TenSanPham = (select TenSanPham from SanPham where ChitietSP.MaSanPham=SanPham.MaSanPham)
--update ChitietSP 
--set Gia = (select Gia from SanPham where ChitietSP.MaSanPham=SanPham.MaSanPham)


--update ChiTietDonHang
--set ThanhTien=(select SoLuong*Gia from SanPham where ChiTietDonHang.MaSanPham=SanPham.MaSanPham)
--go
--exec UpdateTatCaDonHang
--go

--create proc UpdateMK @TenDN varchar(20),@MK nvarchar(100)
--as
--	begin
--		update TaiKhoan
--		set MatKhau=@MK where TenDN=@TenDN 
--	end
--go
--exec UpdateMK 'kh1','1233'
--select * from TaiKhoan




