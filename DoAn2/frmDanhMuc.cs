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

namespace DoAn2
{
    public partial class frmDanhMuc : Form
    {
        Functions fn = new Functions();
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        // Nạp dữ liệu vào DataGridView
        private void LoadDanhMuc()
        {
            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();

                string query = "SELECT MaDM, TenDM FROM DanhMuc";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDanhMuc.DataSource = dt;
            }
        }

        private string GenerateMaDM()
        {
            string newMaDM = "DM001"; // Mã mặc định nếu bảng rỗng

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();

                // Truy vấn mã danh mục lớn nhất hiện có
                string query = "SELECT MAX(MaDM) FROM DanhMuc";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    string maxMaDM = result.ToString(); // Lấy mã lớn nhất
                    if (!string.IsNullOrEmpty(maxMaDM))
                    {
                        int number = int.Parse(maxMaDM.Substring(2)); // Tách phần số
                        newMaDM = $"DM{(number + 1):D3}"; // Tăng lên 1 và định dạng lại
                    }
                }
            }

            // Kiểm tra nếu mã đã tồn tại
            while (CheckMaDanhMucExists(newMaDM))
            {
                int number = int.Parse(newMaDM.Substring(2)); // Tách phần số
                newMaDM = $"DM{(number + 1):D3}"; // Tăng lên 1 và kiểm tra lại
            }

            return newMaDM;

        }
        private bool CheckMaDanhMucExists(string maDM)
        {
            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DanhMuc WHERE MaDM = @MaDM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDM", maDM);

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Trả về true nếu mã đã tồn tại, false nếu chưa tồn tại
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDM.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tự động sinh mã danh mục
            string maDM = GenerateMaDM();

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                string query = "INSERT INTO DanhMuc (MaDM, TenDM) VALUES (@MaDM, @TenDM)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDM", maDM);
                cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text.Trim());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearForm()
        {
            txtMaDM.Clear();
            txtTenDM.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                string query = "SELECT MaDM, TenDM FROM DanhMuc WHERE TenDM LIKE @TenDM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDM", $"%{txtTimKiem.Text.Trim()}%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDanhMuc.DataSource = dt;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();

                string query = @"
                SELECT MaDM, TenDM  FROM DanhMuc 
                WHERE TenDM LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", $"%{tuKhoa}%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDanhMuc.DataSource = dt; // Hiển thị kết quả tìm kiếm
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDM.Text))
            {
                MessageBox.Show("Vui lòng nhập mã danh mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                string query = "DELETE FROM DanhMuc WHERE MaDM = @MaDM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaDM.Text) || string.IsNullOrEmpty(txtTenDM.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                string query = "UPDATE DanhMuc SET TenDM = @TenDM WHERE MaDM = @MaDM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text.Trim());
                cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                txtMaDM.Text = row.Cells["MaDM"].Value.ToString();
                txtTenDM.Text = row.Cells["TenDM"].Value.ToString();
            }
        }
    }
}
