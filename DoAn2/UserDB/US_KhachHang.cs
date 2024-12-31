using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2.UserDB
{
    public partial class US_KhachHang : UserControl
    {
        Functions dbFunctions = new Functions();
        public US_KhachHang()
        {
            InitializeComponent();
            LoadKhachHangList();
            InitializeGenderComboBox();
            InitializeMaCNComboBox(); // Gọi hàm để tải mã chi nhánh
        }

        private void InitializeMaCNComboBox()
        {
            string query = "SELECT MaCN, TenCN FROM ChiNhanh";
            DataSet ds = dbFunctions.GetData(query);

            cboCN.DisplayMember = "TenCN"; // Hiển thị tên chi nhánh
            cboCN.ValueMember = "MaCN";   // Lưu giá trị mã chi nhánh

            cboCN.DataSource = ds.Tables[0];
            cboCN.SelectedIndex = 0; // Đặt giá trị mặc định cho cboCN
        }
        private void LoadKhachHangList()
        {
            string query = "SELECT * FROM KhachHang";
            DataSet ds = dbFunctions.GetData(query);
            dgvKhachHang.DataSource = ds.Tables[0];
        }

        private void InitializeGenderComboBox()
        {
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");
            cboGioiTinh.SelectedIndex = 0; // Đặt giá trị mặc định
        }
       

        private void btnThem_Click(object sender, EventArgs e)
        {

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(mtbSoDienThoai.Text) || mtbSoDienThoai.Text == "(   )    -")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDienThoai.Focus();
                return;
            }

            string soDienThoai = mtbSoDienThoai.Text;

            // Kiểm tra số điện thoại có trùng lặp
            string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE SDT = @SDT";
            SqlParameter[] checkParams = { new SqlParameter("@SDT", soDienThoai) };
            int count = (int)dbFunctions.ExecuteScalar(checkQuery, checkParams);

            if (count > 0)
            {
                MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng nhập số khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDienThoai.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            // Kiểm tra nếu không chọn giới tính hợp lệ
            if (!new List<string> { "Nam", "Nữ", "Khác" }.Contains(cboGioiTinh.SelectedItem?.ToString()))
            {
                MessageBox.Show("Vui lòng chọn giới tính hợp lệ (Nam, Nữ, Khác).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Thêm khách hàng
            string maKH = dbFunctions.GenerateMaKH();
            string tenKH = txtTenKH.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string gt = cboGioiTinh.SelectedItem?.ToString();
            string maCN = cboCN.SelectedValue.ToString(); // Lấy mã chi nhánh từ ComboBox

            txtMaKH.Text = maKH;
            txtMaKH.Enabled = false;

            string query = "INSERT INTO KhachHang (MaKH, MaCN, TenKH, SDT, DiaChi, GioiTinh, Email) VALUES (@MaKH, @MaCN, @TenKH, @SDT, @DiaChi, @GioiTinh, @Email)";
            SqlParameter[] parameters = {
            new SqlParameter("@MaKH", maKH),
            new SqlParameter("@MaCN", maCN),  // Thêm MaCN vào câu lệnh
            new SqlParameter("@TenKH", tenKH),
            new SqlParameter("@SDT", soDienThoai),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@GioiTinh", gt),
            new SqlParameter("@Email", email)
            };

            dbFunctions.SetDataWithParams(query, parameters, "Thêm khách hàng thành công!");
            LoadKhachHangList();
            ClearTextBoxes();

        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE KhachHang SET TenKH = @TenKH, SDT = @SDT, DiaChi = @DiaChi, GioiTinh = @GioiTinh, Email = @Email, MaCN = @MaCN WHERE MaKH = @MaKH";
            SqlParameter[] parameters = {
            new SqlParameter("@MaKH", txtMaKH.Text),
            new SqlParameter("@TenKH", txtTenKH.Text),
            new SqlParameter("@SDT", mtbSoDienThoai.Text),
            new SqlParameter("@DiaChi", txtDiaChi.Text),
            new SqlParameter("@GioiTinh", cboGioiTinh.SelectedItem?.ToString() ?? "Không xác định"),
            new SqlParameter("@Email", txtEmail.Text),
            new SqlParameter("@MaCN", cboCN.SelectedValue.ToString()) // Cập nhật MaCN
            };
            dbFunctions.SetDataWithParams(query, parameters, "Cập nhật khách hàng thành công!");
            LoadKhachHangList();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            SqlParameter[] parameters = { new SqlParameter("@MaKH", maKH) };
            dbFunctions.SetDataWithParams(query, parameters, "Xóa khách hàng thành công!");
            LoadKhachHangList();
        }


        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                mtbSoDienThoai.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text;
            string query = "SELECT * FROM KhachHang WHERE TenKH LIKE @searchText";
            SqlParameter[] parameters = { new SqlParameter("@searchText", "%" + searchText + "%") };

            DataSet ds = dbFunctions.GetDataWithParams(query, parameters);
            dgvKhachHang.DataSource = ds.Tables[0];
        }
        private void ClearTextBoxes()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            mtbSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cboGioiTinh.SelectedIndex = 0;
        }

        private void US_KhachHang_Load(object sender, EventArgs e)
        {
            
        }
        private void US_KhachHang_Load_1(object sender, EventArgs e)
        {

        }
    }
}
