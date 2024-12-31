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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace DoAn2.UserDB
{
    public partial class US_HoaDon : UserControl
    {
        Functions fn = new Functions();
        private SqlConnection conn = new SqlConnection(@"Data Source=ASUS\ASUS;Initial Catalog=Pharmacy;Integrated Security=True");
        public US_HoaDon()
        {
            InitializeComponent();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;

/*            btnInHoaDon.Enabled = false;*/
            txtMaHoaDon.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            mtbDienThoai.ReadOnly = true;
            txtTenThuoc.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            fn.FillCombo("SELECT MaKH, TenKH FROM KhachHang", cboMaKH, "MaKH", "MaKH");
            cboMaKH.SelectedIndex = -1;
            fn.FillCombo("SELECT MaNV, TenNV FROM NhanVien", cboMaNV, "MaNV", "MaNV");
            cboMaNV.SelectedIndex = -1;
            fn.FillCombo("SELECT MaThuoc, TenThuoc FROM Thuoc", cboMaThuoc, "MaThuoc", "MaThuoc");
            cboMaThuoc.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHoaDon.Text != "")
            {
                LoadInfoHoaDon();
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();

        }

        private void US_HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void LoadDataGridView()
        {
            string sql = "SELECT HDBan.MaHDBan, HDBan.NgayBan, NhanVien.TenNV, KhachHang.TenKH, HDBan.TongTien, " +
                         "Thuoc.TenThuoc, ChiTietBan.GiamGia " +
                         "FROM HDBan " +
                         "INNER JOIN NhanVien ON HDBan.MaNV = NhanVien.MaNV " +
                         "INNER JOIN KhachHang ON HDBan.MaKH = KhachHang.MaKH " +
                         "INNER JOIN ChiTietBan ON HDBan.MaHDBan = ChiTietBan.MaHDBan " +
                         "INNER JOIN Thuoc ON ChiTietBan.MaThuoc = Thuoc.MaThuoc";

            DataTable dt = Functions.GetDataTable(sql);
            dgvHDBanHang.DataSource = dt;
            dgvHDBanHang.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHDBanHang.Columns[1].HeaderText = "Ngày Bán";
            dgvHDBanHang.Columns[2].HeaderText = "Nhân Viên";
            dgvHDBanHang.Columns[3].HeaderText = "Khách Hàng";
            dgvHDBanHang.Columns[4].HeaderText = "Đơn Giá";
            dgvHDBanHang.Columns[5].HeaderText = "Tên Thuốc";
            dgvHDBanHang.Columns[6].HeaderText = "Giảm Giá";


            // Ẩn cột nếu không cần hiển thị (nếu bạn chỉ muốn hiển thị thông tin cần thiết)
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HDBan WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'";
            dtpNgayBan.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT MaNV FROM HDBan WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'";
            cboMaNV.Text = Functions.GetFieldValues(str);
            str = "SELECT MaKH FROM HDBan WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'";
            cboMaKH.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HDBan WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongTien.Text);
        }


        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHoaDon.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }


        //napj các giá trị control vê mặc định 
        private void ResetValues()
        {
            txtMaHoaDon.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            cboMaNV.Text = "";
            cboMaKH.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaThuoc.Text = "";
            //txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void ResetValuesHang()
        {
            cboMaThuoc.Text = "";
            //txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;

            try
            {
                // Kiểm tra giá trị nhập vào có phải là số hợp lệ hay không
                if (!double.TryParse(txtTongTien.Text, out tong))
                {
                    MessageBox.Show("Tổng tiền không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra giá trị trong txtSoLuong có phải là số hợp lệ không
                int soLuong = 0;
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số nguyên lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtDonGia.Text, out double donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtGiamGia.Text, out double giamGia))
                {
                    MessageBox.Show("Giảm giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem hóa đơn đã tồn tại hay chưa
                sql = "SELECT MaHDBan FROM HDBan WHERE MaHDBan = @MaHDBan";
                SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text.Trim() }
        };

                if (!Functions.CheckKey(sql, parameters))
                {
                    // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                    if (cboMaNV.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboMaNV.Focus();
                        return;
                    }
                    if (cboMaKH.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboMaKH.Focus();
                        return;
                    }

                    // Sử dụng tham số để tránh lỗi chuyển đổi ngày tháng
                    sql = "INSERT INTO HDBan(MaHDBan, MaNV, MaKH, NgayBan, TongTien) VALUES (@MaHDBan, @MaNV, @MaKH, @NgayBan, @TongTien)";
                    SqlParameter[] insertParameters = new SqlParameter[] {
                new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text.Trim() },
                new SqlParameter("@MaNV", SqlDbType.NVarChar) { Value = cboMaNV.SelectedValue },
                new SqlParameter("@MaKH", SqlDbType.NVarChar) { Value = cboMaKH.SelectedValue },
                new SqlParameter("@NgayBan", SqlDbType.DateTime) { Value = dtpNgayBan.Value },
                new SqlParameter("@TongTien", SqlDbType.Float) { Value = tong }
            };
                    Functions.RunSQL(sql, insertParameters);
                }

                // Thêm chi tiết hàng hóa vào hóa đơn
                if (cboMaThuoc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaThuoc.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || txtSoLuong.Text == "0")
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtGiamGia.Text))
                {
                    MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGiamGia.Focus();
                    return;
                }

                // Kiểm tra số lượng hàng trong kho
                sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM Thuoc WHERE MaThuoc = N'" + cboMaThuoc.SelectedValue + "'"));
                if (soLuong > sl)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }

                // Tính thành tiền cho sản phẩm
                double thanhTien = soLuong * donGia * (1 - giamGia / 100);

                // Thêm chi tiết vào bảng ChiTietBan
                sql = "INSERT INTO ChiTietBan(MaHDBan, MaThuoc, SoLuong, DonGia, GiamGia, ThanhTien) VALUES(@MaHDBan, @MaThuoc, @SoLuong, @DonGia, @GiamGia, @ThanhTien)";
                SqlParameter[] detailParameters = new SqlParameter[] {
            new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text.Trim() },
            new SqlParameter("@MaThuoc", SqlDbType.NVarChar) { Value = cboMaThuoc.SelectedValue },
            new SqlParameter("@SoLuong", SqlDbType.Int) { Value = soLuong },
            new SqlParameter("@DonGia", SqlDbType.Float) { Value = donGia },
            new SqlParameter("@GiamGia", SqlDbType.Float) { Value = giamGia },
            new SqlParameter("@ThanhTien", SqlDbType.Float) { Value = thanhTien }
        };
                Functions.RunSQL(sql, detailParameters);

                // Cập nhật số lượng tồn kho
                SLcon = sl - soLuong;
                sql = "UPDATE Thuoc SET SoLuong = @SoLuong WHERE MaThuoc = @MaThuoc";
                SqlParameter[] updateStockParameters = new SqlParameter[] {
            new SqlParameter("@SoLuong", SqlDbType.Float) { Value = SLcon },
            new SqlParameter("@MaThuoc", SqlDbType.NVarChar) { Value = cboMaThuoc.SelectedValue }
        };
                Functions.RunSQL(sql, updateStockParameters);

                // Cập nhật tổng tiền cho hóa đơn
                Tongmoi = tong + thanhTien;
                sql = "UPDATE HDBan SET TongTien = @TongTien WHERE MaHDBan = @MaHDBan";
                SqlParameter[] updateInvoiceParameters = new SqlParameter[] {
            new SqlParameter("@TongTien", SqlDbType.Float) { Value = Tongmoi },
            new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text }
        };
                Functions.RunSQL(sql, updateInvoiceParameters);

                // Cập nhật UI
                txtTongTien.Text = Tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
                ResetValuesHang();

                btnThem.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDataGridView();
        }

        private void cboMaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaThuoc.Text == "")
            {
                txtTenThuoc.Text = "";
                txtDonGia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenThuoc FROM Thuoc WHERE MaThuoc =N'" + cboMaThuoc.SelectedValue + "'";
            txtTenThuoc.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGia FROM Thuoc WHERE MaThuoc =N'" + cboMaThuoc.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(str);

        }


        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                mtbDienThoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TenKH from KhachHang where MaKH = N'" + cboMaKH.SelectedValue + "'";
            txtTenKH.Text = Functions.GetFieldValues(str);
            str = "Select DiaChi from KhachHang where MaKH = N'" + cboMaKH.SelectedValue + "'";
            txtDiaChi.Text = Functions.GetFieldValues(str);
            str = "Select SDT from KhachHang where MaKH= N'" + cboMaKH.SelectedValue + "'";
            mtbDienThoai.Text = Functions.GetFieldValues(str);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNV.Text == "")
                txtTenNV.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select TenNV from NhanVien where MaNV =N'" + cboMaNV.SelectedValue + "'";
            txtTenNV.Text = Functions.GetFieldValues(str);
        }

        private void dgvHDBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có chọn một dòng hợp lệ hay không
            if (e.RowIndex >= 0) // e.RowIndex sẽ trả về -1 nếu không có dòng nào được chọn
            {
                // Kiểm tra xem cột có phải là cột "Mã Hóa Đơn" (thường là cột 0)
                string maHoaDon = dgvHDBanHang.Rows[e.RowIndex].Cells["MaHDBan"].Value.ToString();

                // Gán mã hóa đơn vào ô nhập liệu txtMaHoaDon (hoặc tương tự trong form của bạn)
                txtMaHoaDon.Text = maHoaDon;

                // Gọi hàm in hóa đơn
                btnInHoaDon_Click(sender, e);
            }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, donGia, giamGia, thanhTien;

            try
            {
                // Kiểm tra số lượng và giá trị hợp lệ
                if (!double.TryParse(txtSoLuong.Text, out sl))
                {
                    MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtDonGia.Text, out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtGiamGia.Text, out giamGia))
                {
                    MessageBox.Show("Giảm giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tính thành tiền
                thanhTien = sl * donGia - sl * donGia * giamGia / 100;
                txtThanhTien.Text = thanhTien.ToString();

                // Kiểm tra xem thuốc đã có trong chi tiết hóa đơn chưa
                sql = "SELECT MaThuoc FROM ChiTietBan WHERE MaThuoc = @MaThuoc AND MaHDBan = @MaHDBan";
                SqlParameter[] checkItemParameters = new SqlParameter[] {
        new SqlParameter("@MaThuoc", SqlDbType.NVarChar) { Value = cboMaThuoc.SelectedValue },
        new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text.Trim() }
    };

                if (Functions.CheckKey(sql, checkItemParameters))
                {
                    MessageBox.Show("Mã hàng này đã có trong hóa đơn, bạn phải nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValuesHang();
                    cboMaThuoc.Focus();
                    return;
                }

                // Kiểm tra số lượng hàng trong kho
                double slKho = 0;
                string sqlKho = "SELECT SoLuong FROM Thuoc WHERE MaThuoc = N'" + cboMaThuoc.SelectedValue + "'";
                object result = Functions.GetFieldValues(sqlKho);

                if (result != null && double.TryParse(result.ToString(), out slKho))
                {
                    if (sl > slKho)
                    {
                        MessageBox.Show("Số lượng trong kho không đủ. Chỉ còn " + slKho, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSoLuong.Text = "";
                        txtSoLuong.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin thuốc trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm chi tiết hàng hóa vào hóa đơn
                sql = "INSERT INTO ChiTietBan(MaHDBan, MaThuoc, SoLuong, DonGia, GiamGia, ThanhTien) VALUES(@MaHDBan, @MaThuoc, @SoLuong, @DonGia, @GiamGia, @ThanhTien)";
                        SqlParameter[] detailParameters = new SqlParameter[] {
                new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text.Trim() },
                new SqlParameter("@MaThuoc", SqlDbType.NVarChar) { Value = cboMaThuoc.SelectedValue },
                new SqlParameter("@SoLuong", SqlDbType.Int) { Value = sl },
                new SqlParameter("@DonGia", SqlDbType.Float) { Value = donGia },
                new SqlParameter("@GiamGia", SqlDbType.Float) { Value = giamGia },
                new SqlParameter("@ThanhTien", SqlDbType.Float) { Value = thanhTien }
                          };
                Functions.RunSQL(sql, detailParameters);

                // Cập nhật lại số lượng tồn kho
                double slCon = slKho - sl;
                sql = "UPDATE Thuoc SET SoLuong = @SoLuong WHERE MaThuoc = @MaThuoc";
                SqlParameter[] updateStockParameters = new SqlParameter[] {
        new SqlParameter("@SoLuong", SqlDbType.Float) { Value = slCon },
        new SqlParameter("@MaThuoc", SqlDbType.NVarChar) { Value = cboMaThuoc.SelectedValue }
    };
                Functions.RunSQL(sql, updateStockParameters);

                // Cập nhật tổng tiền cho hóa đơn
                double tongTien = Convert.ToDouble(txtTongTien.Text) + thanhTien;
                sql = "UPDATE HDBan SET TongTien = @TongTien WHERE MaHDBan = @MaHDBan";
                SqlParameter[] updateInvoiceParameters = new SqlParameter[] {
        new SqlParameter("@TongTien", SqlDbType.Float) { Value = tongTien },
        new SqlParameter("@MaHDBan", SqlDbType.NVarChar) { Value = txtMaHoaDon.Text }
    };
                Functions.RunSQL(sql, updateInvoiceParameters);

                // Cập nhật lại giao diện
                txtTongTien.Text = tongTien.ToString();
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tongTien.ToString());
                ResetValuesHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message + "\n" + ex.StackTrace, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDataGridView();
        }

            private void btnInHoaDon_Click(object sender, EventArgs e)
            {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook;
                COMExcel.Worksheet exSheet;
                COMExcel.Range exRange;
                string sql;
                int hang = 0; /*cot = 0;*/
                DataTable tblThongtinHD, tblThongtinHang;

                // Tạo mới workbook và worksheet
                exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
                exSheet = exBook.Worksheets[1];

                // Định dạng chung
                exRange = exSheet.Cells[1, 1];
                exRange.Range["A1:Z300"].Font.Name = "Times New Roman"; //Font chữ
                exRange.Range["A1:B3"].Font.Size = 10;
                exRange.Range["A1:B3"].Font.Bold = true;
                exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời

                // Định dạng các ô trong header
                exRange.Range["A1:A1"].ColumnWidth = 7;
                exRange.Range["B1:B1"].ColumnWidth = 15;
                exRange.Range["A1:B1"].MergeCells = true;
                exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:B1"].Value = "Pharmacy";
                exRange.Range["A2:B2"].MergeCells = true;
                exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A2:B2"].Value = "Ninh Kiều - Cần Thơ";
                exRange.Range["A3:B3"].MergeCells = true;
                exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A3:B3"].Value = "Điện thoại: (04)383466419";

                // Định dạng tiêu đề "HÓA ĐƠN BÁN"
                exRange.Range["C2:E2"].Font.Size = 16;
                exRange.Range["C2:E2"].Font.Bold = true;
                exRange.Range["C2:E2"].Font.ColorIndex = 3; // Màu đỏ
                exRange.Range["C2:E2"].MergeCells = true;
                exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN THUỐC";

                // Thay đổi chiều rộng của cột C, D, E
                exRange.Range["C2:E2"].ColumnWidth = 20; // Điều chỉnh số này để thay đổi chiều rộng theo ý muốn


                // Truy vấn thông tin chung của hóa đơn bán
                sql = "SELECT a.MaHDBan, a.NgayBan, a.TongTien, b.TenKH, b.DiaChi, b.SDT, c.TenNV " +
                      "FROM HDBan AS a " +
                      "INNER JOIN KhachHang AS b ON a.MaKH = b.MaKH " +
                      "INNER JOIN NhanVien AS c ON a.MaNV = c.MaNV " +
                      "WHERE a.MaHDBan = N'" + txtMaHoaDon.Text + "'";
                tblThongtinHD = Functions.GetDataTable(sql);

                // Điền thông tin hóa đơn vào Excel
                exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
                exRange.Range["C6:E6"].MergeCells = true;
                exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();

                exRange.Range["B7:B7"].Value = "Khách hàng:";
                exRange.Range["C7:E7"].MergeCells = true;
                exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();

                exRange.Range["B8:B8"].Value = "Địa chỉ:";
                exRange.Range["C8:E8"].MergeCells = true;
                exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();

                exRange.Range["B9:B9"].Value = "Điện thoại:";
                exRange.Range["C9:E9"].MergeCells = true;
                exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
          
                // Truy vấn thông tin chi tiết các mặt hàng
                sql = "SELECT Thuoc.TenThuoc, ChiTietBan.Soluong, ChiTietBan.DonGia, ChiTietBan.GiamGia, ChiTietBan.ThanhTien " +
                      "FROM ChiTietBan " +
                      "INNER JOIN Thuoc ON ChiTietBan.MaThuoc = Thuoc.MaThuoc " +
                      "WHERE ChiTietBan.MaHDBan = N'" + txtMaHoaDon.Text + "'";
                tblThongtinHang = Functions.GetDataTable(sql);

                // Tạo tiêu đề bảng cho các mặt hàng
                exRange.Range["B11"].Value = "STT";
                exRange.Range["C11"].Value = "Tên thuốc";
                exRange.Range["D11"].Value = "Số lượng";
                exRange.Range["E11"].Value = "Đơn giá";
                exRange.Range["F11"].Value = "Giảm giá";
                exRange.Range["G11"].Value = "Thành tiền";

                string soLuongText = txtSoLuong.Text.Trim();
                soLuongText = soLuongText.Replace(",", ""); // Loại bỏ dấu phân cách nghìn

                int soLuong;
                bool isValid = int.TryParse(soLuongText, out soLuong);

                if (!isValid)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu số lượng không hợp lệ
                }

                MessageBox.Show("In thành công nha chế!!!: " + soLuong.ToString(),
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);

                // Điền thông tin mặt hàng vào Excel
                for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
                {       
                    // Điền các giá trị vào bảng, bắt đầu từ dòng 12 (Dòng tiêu đề là 11)
                    exSheet.Cells[hang + 12, 2].Value = hang + 1;  // STT
                    exSheet.Cells[hang + 12, 3].Value = tblThongtinHang.Rows[hang]["TenThuoc"].ToString();  // Tên thuốc
                    exSheet.Cells[hang + 12, 4].Value = soLuong.ToString();  // Số lượng từ txtSoLuong
                    exSheet.Cells[hang + 12, 5].Value = Convert.ToDecimal(tblThongtinHang.Rows[hang]["DonGia"]).ToString("N0");  // Đơn giá
                    exSheet.Cells[hang + 12, 6].Value = Convert.ToDecimal(tblThongtinHang.Rows[hang]["GiamGia"]).ToString("N0");  // Giảm giá
                    exSheet.Cells[hang + 12, 7].Value = Convert.ToDecimal(tblThongtinHang.Rows[hang]["ThanhTien"]).ToString("N0");  // Thành tiền
                }

                // Tổng tiền
                exRange = exSheet.Cells[hang + 13, 6];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[hang + 13, 7];
                exRange.Font.Bold = true;
                exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();

                // Chuyển số thành chữ
                exRange = exSheet.Cells[hang + 14, 1];
                exRange.Range["A1:F1"].MergeCells = true;
                exRange.Range["A1:F1"].Font.Bold = true;
                exRange.Range["A1:F1"].Font.Italic = true;
                exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
              //  exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());

                // Ngày tháng
                DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
                exRange = exSheet.Cells[hang + 15, 1];
                exRange.Range["A1:C1"].MergeCells = true;
                exRange.Range["A1:C1"].Font.Italic = true;
                exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:C1"].Value = "Cần Thơ, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

                // Nhân viên bán hàng
                exRange.Range["A16:C16"].MergeCells = true;
                exRange.Range["A16:C16"].Font.Italic = true;
                exRange.Range["A16:C16"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A16:C16"].Value = "Nhân viên bán hàng: " + tblThongtinHD.Rows[0][6].ToString();

                // Hiển thị Excel
                exApp.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchQuery = txtTimKiem.Text.Trim();  // Lấy giá trị từ ô tìm kiếm

            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Câu truy vấn tìm kiếm với tham số
            string query = @"
            SELECT 
            HDBan.MaHDBan, 
            HDBan.NgayBan, 
            HDBan.TongTien, 
            KhachHang.TenKH, 
            Thuoc.TenThuoc, 
            ChiTietBan.SoLuong, 
            ChiTietBan.DonGia, 
            ChiTietBan.GiamGia, 
            ChiTietBan.ThanhTien
            FROM HDBan
            JOIN KhachHang ON HDBan.MaKH = KhachHang.MaKH
            JOIN ChiTietBan ON HDBan.MaHDBan = ChiTietBan.MaHDBan
            JOIN Thuoc ON ChiTietBan.MaThuoc = Thuoc.MaThuoc
            WHERE KhachHang.TenKH LIKE @searchQuery";

            // Thêm tham số vào truy vấn
            SqlParameter[] parameters = {
        new SqlParameter("@searchQuery", "%" + searchQuery + "%")
    };

            // Gọi hàm GetData với tham số
            Functions functions = new Functions();
            DataSet ds = functions.GetData(query, parameters);

            // Kiểm tra xem có dữ liệu trả về không
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dgvHDBanHang.DataSource = ds.Tables[0];  // Gán dữ liệu cho DataGridView
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào khớp với yêu cầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHDBanHang.DataSource = null;  // Nếu không có kết quả, xóa dữ liệu cũ trong DataGridView
            }
        }

        private void LoadCboMaThuoc()
        {
            // Truy vấn dữ liệu từ bảng Thuoc
            DataSet dsThuoc = fn.GetData("SELECT MaThuoc, TenThuoc FROM Thuoc");

            // Đặt dữ liệu cho ComboBox
            cboMaThuoc.DataSource = dsThuoc.Tables[0];
            cboMaThuoc.DisplayMember = "TenThuoc"; // Hiển thị tên thuốc
            cboMaThuoc.ValueMember = "MaThuoc";   // Giá trị là mã thuốc
        }

        private void LoadCboKhachHang()
        {
            // Truy vấn dữ liệu từ bảng Thuoc
            DataSet dsKhachHang = fn.GetData("SELECT MaKH, TenKH FROM KhachHang");

            // Đặt dữ liệu cho ComboBox
            cboMaKH.DataSource = dsKhachHang.Tables[0];
            cboMaKH.DisplayMember = "MaKH"; // Hiển thị tên thuốc

        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            LoadCboKhachHang();
            LoadCboMaThuoc();
            MessageBox.Show("Đã tải lại dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}   

