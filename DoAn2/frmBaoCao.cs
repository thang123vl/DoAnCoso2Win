using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2
{
    public partial class frmBaoCao : Form
    {
        Functions fn = new Functions();
        private System.Drawing.Printing.PrintDocument printDocument1;

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm

            // Truy vấn lấy số lượng sản phẩm
            string query = "SELECT MaThuoc, TenThuoc, SoLuong, DonGia " +
                           "FROM Thuoc " +
                           "WHERE TenThuoc LIKE @Keyword OR MaThuoc LIKE @Keyword";

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị dữ liệu lên DataGridView
                dgvBaoCao.DataSource = dt;

                // Tính tổng số lượng sản phẩm
                int totalQuantity = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalQuantity += Convert.ToInt32(row["SoLuong"]);
                }

                lblTongSoLuong.Text = "Tổng số lượng sản phẩm: " + totalQuantity;
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            string selectedReport = cboBaoCao.SelectedItem.ToString();

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();
                DataTable dtBaoCao = new DataTable();

                if (selectedReport == "Báo cáo số lượng thuốc")
                {
                    // Truy vấn số lượng thuốc
                    string querySoLuongThuoc = @"
                     SELECT 
                    MaThuoc, 
                    TenThuoc, 
                    SoLuong, 
                    DonGia 
                    FROM Thuoc";

                    SqlDataAdapter adapter = new SqlDataAdapter(querySoLuongThuoc, conn);
                    adapter.Fill(dtBaoCao);
                }
                else if (selectedReport == "Báo cáo 5 sản phẩm bán chạy nhất")
                {
                    string queryTop5Products = @"
                    SELECT TOP 5 
                    T.MaThuoc, 
                    T.TenThuoc, 
                    SUM(CT.SoLuong) AS TongSoLuongBan, 
                    T.DonGia,
                    (SUM(CT.SoLuong) * T.DonGia) AS TongDoanhThu
                    FROM ChiTietBan CT
                    INNER JOIN Thuoc T ON CT.MaThuoc = T.MaThuoc
                    GROUP BY T.MaThuoc, T.TenThuoc, T.DonGia
                    ORDER BY TongSoLuongBan DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(queryTop5Products, conn);
                    adapter.Fill(dtBaoCao);

                    if (dtBaoCao.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu cho báo cáo này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                dgvBaoCao.DataSource = dtBaoCao;
            }
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            // Thêm các tùy chọn vào ComboBox
            cboBaoCao.Items.Add("Báo cáo số lượng thuốc");
            cboBaoCao.Items.Add("Báo cáo 5 sản phẩm bán chạy nhất");

            // Đặt giá trị mặc định
            cboBaoCao.SelectedIndex = 0;

            // Ẩn label tổng số lượng nếu chưa tìm kiếm
            lblTongSoLuong.Text = string.Empty;
            // Khởi tạo printDocument và đăng ký sự kiện
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument1,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Lấy lựa chọn từ ComboBox
            string selectedReport = cboBaoCao.SelectedItem.ToString();

            // Tiêu đề báo cáo
            Font headerFont = new Font("Times New Roman", 16, FontStyle.Bold);
            e.Graphics.DrawString("Báo cáo: " + selectedReport, headerFont, Brushes.Black, new PointF(200, 50));

            // Cột tiêu đề
            Font columnFont = new Font("Times New Roman", 12, FontStyle.Bold);
            int startX = 100;
            int startY = 120;
            int offset = 25;

            // Vẽ viền cho bảng
            Pen pen = new Pen(Color.Black);

            if (selectedReport == "Báo cáo số lượng thuốc")
            {
                // In báo cáo số lượng thuốc
                string querySoLuongThuoc = @"SELECT MaThuoc, TenThuoc, SoLuong, DonGia FROM Thuoc";

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable dtSoLuongThuoc = GetData(querySoLuongThuoc);

                // In tiêu đề cột với căn chỉnh
                e.Graphics.DrawString("Mã Thuốc", columnFont, Brushes.Black, startX, startY);
                e.Graphics.DrawString("Tên Thuốc", columnFont, Brushes.Black, startX + 150, startY);
                e.Graphics.DrawString("Số Lượng Tồn", columnFont, Brushes.Black, startX + 300, startY);
                e.Graphics.DrawString("Đơn Giá", columnFont, Brushes.Black, startX + 450, startY);

                // Vẽ viền cột tiêu đề
                e.Graphics.DrawLine(pen, startX, startY + 20, startX + 600, startY + 20);

                // In dữ liệu
                startY += offset;
                Font dataFont = new Font("Times New Roman", 12);
                foreach (DataRow row in dtSoLuongThuoc.Rows)
                {
                    e.Graphics.DrawString(row["MaThuoc"].ToString(), dataFont, Brushes.Black, startX, startY);
                    e.Graphics.DrawString(row["TenThuoc"].ToString(), dataFont, Brushes.Black, startX + 150, startY);
                    e.Graphics.DrawString(row["SoLuong"].ToString(), dataFont, Brushes.Black, startX + 300, startY);
                    e.Graphics.DrawString(row["DonGia"].ToString(), dataFont, Brushes.Black, startX + 450, startY);

                    // Vẽ viền hàng
                    e.Graphics.DrawLine(pen, startX, startY + 15, startX + 600, startY + 15);

                    startY += offset;
                }
            }
            else if (selectedReport == "Báo cáo 5 sản phẩm bán chạy nhất")
            {
                // In báo cáo 5 sản phẩm bán chạy nhất
                string queryTop5Products = @" SELECT TOP 5 T.MaThuoc, T.TenThuoc, 
                SUM(CT.SoLuong) AS TongSoLuongBan, 
                T.DonGia,
                (SUM(CT.SoLuong) * T.DonGia) AS TongDoanhThu
                FROM ChiTietBan CT
                INNER JOIN Thuoc T ON CT.MaThuoc = T.MaThuoc
                GROUP BY T.MaThuoc, T.TenThuoc, T.DonGia
                ORDER BY TongSoLuongBan DESC";

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable dtTop5Products = GetData(queryTop5Products);

                // In tiêu đề cột với căn chỉnh
                e.Graphics.DrawString("Mã Thuốc", columnFont, Brushes.Black, startX, startY);
                e.Graphics.DrawString("Tên Thuốc", columnFont, Brushes.Black, startX + 150, startY);
                e.Graphics.DrawString("Số Lượng Bán", columnFont, Brushes.Black, startX + 300, startY);
                e.Graphics.DrawString("Đơn Giá", columnFont, Brushes.Black, startX + 450, startY);
                e.Graphics.DrawString("Tổng Doanh Thu", columnFont, Brushes.Black, startX + 600, startY);

                // Vẽ viền cột tiêu đề
                e.Graphics.DrawLine(pen, startX, startY + 20, startX + 750, startY + 20);

                // In dữ liệu
                startY += offset;
                Font dataFont = new Font("Times New Roman", 12);
                foreach (DataRow row in dtTop5Products.Rows)
                {
                    e.Graphics.DrawString(row["MaThuoc"].ToString(), dataFont, Brushes.Black, startX, startY);
                    e.Graphics.DrawString(row["TenThuoc"].ToString(), dataFont, Brushes.Black, startX + 150, startY);
                    e.Graphics.DrawString(row["TongSoLuongBan"].ToString(), dataFont, Brushes.Black, startX + 300, startY);
                    e.Graphics.DrawString(row["DonGia"].ToString(), dataFont, Brushes.Black, startX + 450, startY);
                    e.Graphics.DrawString(row["TongDoanhThu"].ToString(), dataFont, Brushes.Black, startX + 600, startY);

                    // Vẽ viền hàng
                    e.Graphics.DrawLine(pen, startX, startY + 15, startX + 750, startY + 15);

                    startY += offset;
                }
            }
        }


        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn= Functions.GetSqlConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        private void cboBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
