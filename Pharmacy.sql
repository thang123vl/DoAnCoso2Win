CREATE DATABASE Pharmacy;

USE Pharmacy;

-- Tạo bảng ChiNhanh trước
CREATE TABLE ChiNhanh (
    MaCN VARCHAR(50) PRIMARY KEY,  -- Cột MaCN là khóa chính
    TenCN NVARCHAR(100) NOT NULL, 
    DiaChi NVARCHAR(200) NOT NULL, 
    SDT VARCHAR(15) UNIQUE, 
    Email VARCHAR(100) UNIQUE,
    GhiChu NVARCHAR(255) NULL
);

-- Tạo bảng NhaCungCap sau
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(50) PRIMARY KEY,
    MaCN VARCHAR(50),  -- Cột MaCN làm khóa ngoại tham chiếu đến bảng ChiNhanh
    TenNCC NVARCHAR(50) NOT NULL,
    MST NVARCHAR(50) NOT NULL,
    DiaChiNCC NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) UNIQUE,
    Email VARCHAR(50) UNIQUE,
    GhiChu NVARCHAR(100),
    FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)  -- Đảm bảo khóa ngoại tham chiếu đến bảng ChiNhanh
);
select * from NhaCungCap

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH NVARCHAR(50) PRIMARY KEY,
    MaCN VARCHAR(50),
    TenKH NVARCHAR(50) NOT NULL,
    SDT VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    Email VARCHAR(50) UNIQUE,
    FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);
select * from KhachHang

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(50) PRIMARY KEY,
    MaCN VARCHAR(50),
    TenNV NVARCHAR(50) NOT NULL,
    NgaySinh DATE,
    Email VARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    AnhNV VARBINARY(MAX),
    GioiTinh NVARCHAR(10) NOT NULL,
  --  Luong DECIMAL(18,2) CHECK (Luong >= 0),
    FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
);

-- Bảng Nhóm Thuốc
CREATE TABLE DanhMuc (
    MaDM VARCHAR(50) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);
select * from DanhMuc
select * from NhaCungCap
-- Bảng Thuốc
CREATE TABLE Thuoc (
	MaThuoc VARCHAR(50) PRIMARY KEY,
	MaDM VARCHAR(50) NOT NULL,
	MaNV VARCHAR(50) NOT NULL,
	MaNCC VARCHAR(50) NOT NULL,    
	TenThuoc NVARCHAR(50) NOT NULL,
	MoTa NVARCHAR(100) NULL,
	Anh VARBINARY(MAX) NULL, -- Đường dẫn ảnh
	TinhTrang NVARCHAR(50) NOT NULL,
	DVT NVARCHAR(10) NOT NULL,
	DonGia DECIMAL(18, 2) CHECK (DonGia >= 0),
	SoLuong INT NOT NULL CHECK (SoLuong >= 0),
	NgayCungCap DATE NOT NULL,
	NgaySX DATE NOT NULL,
	NgayHH DATE NOT NULL,
	FOREIGN KEY (MaDM) REFERENCES DanhMuc(MaDM),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
);


