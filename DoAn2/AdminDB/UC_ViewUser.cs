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

namespace DoAn2.AdminDB
{
    public partial class UC_ViewUser : UserControl
    {
        Functions fn = new Functions();
        String query;

        public UC_ViewUser()
        {
            InitializeComponent();
        }

        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "Select * from TaiKhoan";
            DataSet ds = fn.GetData(query);
            dgvViewUser.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TaiKhoan WHERE Username LIKE @SearchText OR UserRole LIKE @SearchText";

            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@SearchText", txtSearch.Text + "%")
            };

            DataSet ds = fn.GetData(query, parameters);
            dgvViewUser.DataSource = ds.Tables[0];
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một dòng chưa
            if (dgvViewUser.SelectedRows.Count > 0)
            {
                // Lấy Username từ dòng được chọn
                string username = dgvViewUser.SelectedRows[0].Cells["Username"].Value.ToString();

                // Xác nhận trước khi xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    // Thực hiện truy vấn xóa
                    string query = "DELETE FROM TaiKhoan WHERE Username = @Username";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Username", username)
                    };

                    // Gọi phương thức xóa từ lớp Functions
                    fn.SetDataWithParams(query, parameters, "Tài khoản đã được xóa thành công.");

                    // Cập nhật lại bảng hiển thị sau khi xóa
                    LoadUserData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void LoadUserData()
        {
            string query = "SELECT * FROM TaiKhoan";
            DataSet ds = fn.GetData(query);
            dgvViewUser.DataSource = ds.Tables[0];
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void dgvViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
