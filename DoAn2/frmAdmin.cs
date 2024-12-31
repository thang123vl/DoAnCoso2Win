using DoAn2.AdminDB;
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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();
            this.Hide();
        }

        public frmAdmin (string user)
        {
            InitializeComponent();  
            lblUserName.Text = user;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            uC_DasbBord1.Visible = false;
            uC_AddUser1.Visible = false;
            uC_HoaDon1.Visible = false;
            uC_ViewUser1.Visible = false;
            uC_XemNV1.Visible = false;

            uS_AddThuoc1.Visible = false;
            uS_XemThuoc1.Visible = false;
            uS_NhaCungCap1.Visible = false;
            // btndashbord.PerformClick();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btndashbord_Click(object sender, EventArgs e)
        {
            uC_DasbBord1.Visible = true;
            uC_DasbBord1.BringToFront();
        }

        private void uC_XemNV1_Load(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_HoaDon1.Visible = true;
            uC_HoaDon1.BringToFront();
        }

        private void xemNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void thêmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_XemNV1.Visible = true;
            uC_XemNV1.BringToFront();
        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void bảngĐiềuKhiểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uC_DasbBord1.Visible = true;
            uC_DasbBord1.BringToFront();
        }

        private void uC_HoaDon1_Load(object sender, EventArgs e)
        {

        }

        private void thêmThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_AddThuoc1.Visible = true;
            uS_AddThuoc1.BringToFront();
        }

        private void xemThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_XemThuoc1.Visible = true;
            uS_XemThuoc1.BringToFront();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_NhaCungCap1.Visible = true;
            uS_NhaCungCap1.BringToFront();
        }
    }
}
