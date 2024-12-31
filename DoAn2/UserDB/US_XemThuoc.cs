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
using System.IO;

namespace DoAn2.UserDB
    {
    public partial class US_XemThuoc : UserControl
    {
        Functions fn = new Functions();
        public US_XemThuoc()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemThuoc();
        }
       
        private void TimKiemThuoc()
        {
            try
            {
                // Lấy giá trị từ giao diện
                string tuKhoa = txtTimKiem.Text.Trim();
                bool conHan = chkConHan.Checked;
                bool hetHan = chkHetHan.Checked;

                using (SqlConnection conn = Functions.GetSqlConnection())
                {
                    conn.Open();
                    string query = @"
                    SELECT Thuoc.MaThuoc, Thuoc.TenThuoc, Thuoc.MoTa, Thuoc.DonGia, Thuoc.SoLuong, Thuoc.NgaySX, Thuoc.NgayHH, 
                    DanhMuc.TenDM, NhaCungCap.TenNCC, Thuoc.Anh
                    FROM Thuoc 
                    JOIN DanhMuc ON Thuoc.MaDM = DanhMuc.MaDM
                    JOIN NhaCungCap ON Thuoc.MaNCC = NhaCungCap.MaNCC
                     WHERE 
                    (Thuoc.TenThuoc LIKE '%' + @TuKhoa + '%' OR @TuKhoa IS NULL)
                    AND ((Thuoc.NgayHH >= GETDATE() AND @ConHan = 1) 
                    OR (Thuoc.NgayHH < GETDATE() AND @HetHan = 1))
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@TuKhoa", string.IsNullOrEmpty(tuKhoa) ? (object)DBNull.Value : $"%{tuKhoa}%");
                        cmd.Parameters.AddWithValue("@ConHan", conHan ? 1 : 0);
                        cmd.Parameters.AddWithValue("@HetHan", hetHan ? 1 : 0);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Hiển thị kết quả vào DataGridView
                        dgvDanhSachThuoc.DataSource = dt;

                        // Hiển thị thông tin danh mục và nhà cung cấp vào TextBox nếu có kết quả
                        if (dt.Rows.Count > 0)
                        {
                            DataRow firstRow = dt.Rows[0]; // Lấy hàng đầu tiên
                            txtDanhMuc.Text = firstRow["TenDM"]?.ToString() ?? string.Empty;
                            txtNhaCungCap.Text = firstRow["TenNCC"]?.ToString() ?? string.Empty;
                            txtDonGia.Text = firstRow["DonGia"].ToString();
                            // Lấy ảnh từ cơ sở dữ liệu và hiển thị vào PictureBox
                            byte[] imageBytes = firstRow["Anh"] as byte[];
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBoxThuoc.Image = Image.FromStream(ms);  // Tải ảnh vào PictureBox
                                }
                            }
                            else
                            {
                                pictureBoxThuoc.Image = null;  // Nếu không có ảnh, làm trống PictureBox
                            }
                        }
                        else
                        {
                            txtDanhMuc.Text = string.Empty;
                            txtNhaCungCap.Text = string.Empty;
                            pictureBoxThuoc.Image = null;  // Nếu không có kết quả, làm trống PictureBox
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm thuốc: {ex.Message}");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemThuoc();
        }

        private void US_XemThuoc_Load(object sender, EventArgs e)
        {
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

        }

        private void dgvDanhSachThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng chọn dòng hợp lệ (RowIndex >= 0)
                if (e.RowIndex >= 0)
                {
                    // Lấy dòng hiện tại trong DataGridView
                    DataGridViewRow row = dgvDanhSachThuoc.Rows[e.RowIndex];

                    // Hiển thị thông tin thuốc vào các TextBox
                    txtTimKiem.Text = row.Cells["TenThuoc"]?.Value?.ToString() ?? string.Empty;
                    txtDanhMuc.Text = row.Cells["TenDM"]?.Value?.ToString() ?? string.Empty;
                    txtNhaCungCap.Text = row.Cells["TenNCC"]?.Value?.ToString() ?? string.Empty;

                    // Lấy ảnh từ cột HinhAnh và hiển thị vào PictureBox
                    byte[] imageBytes = row.Cells["HinhAnh"].Value as byte[];
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBoxThuoc.Image = Image.FromStream(ms); // Tải ảnh vào PictureBox
                        }
                    }
                    else
                    {
                        pictureBoxThuoc.Image = null; // Nếu không có ảnh, làm trống PictureBox
                    }
                }
            }
            catch (Exception ex)
            {
                // Không hiển thị MessageBox, chỉ ghi log hoặc bỏ qua lỗi
                // Bạn có thể thay MessageBox bằng cách ghi lỗi vào file log hoặc chỉ làm trống
                Console.WriteLine($"Lỗi khi hiển thị thông tin thuốc: {ex.Message}");
            }
        }
    }   
}
