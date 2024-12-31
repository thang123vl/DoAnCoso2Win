using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAn2.AdminDB
{
    public partial class UC_AddUser : UserControl
    {
        private Functions fn = new Functions();

        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            string role = txtVaiTro.Text;
            string name = txtTen.Text;
            string dob = dtpngaysinh.Value.ToString("yyyy-MM-dd"); // Định dạng ngày sinh
            string mobileInput = txtSoDienthoai.Text.Trim();
            string email = txtDiaChi.Text; // Đảm bảo bạn đã có trường email trong form
            string username = txtUsername.Text;
            string pass = txtMatKhau.Text;

            // Kiểm tra ngày sinh không lớn hơn ngày hiện tại
            if (dtpngaysinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "INSERT INTO TaiKhoan (UserRole, Ten, NgaySinh, Mobile, Email, Username, Pass) VALUES (@UserRole, @Ten, @NgaySinh, @Mobile, @Email, @Username, @Pass)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserRole", role),
                    new SqlParameter("@Ten", name),
                    new SqlParameter("@NgaySinh", dob),
                    new SqlParameter("@Mobile", mobileInput),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Pass", pass) // Xem xét mã hóa mật khẩu
                };

                fn.SetDataWithParams(query, parameters, "Đăng ký thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            txtUsername.Clear();
            dtpngaysinh.ResetText();
            txtMatKhau.Clear();
            txtSoDienthoai.Clear();
            txtDiaChi.Clear();
            txtTen.Clear();
            txtVaiTro.SelectedIndex = -1; // Reset giá trị combobox
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TaiKhoan WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@Username", txtUsername.Text)
            };

            DataSet ds = fn.GetData(query, parameters); // Gọi hàm GetData với tham số

            // Cập nhật hình ảnh dựa trên việc tồn tại username
            if (ds.Tables[0].Rows.Count == 0)
            {
                pictrAdduser.ImageLocation = @"D:\\DoAn2\\DoAn2\\Image\\yes.png"; // Username hợp lệ
            }
            else
            {
                pictrAdduser.ImageLocation = @"D:\\DoAn2\\DoAn2\\Image\\no.png"; // Username đã tồn tại
            }
        }

        private void UC_AddUser_Load(object sender, EventArgs e)
        {

        }

        private void pictrAdduser_Click(object sender, EventArgs e)
        {

        }
    }
}
