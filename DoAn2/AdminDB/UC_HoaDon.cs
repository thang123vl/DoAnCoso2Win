using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace DoAn2.AdminDB
{
    public partial class UC_HoaDon : UserControl
    {

        private PrintDocument printDocument = new PrintDocument();
        private string printContent = ""; // Nội dung hóa đơn sẽ in
        Functions fn = new Functions();
        public UC_HoaDon()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiem.Text.Trim(); // Lấy giá trị tìm kiếm

            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm (tên khách hàng hoặc số điện thoại).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Câu truy vấn kết hợp đầy đủ thông tin
            string query = @"
            SELECT 
            HDBan.MaHDBan, 
            HDBan.NgayBan, 
            HDBan.TongTien, 
            KhachHang.TenKH, 
            KhachHang.SDT, 
            Thuoc.TenThuoc, 
            ChiTietBan.SoLuong, 
            ChiTietBan.DonGia, 
            ChiTietBan.GiamGia, 
            ChiTietBan.ThanhTien
            FROM HDBan
            JOIN KhachHang ON HDBan.MaKH = KhachHang.MaKH
            JOIN ChiTietBan ON HDBan.MaHDBan = ChiTietBan.MaHDBan
            JOIN Thuoc ON ChiTietBan.MaThuoc = Thuoc.MaThuoc
            WHERE KhachHang.TenKH LIKE @searchQuery
            OR KhachHang.SDT LIKE @searchQuery";

            // Thêm tham số cho truy vấn
            SqlParameter[] parameters = {
            new SqlParameter("@searchQuery", "%" + searchQuery + "%")
            };

            // Gọi hàm lấy dữ liệu
            Functions functions = new Functions();
            DataSet ds = functions.GetData(query, parameters);

            // Kiểm tra và hiển thị kết quả
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dgvHDBanHang.DataSource = ds.Tables[0]; // Gán dữ liệu vào DataGridView
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khớp với yêu cầu tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHDBanHang.DataSource = null; // Xóa dữ liệu cũ nếu không tìm thấy
            }
        }
    

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHDBanHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy Mã Hóa Đơn từ dòng được chọn
            string maHDBan = dgvHDBanHang.SelectedRows[0].Cells["MaHDBan"].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn với mã {maHDBan}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Câu lệnh xóa các bản ghi liên quan
            string queryDeleteChiTiet = "DELETE FROM ChiTietBan WHERE MaHDBan = @MaHDBan";
            string queryDeleteHDBan = "DELETE FROM HDBan WHERE MaHDBan = @MaHDBan";

            try
            {
                Functions functions = new Functions();

                // Xóa các chi tiết hóa đơn trước
                SqlParameter[] parametersChiTiet = {
                 new SqlParameter("@MaHDBan", maHDBan)
                };
                functions.ExecuteQuery(queryDeleteChiTiet, parametersChiTiet);

                // Xóa hóa đơn
                SqlParameter[] parametersHDBan = {
                new SqlParameter("@MaHDBan", maHDBan)
                };
                functions.ExecuteQuery(queryDeleteHDBan, parametersHDBan);

                // Cập nhật lại DataGridView sau khi xóa
                MessageBox.Show("Xóa hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHDBanData(); // Hàm load lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHDBanData()
        {
            string query = @"
            SELECT 
            HDBan.MaHDBan, 
            HDBan.NgayBan, 
            HDBan.TongTien, 
            KhachHang.TenKH 
            FROM HDBan
            JOIN KhachHang ON HDBan.MaKH = KhachHang.MaKH";

            Functions functions = new Functions();
            DataSet ds = functions.GetData(query, null);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dgvHDBanHang.DataSource = ds.Tables[0];
            }
            else
            {
                dgvHDBanHang.DataSource = null;
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHDBanHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin hóa đơn từ dòng được chọn
            string maHDBan = dgvHDBanHang.SelectedRows[0].Cells["MaHDBan"].Value.ToString();

            // Lấy chi tiết hóa đơn từ database
            printContent = GetInvoiceContent(maHDBan);

            if (string.IsNullOrEmpty(printContent))
            {
                MessageBox.Show("Không thể lấy thông tin hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cấu hình in
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Hiển thị hộp thoại xem trước in
            PrintPreviewDialog printPreview = new PrintPreviewDialog
            {
                Document = printDocument
            };
            printPreview.ShowDialog();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Định dạng phông chữ và màu sắc
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 14, FontStyle.Bold);
            Font contentFont = new Font("Arial", 12);
            Font footerFont = new Font("Arial", 10, FontStyle.Italic);
            Brush headerBrush = Brushes.DarkBlue; // Màu tiêu đề
            Brush subHeaderBrush = Brushes.DarkGreen; // Màu tổng tiền
            Brush contentBrush = Brushes.Black; // Màu nội dung
            Pen linePen = new Pen(Color.Gray, 1); // Đường kẻ mỏng

            float pageWidth = e.PageBounds.Width;
            float leftMargin = 50; // Lề trái
            float y = 50; // Khoảng cách từ trên xuống

            // 1. Vẽ tiêu đề (căn giữa)
            string[] headerLines = {
        "*************************************",
        "         PHARMACY SHOP            ",
        "    Địa chỉ: Ninh Kiều, Cần Thơ      ",
        "       SĐT: (04) 383466419           ",
        "*************************************"
    };
            foreach (string line in headerLines)
            {
                SizeF textSize = e.Graphics.MeasureString(line, headerFont);
                float x = (pageWidth - textSize.Width) / 2; // Căn giữa
                e.Graphics.DrawString(line, headerFont, headerBrush, x, y);
                y += textSize.Height; // Xuống dòng
            }

            // 2. Thêm khoảng cách trước thông tin ngày và nhân viên
            y += 20;
            string datePrinted = $"Ngày in: {DateTime.Now:dd/MM/yyyy}";
            string employeeName = "Nhân viên: " + "Nguyễn Duy Tôn"; // Bạn có thể thay đổi tên nhân viên tùy vào thông tin
            e.Graphics.DrawString(datePrinted, contentFont, contentBrush, leftMargin, y);
            y += e.Graphics.MeasureString(datePrinted, contentFont).Height + 5;
            e.Graphics.DrawString(employeeName, contentFont, contentBrush, leftMargin, y);
            y += e.Graphics.MeasureString(employeeName, contentFont).Height + 10;

            // 3. Thêm khoảng cách trước nội dung chính
            e.Graphics.DrawLine(linePen, leftMargin, y, pageWidth - leftMargin, y); // Đường kẻ ngang
            y += 10;

            // 4. Nội dung chính (căn trái với các cột thẳng hàng)
            float col1 = leftMargin; // Cột 1: Tên Thuốc
            float col2 = col1 + 200; // Cột 2: Số Lượng
            float col3 = col2 + 100; // Cột 3: Đơn Giá
            float col4 = col3 + 100; // Cột 4: Thành Tiền

            // Vẽ tiêu đề bảng
            e.Graphics.DrawString("Tên Thuốc", contentFont, contentBrush, col1, y);
            e.Graphics.DrawString("Số Lượng", contentFont, contentBrush, col2, y);
            e.Graphics.DrawString("Đơn Giá", contentFont, contentBrush, col3, y);
            e.Graphics.DrawString("Thành Tiền", contentFont, contentBrush, col4, y);
            y += e.Graphics.MeasureString("Tên Thuốc", contentFont).Height + 5;

            // Đường kẻ ngang dưới tiêu đề bảng
            e.Graphics.DrawLine(linePen, leftMargin, y, pageWidth - leftMargin, y);
            y += 10;

            // Lọc dữ liệu bảng để loại bỏ tiêu đề bị lặp
            string[] invoiceContent = printContent.Split('\n');

            // Bỏ qua tiêu đề bảng nếu đã được thêm trong `printContent`
            bool isHeaderSkipped = false;
            decimal totalAmount = 0; // Biến lưu tổng tiền

            foreach (string line in invoiceContent)
            {
                string[] parts = line.Split('\t');

                // Bỏ qua các dòng không có đủ 4 cột
                if (parts.Length != 4) continue;

                // Kiểm tra và bỏ qua tiêu đề nếu cần
                if (!isHeaderSkipped && parts[0] == "Tên Thuốc")
                {
                    isHeaderSkipped = true;
                    continue; // Bỏ qua tiêu đề trong nội dung
                }

                // Hiển thị từng dòng nội dung hóa đơn
                e.Graphics.DrawString(parts[0], contentFont, contentBrush, col1, y); // Tên Thuốc
                e.Graphics.DrawString(parts[1], contentFont, contentBrush, col2, y); // Số Lượng
                e.Graphics.DrawString(parts[2], contentFont, contentBrush, col3, y); // Đơn Giá
                e.Graphics.DrawString(parts[3], contentFont, contentBrush, col4, y); // Thành Tiền

                // Tính tổng tiền (giả sử cột thứ 4 là Thành Tiền và có thể chuyển đổi sang số)
                if (decimal.TryParse(parts[3].Replace(" VNĐ", "").Trim(), out decimal itemAmount))
                {
                    totalAmount += itemAmount; // Cộng dồn tổng tiền
                }

                y += e.Graphics.MeasureString(parts[0], contentFont).Height; // Di chuyển xuống dòng tiếp theo
            }

            // 5. Thêm khoảng cách trước tổng tiền
            y += 10;
            e.Graphics.DrawLine(linePen, leftMargin, y, pageWidth - leftMargin, y); // Đường kẻ ngang
            y += 20;

            // 6. Tổng tiền (căn phải và in đậm)
            string total = $"TỔNG TIỀN: {totalAmount:N0} VNĐ"; // Định dạng tổng tiền
            SizeF totalSize = e.Graphics.MeasureString(total, subHeaderFont);
            float totalX = pageWidth - totalSize.Width - leftMargin; // Tính vị trí căn phải
            e.Graphics.DrawString(total, subHeaderFont, subHeaderBrush, totalX, y);
            y += totalSize.Height;

            // 7. Footer (căn giữa)
            y += 30;
            string footer = "Cảm ơn Quý khách! Hẹn gặp lại!";
            SizeF footerTextSize = e.Graphics.MeasureString(footer, footerFont);
            float footerX = (pageWidth - footerTextSize.Width) / 2; // Căn giữa
            e.Graphics.DrawString(footer, footerFont, Brushes.DarkGray, footerX, y);
        }



        private string GetInvoiceContent(string maHDBan)
        {
            try
            {
                // Câu truy vấn lấy thông tin hóa đơn và chi tiết
                string query = @"
            SELECT 
                HDBan.MaHDBan, 
                HDBan.NgayBan, 
                HDBan.TongTien, 
                KhachHang.TenKH, 
                KhachHang.SDT, 
                Thuoc.TenThuoc, 
                ChiTietBan.SoLuong, 
                ChiTietBan.DonGia, 
                ChiTietBan.ThanhTien
                FROM HDBan
                JOIN KhachHang ON HDBan.MaKH = KhachHang.MaKH
                JOIN ChiTietBan ON HDBan.MaHDBan = ChiTietBan.MaHDBan
                JOIN Thuoc ON ChiTietBan.MaThuoc = Thuoc.MaThuoc
                WHERE HDBan.MaHDBan = @MaHDBan";

                SqlParameter[] parameters = {
                new SqlParameter("@MaHDBan", maHDBan)
                };

                Functions functions = new Functions();
                DataSet ds = functions.GetData(query, parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    // Xử lý dữ liệu thành chuỗi in
                    DataTable dt = ds.Tables[0];
                    string invoice = $"HÓA ĐƠN BÁN HÀNG\n";
                    invoice += $"Mã Hóa Đơn: {dt.Rows[0]["MaHDBan"]}\n";
                    invoice += $"Khách Hàng: {dt.Rows[0]["TenKH"]}\n";
                    invoice += $"Số Điện Thoại: {dt.Rows[0]["SDT"]}\n";
                    invoice += $"Ngày Bán: {dt.Rows[0]["NgayBan"]}\n";
                    invoice += $"-----------------------------------\n";
                    invoice += $"Tên Thuốc\tSố Lượng\tĐơn Giá\tThành Tiền\n";

                    foreach (DataRow row in dt.Rows)
                    {
                        string tenThuoc = row["TenThuoc"].ToString();
                        string soLuong = row["SoLuong"].ToString();
                        string donGia = row["DonGia"].ToString();
                        string thanhTien = row["ThanhTien"].ToString();
                        invoice += $"{tenThuoc}\t{soLuong}\t{donGia}\t{thanhTien}\n";
                    }

                    invoice += $"-----------------------------------\n";
                    invoice += $"Tổng Tiền: {dt.Rows[0]["TongTien"]}";

                    return invoice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private void dgvHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
