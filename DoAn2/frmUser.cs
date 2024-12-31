using DoAn2.AdminDB;
using DoAn2.UserDB;
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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
           
            uS_Dashbord1.Visible = false;
            uS_NhaCungCap1.Visible = false;
            uS_KhachHang1.Visible = false;
            uS_AddThuoc1.Visible = false;
            uS_HoaDon1.Visible = false;
            uS_XemThuoc1.Visible = false;
            uS_TraCuuHD1.Visible = false;
            // uS_ThongKe1.Visible = false;
            btnDashBord.PerformClick();
        }

        private void btnDashBord_Click(object sender, EventArgs e)
        {
          uS_Dashbord1.Visible = true;
            uS_Dashbord1.BringToFront();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();
            this.Hide();
        }

        private void uS_NhaCungCap1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uS_KhachHang1.Visible = true;
            uS_KhachHang1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uS_HoaDon1.Visible = true;
            uS_HoaDon1.BringToFront();
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            uS_AddThuoc1.Visible = true;
            uS_AddThuoc1.BringToFront();
        }

        private void btnXemThuoc_Click(object sender, EventArgs e)
        {
            uS_XemThuoc1.Visible = true;
            uS_XemThuoc1.BringToFront();
        }

        private void uS_ThongKe1_Load(object sender, EventArgs e)
        {

        }

        private void tKHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmDonHoa frmDonHoa = new frmDonHoa();
            frmDonHoa.ShowDialog();
        }

        private void thêmThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_AddThuoc1.Visible = true;
            uS_AddThuoc1.BringToFront();
        }

        private void danhMụcThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMuc frmDanhMuc = new frmDanhMuc();
            frmDanhMuc.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();
            this.Hide();
        }

        private void xemThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_XemThuoc1.Visible = true;
            uS_XemThuoc1.BringToFront();
        }

        private void nhàCungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_NhaCungCap1.Visible = true;
            uS_NhaCungCap1.BringToFront();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_KhachHang1.Visible = true;
            uS_KhachHang1.BringToFront();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_HoaDon1.Visible = true;
            uS_HoaDon1.BringToFront();
        }

        private void tKThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTK_Thuoc frmTK_Thuoc = new frmTK_Thuoc();
            frmTK_Thuoc.ShowDialog();
        }

        private void tinTứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNews frmNews = new frmNews();
            frmNews.ShowDialog();
        }

        private void uS_Dashbord1_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp frmHelp = new frmHelp();    
            frmHelp.ShowDialog();
        }

        private void traCứuHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uS_TraCuuHD1.Visible = true;
            uS_TraCuuHD1.BringToFront() ;
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCao frmBaoCao = new frmBaoCao();
            frmBaoCao.ShowDialog();
        }
    }
}
