using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2
{
    public partial class frmDangNhap : Form
    {
        Functions fn =  new Functions();
        String query;
        DataSet ds;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            query = "select * from TaiKhoan";
            ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtUserName.Text == "root" && txtPass.Text =="root")
                {
                    frmAdmin admin = new frmAdmin();
                    admin.Show();
                    this.Hide();

                }
            }
            else
            {
                query = "select * from TaiKhoan where Username ='" + txtUserName.Text + "' and Pass = '" + txtPass.Text + "' ";
                ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();   
                    if (role == "Admin")//Collection ở AddUser 
                    {
                        frmAdmin admin = new frmAdmin(txtUserName.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "User")
                    {
                        frmUser user = new frmUser();
                        user.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu sai","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPass.Clear();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus(); // Chuyển con trỏ đến txtPass
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1.PerformClick(); // Giả lập nhấn nút Đăng nhập
            }
        }
    }
}