select * from Thuoc
delete from Thuoc
-- Bảng HDBan (Hóa Đơn Bán)
CREATE TABLE HDBan (
	MaHDBan VARCHAR(50) PRIMARY KEY, 
	MaNV VARCHAR(50) NOT NULL,
	MaKH NVARCHAR(50) NOT NULL,
	NgayBan DATETIME NOT NULL,
	TongTien DECIMAL(18, 2) NOT NULL,
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
select * from HDBan
delete from HDBan
-- Bảng ChiTietBan (Chi Tiết Bán)
CREATE TABLE ChiTietBan ( 
	MaHDBan VARCHAR(50) NOT NULL,
	MaThuoc VARCHAR(50) NOT NULL,
	SoLuong INT NOT NULL,
	DonGia DECIMAL(18, 2) NOT NULL,
	GiamGia DECIMAL(18, 2) NULL,
	ThanhTien DECIMAL(18, 2) NOT NULL,
	PRIMARY KEY (MaHDBan, MaThuoc), -- Khóa chính là sự kết hợp của MaHDBan và MaThuoc
	FOREIGN KEY (MaHDBan) REFERENCES HDBan(MaHDBan),
	FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc)
);
select * from ChiTietBan
delete from ChiTietBan
-- Bảng Hóa Đơn Nhập
CREATE TABLE HDNhap (
    MaHDNhap VARCHAR(50) PRIMARY KEY,
    MaNV VARCHAR(50) NOT NULL,
    MaNCC VARCHAR(50) NOT NULL,
    NgayDat DATE NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL CHECK (TongTien >= 0),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
select * from ChiTietBan
-- Bảng Chi Tiết Nhập
CREATE TABLE ChiTietNhap (
    MaHDNhapHang VARCHAR(50) NOT NULL,
    MaThuoc VARCHAR(50) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    ChietKhau DECIMAL(5, 2) CHECK (ChietKhau >= 0 AND ChietKhau <= 100),
    VAT DECIMAL(5, 2) CHECK (VAT >= 0 AND VAT <= 100),
	ThanhTien DECIMAL(18, 2) NOT NULL,
    DonViTinh NVARCHAR(10),
    PRIMARY KEY (MaHDNhapHang, MaThuoc),
    FOREIGN KEY (MaHDNhapHang) REFERENCES HDNhap(MaHDNhap),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc)
);

-- Bảng Tài Khoản
CREATE TABLE TaiKhoan (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserRole NVARCHAR(50) NOT NULL,
    Ten NVARCHAR(50) NOT NULL,
    NgaySinh DATE,
    Mobile BIGINT NOT NULL,
    Email VARCHAR(250) NOT NULL UNIQUE,
    Username VARCHAR(250) NOT NULL UNIQUE,
    Pass VARCHAR(250) NOT NULL,
    MaNV VARCHAR(50),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Thêm dữ liệu vào bảng ChiNhanh
INSERT INTO ChiNhanh (MaCN, TenCN, DiaChi, SDT, Email, GhiChu)
VALUES
('CN001', N'Chi Nhánh Hà Nội', N'Số 123, Đường A, Quận B, Hà Nội', '0241234567', 'hanoi@pharmacy.vn', N'Chi nhánh chính tại Hà Nội'),
('CN002', N'Chi Nhánh Hồ Chí Minh', N'Số 456, Đường C, Quận D, TP. Hồ Chí Minh', '0287654321', 'hcm@pharmacy.vn', N'Chi nhánh chính tại TP.HCM'),
('CN003', N'Chi Nhánh Đà Nẵng', N'Số 789, Đường E, Quận F, Đà Nẵng', '0236789123', 'danang@pharmacy.vn', N'Chi nhánh tại miền Trung'),
('CN004', N'Chi Nhánh Cần Thơ', N'Số 321, Đường G, Quận H, Cần Thơ', '0294658392', 'cantho@pharmacy.vn', N'Chi nhánh tại miền Tây');

select * from ChiNhanh


INSERT INTO TaiKhoan (UserRole, Ten, NgaySinh, Mobile, Email, Username, Pass, MaNV) 
VALUES 
('User', 'Le Van C', '1988-07-30', 1122334455, 'levanc@example.com', 'NguyenTon', '123', NULL);

INSERT INTO TaiKhoan (UserRole, Ten, NgaySinh, Mobile, Email, Username, Pass, MaNV) 
VALUES 
('Admin', 'Le Van x', '1988-07-29', 11234455, 'levanc@examle.com', 'tonn', '111', NULL);


----Khách Hàng
INSERT INTO KhachHang (MaKH, MaCN, TenKH, SDT, DiaChi, GioiTinh, Email)
VALUES
('KH001', 'CN001', N'Nguyễn Thị A', '0912345678', N'Số 1, Đường A, Hà Nội', N'Nữ', 'nguyenthia@example.com'),
('KH002', 'CN002', N'Lê Văn B', '0923456789', N'Số 2, Đường B, TP.HCM', N'Nam', 'levanb@example.com'),
('KH003', 'CN003', N'Trần Thị C', '0934567890', N'Số 3, Đường C, Đà Nẵng', N'Nữ', 'tranthic@example.com'),
('KH004', 'CN004', N'Phạm Văn D', '0945678901', N'Số 4, Đường D, Cần Thơ', N'Nam', 'phamvand@example.com'),
('KH005', 'CN001', N'Hoàng Thị E', '0956789012', N'Số 5, Đường E, Hà Nội', N'Nữ', 'hoangthie@example.com');


-- Thêm dữ liệu mẫu cho bảng DanhMuc
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM01', N'Kháng sinh');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM02', N'Giảm đau');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM03', N'Hạ huyết áp');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM04', N'Tiểu đường');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM05', N'Vitamin và khoáng chất');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM06', N'Thực phẩm chức năng');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM07', N'Tiêu hóa');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM08', N'Tim mạch');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM09', N'Hô hấp');
INSERT INTO DanhMuc (MaDM, TenDM) VALUES ('DM10', N'Khác');
select * from DanhMuc


