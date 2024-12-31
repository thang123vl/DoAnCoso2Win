using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;


namespace DoAn2.UserDB
{
    public partial class US_AddThuoc : UserControl
    {
        Functions fn = new Functions();
/*        String query;
        DataSet ds;
*/
        string drugImagePath; // Biến để lưu trữ đường dẫn tệp ảnh

        public US_AddThuoc()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadData();
            txtMaThuoc.Text = GenerateMaThuoc();
            txtMaThuoc.ReadOnly = true; // Không cho phép nhập mã thuốc
        }
        // Load dữ liệu từ bảng vào DataGridView
        private void LoadData()
        {
            string query = "SELECT * FROM Thuoc";
            DataSet ds = fn.GetData(query);
            if (ds != null)
            {
                dgvThuoc.DataSource = ds.Tables[0];
            }
        }

        // Load dữ liệu vào ComboBox
        private void LoadComboBoxData()
        {
            // Load MaDM
            DataSet dsDM = fn.GetData("SELECT MaDM, TenDM FROM DanhMuc");
            cboMaDM.DataSource = dsDM.Tables[0];
            cboMaDM.DisplayMember = "TenDM";
            cboMaDM.ValueMember = "MaDM";

            // Load MaNV
            DataSet dsNV = fn.GetData("SELECT MaNV, TenNV FROM NhanVien");
            cboNhanVien.DataSource = dsNV.Tables[0];
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";

            // Load MaNCC
            DataSet dsNCC = fn.GetData("SELECT MaNCC, TenNCC FROM NhaCungCap");
            cboNCC.DataSource = dsNCC.Tables[0];
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";

            // TinhTrang
            cboTinhTrang.Items.AddRange(new string[] { "Còn hàng", "Hết hàng", "Ngừng kinh doanh" });
        }
    
     
        // Tự động sinh mã thuốc
        private string GenerateMaThuoc()
        {
            // Truy vấn để lấy mã thuốc lớn nhất hiện tại
            string query = "SELECT MAX(MaThuoc) FROM Thuoc";
            object result = fn.ExecuteScalar(query);

            // Nếu chưa có thuốc nào trong DB, bắt đầu với mã TH001
            if (result == DBNull.Value || result == null)
            {
                return "TH001";
            }

            // Lấy giá trị mã thuốc cuối cùng và tăng lên 1
            string maxMaThuoc = result.ToString();
            int numericPart = int.Parse(maxMaThuoc.Substring(2)); // Lấy phần số sau "TH"
            numericPart++; // Tăng phần số lên 1
            return "TH" + numericPart.ToString("D3"); // Format lại thành TH001, TH002, ...
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {  // Kiểm tra giá trị nhập vào
            string donGiaInput = txtDonGia.Text;
            decimal donGia;
            string soLuongInput = txtSoLuong.Text;

            // Kiểm tra xem các trường số có hợp lệ không
            if (!decimal.TryParse(donGiaInput, out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ! Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(soLuongInput, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ! Vui lòng nhập số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo câu truy vấn thêm thuốc
            string query = "INSERT INTO Thuoc (MaThuoc, MaDM, MaNV, MaNCC, TenThuoc, MoTa, DVT, DonGia, SoLuong, TinhTrang, NgayCungCap, NgaySX, NgayHH, Anh) " +
                           "VALUES (@MaThuoc, @MaDM, @MaNV, @MaNCC, @TenThuoc, @MoTa, @DVT, @DonGia, @SoLuong, @TinhTrang, @NgayCungCap, @NgaySX, @NgayHH, @Anh)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaThuoc", GenerateMaThuoc()), // Gọi hàm sinh mã thuốc
                new SqlParameter("@MaDM", cboMaDM.SelectedValue),
                new SqlParameter("@MaNV", cboNhanVien.SelectedValue),
                new SqlParameter("@MaNCC", cboNCC.SelectedValue),
                new SqlParameter("@TenThuoc", txtTenThuoc.Text),
                new SqlParameter("@MoTa", txtMoTa.Text),
                new SqlParameter("@DVT", txtDVT.Text),
                new SqlParameter("@DonGia", donGia),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@TinhTrang", cboTinhTrang.SelectedItem.ToString()),
                new SqlParameter("@NgayCungCap", dtpNgayNhap.Value),
                new SqlParameter("@NgaySX", dtpNgaySX.Value),
                new SqlParameter("@NgayHH", dtpNgayHH.Value),
                new SqlParameter("@Anh", ConvertImageToByteArray(picAnh.Image)) // Chuyển đổi hình ảnh
            };

            fn.SetDataWithParams(query, parameters, "Thêm thuốc thành công!");
            LoadData();
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            return null; // Trả về null nếu không có hình ảnh
        }
        private void btnAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                drugImagePath = openFileDialog.FileName;
                picAnh.Image = Image.FromFile(drugImagePath);
                picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn thuốc trong DataGridView chưa
            if (dgvThuoc.SelectedRows.Count > 0)
            {
                // Lấy mã thuốc từ dòng đã chọn
                string maThuoc = dgvThuoc.SelectedRows[0].Cells["MaThuoc"].Value.ToString();

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Tạo câu truy vấn xóa thuốc
                    string query = "DELETE FROM Thuoc WHERE MaThuoc = @MaThuoc";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@MaThuoc", maThuoc)
                    };

                    // Thực hiện truy vấn xóa
                    fn.SetDataWithParams(query, parameters, "Xóa thuốc thành công!");
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã thuốc từ dòng đã chọn
            string maThuoc = dgvThuoc.SelectedRows[0].Cells["MaThuoc"].Value.ToString();

            // Kiểm tra giá trị nhập vào
            string donGiaInput = txtDonGia.Text;
            string soLuongInput = txtSoLuong.Text;

            // Kiểm tra xem các trường số có hợp lệ không
            if (!decimal.TryParse(donGiaInput, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ! Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(soLuongInput, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ! Vui lòng nhập số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo câu truy vấn cập nhật thuốc
            string query = "UPDATE Thuoc SET MaDM = @MaDM, MaNV = @MaNV, MaNCC = @MaNCC, TenThuoc = @TenThuoc, MoTa = @MoTa, DVT = @DVT, DonGia = @DonGia, SoLuong = @SoLuong, TinhTrang = @TinhTrang, NgayCungCap = @NgayCungCap, NgaySX = @NgaySX, NgayHH = @NgayHH, Anh = @Anh WHERE MaThuoc = @MaThuoc";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDM", cboMaDM.SelectedValue),
                new SqlParameter("@MaNV", cboNhanVien.SelectedValue),
                new SqlParameter("@MaNCC", cboNCC.SelectedValue),
                new SqlParameter("@TenThuoc", txtTenThuoc.Text),
                new SqlParameter("@MoTa", txtMoTa.Text),
                new SqlParameter("@DVT", txtDVT.Text),
                new SqlParameter("@DonGia", donGia),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@TinhTrang", cboTinhTrang.SelectedItem.ToString()),
                new SqlParameter("@NgayCungCap", dtpNgayNhap.Value),
                new SqlParameter("@NgaySX", dtpNgaySX.Value),
                new SqlParameter("@NgayHH", dtpNgayHH.Value),
                new SqlParameter("@Anh", ConvertImageToByteArray(picAnh.Image)), // Chuyển đổi hình ảnh
                new SqlParameter("@MaThuoc", maThuoc) // Mã thuốc để cập nhật
            };

            fn.SetDataWithParams(query, parameters, "Cập nhật thuốc thành công!");
            LoadData(); // Tải lại dữ liệu sau khi cập nhật
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            // Xóa tất cả thông tin trên các ô nhập liệu
            txtMaThuoc.Text = GenerateMaThuoc(); // Tạo mã thuốc mới
            txtTenThuoc.Clear();
            txtMoTa.Clear();
            txtDVT.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            cboTinhTrang.SelectedIndex = -1; // Không chọn gì
            cboMaDM.SelectedIndex = -1; // Không chọn gì
            cboNhanVien.SelectedIndex = -1; // Không chọn gì
            cboNCC.SelectedIndex = -1; // Không chọn gì
            picAnh.Image = null; // Xóa hình ảnh

            // Tải lại dữ liệu từ cơ sở dữ liệu
            LoadData();
        }

        private void btnTaiLai_Click_1(object sender, EventArgs e)
        {
            // Xóa tất cả thông tin trên các ô nhập liệu
            txtMaThuoc.Text = GenerateMaThuoc(); // Tạo mã thuốc mới
            txtTenThuoc.Clear();
            txtMoTa.Clear();
            txtDVT.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            cboTinhTrang.SelectedIndex = -1; // Không chọn gì
            cboMaDM.SelectedIndex = -1; // Không chọn gì
            cboNhanVien.SelectedIndex = -1; // Không chọn gì
            cboNCC.SelectedIndex = -1; // Không chọn gì
            picAnh.Image = null; // Xóa hình ảnh

            // Tải lại dữ liệu từ cơ sở dữ liệu
            LoadData();
        }

        private void dgvThuoc_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng có chỉ số lớn hơn hoặc bằng 0 (hàng không hợp lệ)
            if (e.RowIndex >= 0)
            {
                // Lấy hàng đã chọn
                DataGridViewRow selectedRow = dgvThuoc.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox
                txtMaThuoc.Text = selectedRow.Cells["MaThuoc"].Value.ToString();
                txtTenThuoc.Text = selectedRow.Cells["TenThuoc"].Value.ToString();
                txtMoTa.Text = selectedRow.Cells["MoTa"].Value.ToString();
                txtDVT.Text = selectedRow.Cells["DVT"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                cboTinhTrang.SelectedItem = selectedRow.Cells["TinhTrang"].Value.ToString();
                cboMaDM.SelectedValue = selectedRow.Cells["MaDM"].Value.ToString();
                cboNhanVien.SelectedValue = selectedRow.Cells["MaNV"].Value.ToString();
                cboNCC.SelectedValue = selectedRow.Cells["MaNCC"].Value.ToString();

                // Xử lý hình ảnh
                byte[] imageData = selectedRow.Cells["Anh"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picAnh.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picAnh.Image = null; // Đặt hình ảnh về null nếu không có
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmDanhMuc frmDanhMuc = new frmDanhMuc();
            frmDanhMuc.ShowDialog();
        }

        private void LoadCboDMData()
        {
            // Load MaDM
            DataSet dsDM = fn.GetData("SELECT MaDM, TenDM FROM DanhMuc");
            cboMaDM.DataSource = dsDM.Tables[0];
            cboMaDM.DisplayMember = "TenDM";
            cboMaDM.ValueMember = "MaDM";
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            LoadCboDMData();  // Gọi hàm LoadComboBoxData để tải lại dữ liệu cho các ComboBox
            MessageBox.Show("Đã tải lại dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void US_AddThuoc_Load(object sender, EventArgs e)
        {

        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            // Thiết lập giấy phép trước khi sử dụng EPPlus
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;     // hoặc LicenseContext.NonCommercial

            // Mở hộp thoại chọn file Excel
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Đọc dữ liệu từ Excel
                    FileInfo fileInfo = new FileInfo(filePath);
                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Chọn sheet đầu tiên

                        bool isDataAdded = false; // Cờ để kiểm tra có dữ liệu nào được thêm vào không

                        // Lặp qua các dòng trong Excel
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Bắt đầu từ dòng 2 nếu dòng 1 là tiêu đề
                        {
                            string maThuoc = worksheet.Cells[row, 1].Text;
                            string maDM = worksheet.Cells[row, 2].Text;
                            string maNV = worksheet.Cells[row, 3].Text;
                            string maNCC = worksheet.Cells[row, 4].Text;
                            string tenThuoc = worksheet.Cells[row, 5].Text;
                            string moTa = worksheet.Cells[row, 6].Text;
                            string dvt = worksheet.Cells[row, 7].Text;

                            // Sử dụng TryParse để kiểm tra dữ liệu hợp lệ
                            decimal donGia = 0;
                            if (!decimal.TryParse(worksheet.Cells[row, 8].Text, out donGia))
                            {
                                donGia = 0; // Bạn có thể thông báo lỗi ở đây nếu cần
                            }

                            int soLuong = 0;
                            if (!int.TryParse(worksheet.Cells[row, 9].Text, out soLuong))
                            {
                                soLuong = 0; // Bạn có thể thông báo lỗi ở đây nếu cần
                            }

                            string tinhTrang = worksheet.Cells[row, 10].Text;

                            // Xử lý ngày tháng với TryParse để tránh lỗi
                            DateTime ngayCungCap = DateTime.MinValue;
                            if (!DateTime.TryParse(worksheet.Cells[row, 11].Text, out ngayCungCap) || ngayCungCap == DateTime.MinValue)
                            {
                                ngayCungCap = DateTime.Now; // Nếu không hợp lệ, gán giá trị mặc định
                            }

                            DateTime ngaySX = DateTime.MinValue;
                            if (!DateTime.TryParse(worksheet.Cells[row, 12].Text, out ngaySX) || ngaySX == DateTime.MinValue)
                            {
                                ngaySX = DateTime.Now; // Nếu không hợp lệ, gán giá trị mặc định
                            }

                            DateTime ngayHH = DateTime.MinValue;
                            if (!DateTime.TryParse(worksheet.Cells[row, 13].Text, out ngayHH) || ngayHH == DateTime.MinValue)
                            {
                                ngayHH = DateTime.Now; // Nếu không hợp lệ, gán giá trị mặc định
                            }

                            byte[] anh = null;
                            var pictures = worksheet.Drawings.OfType<ExcelPicture>().ToList();

                            foreach (var picture in pictures)
                            {
                                if (picture.From.Column == 14)  // Điều chỉnh số cột nếu cần
                                {
                                    // Direct byte array extraction
                                    anh = picture.Image.ImageBytes;
                                }
                            }

                            // Tạo câu lệnh SQL INSERT
                            string query = "INSERT INTO Thuoc (MaThuoc, MaDM, MaNV, MaNCC, TenThuoc, MoTa, DVT, DonGia, SoLuong, TinhTrang, NgayCungCap, NgaySX, NgayHH, Anh) " +
                                           "VALUES (@MaThuoc, @MaDM, @MaNV, @MaNCC, @TenThuoc, @MoTa, @DVT, @DonGia, @SoLuong, @TinhTrang, @NgayCungCap, @NgaySX, @NgayHH, @Anh)";

                            SqlParameter[] parameters = new SqlParameter[]
                            {
                        new SqlParameter("@MaThuoc", maThuoc),
                        new SqlParameter("@MaDM", maDM),
                        new SqlParameter("@MaNV", maNV),
                        new SqlParameter("@MaNCC", maNCC),
                        new SqlParameter("@TenThuoc", tenThuoc),
                        new SqlParameter("@MoTa", moTa),
                        new SqlParameter("@DVT", dvt),
                        new SqlParameter("@DonGia", donGia),
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@TinhTrang", tinhTrang),
                        new SqlParameter("@NgayCungCap", ngayCungCap),
                        new SqlParameter("@NgaySX", ngaySX),
                        new SqlParameter("@NgayHH", ngayHH),
                        new SqlParameter("@Anh", SqlDbType.VarBinary, -1)
                        {
                            Value = anh ?? (object)DBNull.Value  // Gán giá trị null nếu không có ảnh
                        }
                            };

                            fn.SetDataWithParams(query, parameters, "Thêm thuốc từ Excel thành công!");
                            isDataAdded = true; // Đánh dấu đã thêm dữ liệu thành công
                        }

                        // Thông báo chỉ 1 lần sau khi tất cả dữ liệu đã được xử lý
                        if (isDataAdded)
                        {
                            MessageBox.Show("Dữ liệu đã được thêm từ Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xử lý file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
