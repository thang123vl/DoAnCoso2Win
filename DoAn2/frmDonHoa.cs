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
    public partial class frmDonHoa : Form
    {
       Functions fn = new Functions();
        public frmDonHoa()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Truy vấn doanh thu trong khoảng thời gian
            string queryDoanhThu = "SELECT SUM(TongTien) AS DoanhThu " +
                                    "FROM HDBan " +
                                    "WHERE NgayBan BETWEEN @StartDate AND @EndDate";

            // Truy vấn số lượng hóa đơn trong khoảng thời gian
            string queryHoaDon = "SELECT MaHDBan, NgayBan, SUM(TongTien) AS TongTien " +
                                 "FROM HDBan " +
                                 "WHERE NgayBan BETWEEN @StartDate AND @EndDate " +
                                 "GROUP BY MaHDBan, NgayBan";

            // Truy vấn thống kê doanh thu của nhân viên
            string queryNhanVienBanChay = "SELECT NV.MaNV, NV.TenNV, SUM(H.TongTien) AS DoanhThu " +
                                          "FROM HDBan H " +
                                          "INNER JOIN NhanVien NV ON H.MaNV = NV.MaNV " +
                                          "WHERE H.NgayBan BETWEEN @StartDate AND @EndDate " +
                                          "GROUP BY NV.MaNV, NV.TenNV " +
                                          "ORDER BY DoanhThu DESC";


            // Truy vấn thống kê lợi nhuận
            string queryLoiNhuan = "SELECT SUM(CT.SoLuong * (H.TongTien - (CT.SoLuong * T.DonGia))) AS LoiNhuan " +
                                   "FROM ChiTietBan CT " +
                                   "INNER JOIN Thuoc T ON CT.MaThuoc = T.MaThuoc " +
                                   "INNER JOIN HDBan H ON CT.MaHDBan = H.MaHDBan " +
                                   "WHERE H.NgayBan BETWEEN @StartDate AND @EndDate";

            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();

                // Nếu chọn "Hóa Đơn"
                if (chkHoaDon.Checked)
                {
                    // Thực hiện truy vấn hóa đơn
                    SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, conn);
                    cmdHoaDon.Parameters.AddWithValue("@StartDate", startDate);
                    cmdHoaDon.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapterHoaDon = new SqlDataAdapter(cmdHoaDon);
                    DataTable dtHoaDon = new DataTable();
                    adapterHoaDon.Fill(dtHoaDon);

                    // Hiển thị kết quả vào DataGridView
                    dgvThongKe.DataSource = dtHoaDon;

                    // Cập nhật label số lượng hóa đơn
                    lblHoaDon.Text = "Tổng hóa đơn: " + dtHoaDon.Rows.Count.ToString();
                }
                // Thực hiện truy vấn nhân viên bán chạy nhất
                SqlCommand cmdNhanVienBanChay = new SqlCommand(queryNhanVienBanChay, conn);
                cmdNhanVienBanChay.Parameters.AddWithValue("@StartDate", startDate);
                cmdNhanVienBanChay.Parameters.AddWithValue("@EndDate", endDate);


                using (SqlDataReader reader = cmdNhanVienBanChay.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string topSeller = reader["TenNV"].ToString();
                        string totalSales = reader["DoanhThu"].ToString();
                        lblTopSeller.Text = "Nhân viên bán chạy nhất: " + topSeller + " với doanh thu: " + totalSales;
                    }
                    else
                    {
                        lblTopSeller.Text = "Không có dữ liệu.";
                    }

                }
             

                // Lợi nhuận
                SqlCommand cmdLoiNhuan = new SqlCommand(queryLoiNhuan, conn);
                cmdLoiNhuan.Parameters.AddWithValue("@StartDate", startDate);
                cmdLoiNhuan.Parameters.AddWithValue("@EndDate", endDate);
                object resultLoiNhuan = cmdLoiNhuan.ExecuteScalar();

                // Nếu chọn "Doanh Thu"
                if (chkDoanhThu.Checked)
                {
                    SqlCommand cmdDoanhThu = new SqlCommand(queryDoanhThu, conn);
                    cmdDoanhThu.Parameters.AddWithValue("@StartDate", startDate);
                    cmdDoanhThu.Parameters.AddWithValue("@EndDate", endDate);
                    object resultDoanhThu = cmdDoanhThu.ExecuteScalar();

                    lblDoanhThu.Text = "Doanh thu từ " + startDate.ToString("dd/MM/yyyy") + " đến " + endDate.ToString("dd/MM/yyyy") + ": " + (resultDoanhThu ?? 0);
                    lblLoiNhuan.Text = "Lợi nhuận: " + (resultLoiNhuan ?? 0);

                    // Cập nhật biểu đồ
                    chartThongKe.Series.Clear();

                    // Series Doanh Thu
                    var seriesDoanhThu = chartThongKe.Series.Add("Doanh thu");
                    seriesDoanhThu.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    seriesDoanhThu.Points.AddXY("Doanh thu", resultDoanhThu ?? 0);

                    // Series Lợi Nhuận
                    var seriesLoiNhuan = chartThongKe.Series.Add("Lợi nhuận");
                    seriesLoiNhuan.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    seriesLoiNhuan.Points.AddXY("Lợi nhuận", resultLoiNhuan ?? 0);
                }

            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmDonHoa_Load(object sender, EventArgs e)
        {

        }
    }     
}
