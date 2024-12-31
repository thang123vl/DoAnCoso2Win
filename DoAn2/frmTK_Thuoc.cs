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
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn2
{
    public partial class frmTK_Thuoc : Form
    {
        Functions fn = new Functions();

        public frmTK_Thuoc()
        {
            InitializeComponent();
        }
        // Khai báo biến toàn cục trong lớp
        private int soLuongThuocConHan = 0;
        private int soLuongThuocHetHan = 0;
        private int soLuongThuocGanHetHan = 0;
        private void ConfigureChart()
        {
            // Xóa các Series và ChartArea cũ
            chartThongKe.Series.Clear();
            chartThongKe.ChartAreas.Clear();

            // Tạo ChartArea mới
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartThongKe.ChartAreas.Add(chartArea);

            // Thêm Series vào biểu đồ
            Series series = new Series
            {
                Name = "Thuoc",
                ChartType = SeriesChartType.Pie, // Dạng biểu đồ tròn
                IsValueShownAsLabel = true,
                Label = "#PERCENT", // Hiển thị phần trăm
                LegendText = "#VALX (#PERCENT)" // Hiển thị phần trăm trong chú thích
            };
            chartThongKe.Series.Add(series);

            // Thêm dữ liệu vào biểu đồ
            series.Points.AddXY("Thuốc còn hạn", soLuongThuocConHan); // Số lượng thuốc còn hạn
            series.Points.AddXY("Thuốc hết hạn", soLuongThuocHetHan); // Số lượng thuốc hết hạn
            series.Points.AddXY("Thuốc gần hết hạn", soLuongThuocGanHetHan); // Số lượng thuốc gần hết hạn
        }

    


    private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Truy vấn dữ liệu
            string query = @"
            SELECT 
            SUM(CASE WHEN NgayHH < GETDATE() THEN 1 ELSE 0 END) AS ThuocHetHan,
            SUM(CASE WHEN NgayHH >= GETDATE() THEN 1 ELSE 0 END) AS ThuocConHan
             FROM Thuoc";

            DataTable dt = Functions.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                // Lấy dữ liệu từ truy vấn
                int thuocHetHan = Convert.ToInt32(dt.Rows[0]["ThuocHetHan"]);
                int thuocConHan = Convert.ToInt32(dt.Rows[0]["ThuocConHan"]);

                // Cập nhật dữ liệu vào biểu đồ
                chartThongKe.Series["Thuoc"].Points.Clear();
                chartThongKe.Series["Thuoc"].Points.AddXY("Thuốc hết hạn", thuocHetHan);
                chartThongKe.Series["Thuoc"].Points.AddXY("Thuốc còn hạn", thuocConHan);

                // Hiển thị tổng số lượng lên Label
                lblHetHan.Text = $"Thuốc hết hạn: {thuocHetHan}";
                lblConHan.Text = $"Thuốc còn hạn: {thuocConHan}";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Gọi hàm để lấy số lượng thuốc hết hạn và gần hết hạn
            LoadThongKeThuocHetHan();

            // Gọi hàm để cập nhật biểu đồ
            ConfigureChart();
        }

        private void LoadThongKeThuocHetHan()
        {
            using (SqlConnection conn = Functions.GetSqlConnection())
            {
                conn.Open();

                // Truy vấn số lượng thuốc còn hạn
                string queryConHan = @"
                SELECT COUNT(*) 
                FROM Thuoc 
                WHERE NgayHH >= GETDATE()";
                SqlCommand cmdConHan = new SqlCommand(queryConHan, conn);
                soLuongThuocConHan = (int)cmdConHan.ExecuteScalar();

                // Truy vấn số lượng thuốc hết hạn
                string queryHetHan = @"
                SELECT COUNT(*) 
                FROM Thuoc 
                WHERE NgayHH < GETDATE()";
                SqlCommand cmdHetHan = new SqlCommand(queryHetHan, conn);
                soLuongThuocHetHan = (int)cmdHetHan.ExecuteScalar();

                // Truy vấn số lượng thuốc gần hết hạn (hết hạn trong vòng 1 tháng)
                string queryGanneHetHan = @"
                SELECT COUNT(*) 
                FROM Thuoc 
                WHERE NgayHH BETWEEN GETDATE() AND DATEADD(MONTH, 1, GETDATE())";
                SqlCommand cmdGanneHetHan = new SqlCommand(queryGanneHetHan, conn);
                soLuongThuocGanHetHan = (int)cmdGanneHetHan.ExecuteScalar();

                // Cập nhật label cho số thuốc gần hết hạn
                lblThuocGanHetHan.Text = "Số thuốc gần hết hạn: " + soLuongThuocGanHetHan.ToString();
            }
        }

        private void frmTK_Thuoc_Load(object sender, EventArgs e)
        {
            // Cấu hình biểu đồ khi form được load
            ConfigureChart();
        }
    }
}