--Nhan Viên
INSERT INTO NhanVien (MaNV, MaCN, TenNV, NgaySinh, Email, DiaChi, SDT, AnhNV, GioiTinh, Luong)
VALUES
('NV001', 'CN001', N'Nguyễn Văn A', '1990-01-15', 'nguyenvana@gmail.com', N'Số 12, Đường A, Hà Nội', '0912345678', NULL, N'Nam', 15000000),
('NV002', 'CN002', N'Lê Thị B', '1992-07-10', 'lethib@gmail.com', N'Số 34, Đường B, TP.HCM', '0908765432', NULL, N'Nữ', 18000000),
('NV003', 'CN003', N'Trần Văn C', '1985-05-25', 'tranvanc@gmail.com', N'Số 56, Đường C, Đà Nẵng', '0987654321', NULL, N'Nam', 20000000),
('NV004', 'CN004', N'Phạm Thị D', '1995-09-05', 'phamthid@gmail.com', N'Số 78, Đường D, Cần Thơ', '0976543210', NULL, N'Nữ', 17000000),
('NV005', 'CN001', N'Hoàng Văn E', '1988-03-20', 'hoangvane@gmail.com', N'Số 90, Đường E, Hà Nội', '0932109876', NULL, N'Nam', 16000000);



---Nhà Cung Cấp
INSERT INTO NhaCungCap (MaNCC, MaCN, TenNCC, MST, DiaChiNCC, SDT, Email, GhiChu)
VALUES
('NCC001', 'CN001', N'Công ty Dược Hà Nội', '0101234567', N'Số 1, Đường A, Hà Nội', '0911111111', 'duochanoi@example.com', N'Chuyên cung cấp thuốc nội địa'),
('NCC002', 'CN002', N'Công ty Dược TP.HCM', '0207654321', N'Số 2, Đường B, TP.HCM', '0922222222', 'duochochiminh@example.com', N'Nhà phân phối thuốc nhập khẩu'),
('NCC003', 'CN003', N'Công ty Dược Đà Nẵng', '0309876543', N'Số 3, Đường C, Đà Nẵng', '0933333333', 'duocdanang@example.com', N'Chuyên phân phối thuốc khu vực miền Trung'),
('NCC004', 'CN004', N'Công ty Dược Cần Thơ', '0404567890', N'Số 4, Đường D, Cần Thơ', '0944444444', 'duoccantho@example.com', N'Cung cấp thuốc cho miền Tây'),
('NCC005', 'CN001', N'Công ty Dược Quốc tế', '0501230987', N'Số 5, Đường E, Hà Nội', '0955555555', 'duocquocte@example.com', N'Nhập khẩu và phân phối dược phẩm toàn quốc');
-- Kiểm tra ràng buộc khóa ngoại
SELECT * FROM ChiNhanh;

