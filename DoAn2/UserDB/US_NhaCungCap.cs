using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2.UserDB
{
    public partial class US_NhaCungCap : UserControl
    {
        Functions dbFunctions = new Functions();

        public US_NhaCungCap()
        {
            InitializeComponent();
            dbFunctions = new Functions(); // Khởi tạo lớp Functions
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
        }

        private void LoadNhaCungCapList()
        {
            string query = "SELECT * FROM NhaCungCap";
            DataSet ds = dbFunctions.GetData(query);
            dgvNCC.DataSource = ds.Tables[0];
        }

        private void LoadChiNhanhList()
        {
            string query = "SELECT MaCN, TenCN FROM ChiNhanh";
            DataSet ds = dbFunctions.GetData(query);

            cboCN.DisplayMember = "TenCN"; // Hiển thị tên chi nhánh
            cboCN.ValueMember = "MaCN";   // Lưu giá trị mã chi nhánh

            cboCN.DataSource = ds.Tables[0];
            cboCN.SelectedIndex = 0; // Đặt giá trị mặc định cho cboCN
        }

        private string GenerateMaNCC()
        {
            string query = "SELECT TOP 1 MaNCC FROM NhaCungCap ORDER BY MaNCC DESC";
            try
            {
                DataSet ds = dbFunctions.GetData(query);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string lastMaNCC = ds.Tables[0].Rows[0]["MaNCC"].ToString();
                    string newMaNCC = "NCC" + (int.Parse(lastMaNCC.Substring(3)) + 1).ToString("D3");
                    return newMaNCC;
                }
                return "NCC001"; // Nếu chưa có bản ghi nào
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "NCC001";
            }
        }
        private void CustomizeDataGridViewColumns()
        {
            dgvNCC.Columns["MaNCC"].HeaderText = "Mã Nhà Cung Cấp";
            dgvNCC.Columns["MaCN"].HeaderText = "Mã Chi Nhánh";
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên Nhà Cung Cấp";
            dgvNCC.Columns["MST"].HeaderText = "Mã Số Thuế";
            dgvNCC.Columns["DiaChiNCC"].HeaderText = "Địa Chỉ";
            dgvNCC.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgvNCC.Columns["Email"].HeaderText = "Email";
            dgvNCC.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private bool IsMaNCCExists(string maNCC)
        {
            string query = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaNCC", maNCC) };
            try
            {
                DataSet ds = dbFunctions.GetDataWithParams(query, parameters);
                return ds.Tables[0].Rows.Count > 0 && (int)ds.Tables[0].Rows[0][0] > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra mã nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void US_NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCapList(); // Tải dữ liệu khi User Control được nạp
            LoadChiNhanhList();  // Tải danh sách Chi Nhánh vào ComboBox
            txtMaNCC.Text = GenerateMaNCC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
                    string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
                    cboCN.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo");
                    return;
                }

                // Kiểm tra sự tồn tại của mã chi nhánh
                string checkCNQuery = "SELECT COUNT(*) FROM ChiNhanh WHERE MaCN = @MaCN";
                SqlParameter[] checkParams = new SqlParameter[]
                {
            new SqlParameter("@MaCN", cboCN.SelectedValue.ToString())
                };

                int cnExists = Convert.ToInt32(dbFunctions.ExecuteScalar(checkCNQuery, checkParams));
                if (cnExists == 0)
                {
                    MessageBox.Show("Mã chi nhánh không tồn tại!", "Lỗi");
                    return;
                }

                // Thêm nhà cung cấp mới
                string query = @"INSERT INTO NhaCungCap 
                        (MaNCC, MaCN, TenNCC, MST, DiaChiNCC, SDT, Email, GhiChu) 
                        VALUES 
                        (@MaNCC, @MaCN, @TenNCC, @MST, @DiaChiNCC, @SDT, @Email, @GhiChu)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaNCC", txtMaNCC.Text),
            new SqlParameter("@MaCN", cboCN.SelectedValue.ToString()), // Sử dụng SelectedValue
            new SqlParameter("@TenNCC", txtTenNCC.Text),
            new SqlParameter("@MST", txtMST.Text),
            new SqlParameter("@DiaChiNCC", txtDiaChi.Text),
            new SqlParameter("@SDT", txtDienThoai.Text),
            new SqlParameter("@Email", txtEmail.Text),
            new SqlParameter("@GhiChu", txtGhiChu.Text)
                };

                dbFunctions.SetDataWithParams(query, parameters, "Thêm nhà cung cấp thành công!");
                LoadNhaCungCapList();  // Load lại danh sách nhà cung cấp
                ClearTextBoxes();  // Xóa các trường nhập liệu
                txtMaNCC.Text = GenerateMaNCC();  // Tạo mã nhà cung cấp mới
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }
       
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNCC.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtMST.Text = row.Cells["MST"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChiNCC"].Value.ToString();
                txtDienThoai.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNCC.SelectedRows.Count > 0)
            {
                string maNCC = dgvNCC.SelectedRows[0].Cells["MaNCC"].Value.ToString();
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@MaNCC", maNCC) };
                    try
                    {
                        dbFunctions.SetDataWithParams(query, parameters, "Xóa nhà cung cấp thành công!");
                        LoadNhaCungCapList();  // Load lại danh sách nhà cung cấp
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadNhaCungCapList();
                return;
            }

            string query = "SELECT * FROM NhaCungCap WHERE TenNCC LIKE @searchText";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@searchText", "%" + searchText + "%") };
            DataSet ds = dbFunctions.GetDataWithParams(query, parameters);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgvNCC.DataSource = ds.Tables[0];
            }
            else
            {
                dgvNCC.DataSource = null;
                MessageBox.Show("Không tìm thấy nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, MST = @MST, DiaChiNCC = @DiaChiNCC, SDT = @SDT, Email = @Email, GhiChu = @GhiChu WHERE MaNCC = @MaNCC";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaNCC", txtMaNCC.Text),
        new SqlParameter("@TenNCC", txtTenNCC.Text),
        new SqlParameter("@MST", txtMST.Text),
        new SqlParameter("@DiaChiNCC", txtDiaChi.Text),
        new SqlParameter("@SDT", txtDienThoai.Text),
        new SqlParameter("@Email", txtEmail.Text),
        new SqlParameter("@GhiChu", txtGhiChu.Text)
            };

            try
            {
                dbFunctions.SetDataWithParams(query, parameters, "Cập nhật nhà cung cấp thành công!");
                LoadNhaCungCapList();  // Load lại danh sách nhà cung cấp
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LoadNhaCungCapList();
            LoadChiNhanhList();  // Tải danh sách Chi Nhánh vào ComboBox
            ClearTextBoxes();
        }
      
        private void ClearTextBoxes()
        {
            txtTenNCC.Clear();
            txtMST.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtGhiChu.Clear();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}   
   
