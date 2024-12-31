using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace DoAn2.AdminDB
{
    public partial class UC_XemNV : UserControl
    {
        Functions fn = new Functions();
        String query;
        public UC_XemNV()
        {
            InitializeComponent();
            // Đăng ký các sự kiện
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            this.Load += UC_XemNV_Load;  
            btnTaiLai.Click += btnTaiLai_Click;  
            btnSync.Click += btnSync_Click;

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            LoadNhanVienData();
        }
        private void LoadNhanVienData()
        {
            query = "SELECT MaNV, MaCN, TenNV, NgaySinh, Email, DiaChi, SDT, AnhNV, GioiTinh FROM NhanVien";
            DataSet ds = fn.GetData(query);
            dgvNhanVien.DataSource = ds.Tables[0];
        }


        private void LoadChiNhanhData()
        {
            query = "SELECT MaCN, TenCN FROM ChiNhanh";
            DataSet ds = fn.GetData(query);
            cboMaCN.DataSource = ds.Tables[0];
            cboMaCN.DisplayMember = "TenCN";
            cboMaCN.ValueMember = "MaCN";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    SqlParameter[] parameters = { new SqlParameter("@MaNV", maNV) };
                    fn.SetDataWithParams(query, parameters, "Nhân viên đã được xóa thành công.");
                    LoadNhanVienData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                cboMaCN.SelectedItem = row.Cells["MaCN"].Value?.ToString() ?? "";
                txtTenNV.Text = row.Cells["TenNV"].Value?.ToString() ?? "";
                dtpNgaySinh.Value = row.Cells["NgaySinh"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["NgaySinh"].Value) : DateTime.Now;
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";

                if (row.Cells["AnhNV"].Value != DBNull.Value)
                {
                    byte[] photoData = (byte[])row.Cells["AnhNV"].Value;
                    using (MemoryStream ms = new MemoryStream(photoData))
                    {
                        picEmployeePhoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picEmployeePhoto.Image = null;
                }

                cboGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString() ?? "Khác";
            }
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                cboMaCN.SelectedIndex == -1) // Kiểm tra chọn chi nhánh
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] photoData = GetPhotoData();

            string query = "UPDATE NhanVien SET  MaCN = @MaCN, TenNV = @TenNV, NgaySinh = @NgaySinh, Email = @Email, DiaChi = @DiaChi, SDT = @SDT, AnhNV = @AnhNV, GioiTinh = @GioiTinh WHERE MaNV = @MaNV";

            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", txtMaNV.Text),
                new SqlParameter("@MaCN", cboMaCN.SelectedValue),
                new SqlParameter("@TenNV", txtTenNV.Text),
                new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text),
                new SqlParameter("@SDT", txtSDT.Text),
                new SqlParameter("@AnhNV", photoData ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", cboGioiTinh.SelectedItem?.ToString() ?? "Khác"),
            };

            try
            {
                fn.SetDataWithParams(query, parameters, "Cập nhật thông tin nhân viên thành công!");
                LoadNhanVienData(); // Tải lại dữ liệu sau khi cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] GetPhotoData()
        {
            if (picEmployeePhoto.Image == null)
            {
                return null;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Lưu ảnh theo định dạng JPEG
                    picEmployeePhoto.Image.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (ExternalException ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
               string.IsNullOrWhiteSpace(txtTenNV.Text) ||
               string.IsNullOrWhiteSpace(txtEmail.Text) ||
               string.IsNullOrWhiteSpace(txtSDT.Text) ||
               cboMaCN.SelectedIndex == -1)  // Kiểm tra nếu không chọn chi nhánh
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] photoData = GetPhotoData();

            string query = "INSERT INTO NhanVien (MaNV, MaCN, TenNV, NgaySinh, Email, DiaChi, SDT, AnhNV, GioiTinh) " +
                           "VALUES (@MaNV, @MaCN, @TenNV, @NgaySinh, @Email, @DiaChi, @SDT, @AnhNV, @GioiTinh)";

            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", txtMaNV.Text),
                new SqlParameter("@MaCN", cboMaCN.SelectedValue),
                new SqlParameter("@TenNV", txtTenNV.Text),
                new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text),
                new SqlParameter("@SDT", txtSDT.Text),
                new SqlParameter("@AnhNV", photoData ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", cboGioiTinh.SelectedItem?.ToString() ?? "Khác"),
            };

            try
            {
                fn.SetDataWithParams(query, parameters, "Lưu thông tin nhân viên thành công!");
                LoadNhanVienData(); // Tải lại dữ liệu sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = GenerateEmployeeId(); // Gán mã tự sinh mới
            ClearTextBoxes(); // Xóa các trường thông tin khác nếu cần
        }
        private string GenerateEmployeeId()
        {
            string newId;
            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaNV, 3, LEN(MaNV) - 2) AS INT)) FROM NhanVien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int numericPart = result != DBNull.Value && result != null ? Convert.ToInt32(result) + 1 : 1;
                    newId = "NV" + numericPart.ToString("D3");
                }
            }
            return newId;
        }
        private void ClearTextBoxes()
        {

            txtTenNV.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            cboGioiTinh.SelectedIndex = -1;
            picEmployeePhoto.Image = null;
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picEmployeePhoto.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void UC_XemNV_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = GenerateEmployeeId();  // Gán mã tự sinh mới cho txtMaNV
            LoadNhanVienData();  // Tải dữ liệu nhân viên lên DataGridView
            LoadChiNhanhData();  // Tải danh sách chi nhánh vào ComboBox
            AddGenderItem("Nam");
            AddGenderItem("Nữ");
            AddGenderItem("Khác");
            txtSearch.TextChanged += txtSearch_TextChanged;  // Gắn sự kiện TextChanged
        }
        private void AddGenderItem(string gender)
        {
            if (!cboGioiTinh.Items.Contains(gender))
            {
                cboGioiTinh.Items.Add(gender);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                SearchNhanVien(searchTerm);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchNhanVien(string searchTerm)
        {
            // Tạo câu truy vấn tìm kiếm, tìm nhân viên có tên, email, hoặc số điện thoại chứa từ khóa (searchTerm) ở bất kỳ vị trí nào
            query = "SELECT * FROM NhanVien WHERE TenNV LIKE @SearchTerm OR Email LIKE @SearchTerm OR SDT LIKE @SearchTerm";

            // Sử dụng % để tìm tất cả các giá trị chứa searchTerm ở bất kỳ vị trí nào
            SqlParameter[] parameters = { new SqlParameter("@SearchTerm", "%" + searchTerm + "%") };

            // Thực thi truy vấn và cập nhật DataGridView
            DataSet ds = fn.GetData(query, parameters);
            dgvNhanVien.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                SearchNhanVien(searchTerm);
            }
            else
            {
                // Nếu trường tìm kiếm trống, hiển thị lại toàn bộ danh sách
                LoadNhanVienData();
            }
        }
    }
}