INSERT INTO Thuoc (MaThuoc, MaDM, MaNV, MaNCC, TenThuoc, MoTa, Anh, TinhTrang, DVT, DonGia, SoLuong, NgayCungCap, NgaySX, NgayHH)
VALUES
('TH001', 'DM01', 'NV001', 'NCC001', 'Paracetamol', N'Thuốc giảm đau, hạ sốt', NULL, 'Còn hạn', 'Viên', 5000, 100, '2024-11-20', '2023-11-01', '2025-11-01'),
('TH002', 'DM01', 'NV002', 'NCC002', 'Ibuprofen', N'Thuốc giảm đau, chống viêm', NULL, 'Còn hạn', 'Viên', 8000, 150, '2024-10-15', '2023-05-01', '2024-10-01'),
('TH003', 'DM02', 'NV003', 'NCC003', 'Amoxicillin', N'Kháng sinh, điều trị nhiễm trùng', NULL, 'Hết hạn', 'Viên', 12000, 50, '2024-11-05', '2022-09-01', '2023-09-01'),
('TH004', 'DM03', 'NV001', 'NCC001', 'Aspirin', N'Thuốc giảm đau, chống viêm', NULL, 'Còn hạn', 'Viên', 3000, 200, '2024-09-01', '2023-07-15', '2025-09-01'),
('TH005', 'DM02', 'NV002', 'NCC002', 'Cetirizine', N'Thuốc dị ứng, giảm ngứa', NULL, 'Còn hạn', 'Viên', 6000, 120, '2024-11-10', '2023-06-20', '2025-11-10'),
('TH006', 'DM03', 'NV003', 'NCC003', 'Metformin', N'Thuốc điều trị tiểu đường', NULL, 'Còn hạn', 'Viên', 10000, 180, '2024-11-18', '2023-08-05', '2025-08-05'),
('TH007', 'DM01', 'NV001', 'NCC001', 'Lorazepam', N'Thuốc an thần', NULL, 'Hết hạn', 'Viên', 15000, 70, '2024-12-01', '2022-03-10', '2023-12-10'),
('TH008', 'DM02', 'NV002', 'NCC002', 'Simvastatin', N'Thuốc điều trị cholesterol', NULL, 'Còn hạn', 'Viên', 20000, 90, '2024-10-25', '2023-01-10', '2025-10-25'),
('TH009', 'DM01', 'NV001', 'NCC004', 'Dextromethorphan', N'Thuốc trị ho, cảm lạnh', NULL, 'Còn hạn', 'Siro', 25000, 120, '2024-11-25', '2023-07-10', '2025-11-25'),
('TH010', 'DM03', 'NV002', 'NCC005', 'Hydrochlorothiazide', N'Thuốc điều trị tăng huyết áp', NULL, 'Còn hạn', 'Viên', 12000, 200, '2024-11-12', '2023-05-15', '2025-11-12'),
('TH011', 'DM02', 'NV003', 'NCC005', 'Loratadine', N'Thuốc trị dị ứng', NULL, 'Còn hạn', 'Viên', 7500, 150, '2024-11-05', '2023-06-01', '2025-11-05'),
('TH012', 'DM01', 'NV002', 'NCC001', 'Paroxetine', N'Thuốc điều trị trầm cảm', NULL, 'Còn hạn', 'Viên', 10000, 130, '2024-11-10', '2023-08-01', '2025-11-10'),
('TH013', 'DM03', 'NV003', 'NCC004', 'Losartan', N'Thuốc điều trị cao huyết áp', NULL, 'Còn hạn', 'Viên', 15000, 90, '2024-11-15', '2023-04-20', '2025-11-15'),
('TH014', 'DM02', 'NV001', 'NCC004', 'Gabapentin', N'Thuốc điều trị đau dây thần kinh', NULL, 'Còn hạn', 'Viên', 22000, 110, '2024-11-18', '2023-02-10', '2025-11-18'),
('TH015', 'DM03', 'NV002', 'NCC005', 'Zolpidem', N'Thuốc an thần, ngủ ngon', NULL, 'Hết hạn', 'Viên', 30000, 75, '2024-11-22', '2022-05-20', '2023-11-22'),
('TH016', 'DM02', 'NV003', 'NCC002', 'Fluoxetine', N'Thuốc điều trị trầm cảm', NULL, 'Còn hạn', 'Viên', 18000, 95, '2024-11-30', '2023-04-01', '2025-11-30');

 delete from Thuoc
