using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DoAn2
{
    internal class Functions
    {
        // Kết nối đến cơ sở dữ liệu
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=ASUS\ASUS;Initial Catalog=Pharmacy;Integrated Security=True");
        }
        public object GetSingleValue(string query)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return cmd.ExecuteScalar(); // Lấy giá trị đầu tiên trong kết quả
            }
        }

        public void ExecuteQuery(string query, SqlParameter[] parameters) //dùng cho các câu lệnh như INSERT, UPDATE, DELETE
        {
            using (SqlConnection connection = Functions.GetSqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null) //Kiểm tra xem có tham số nào được truyền vào không.
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();//Thực thi câu lệnh mà không trả về kết quả (dùng cho các câu lệnh thay đổi dữ liệu như INSERT, UPDATE, DELETE).
                }
            }
        }



        // Lấy dữ liệu từ cơ sở dữ liệu với tham số
        public DataSet GetData(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);//Tạo một đối tượng SqlDataAdapter để thực thi câu lệnh SQL và lấy dữ liệu.
                    DataSet ds = new DataSet();//Tạo một đối tượng DataSet để lưu trữ dữ liệu.

                    try
                    {
                        con.Open();
                        da.Fill(ds);// Đổ dữ liệu từ cơ sở dữ liệu vào DataSet.
                    }
                    catch (Exception ex) // Bắt lỗi nếu có lỗi xảy ra trong quá trình truy vấn dữ liệu và hiển thị thông báo lỗi.
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return ds;// Trả về DataSet chứa dữ liệu truy vấn.
                }
            }
        }

        public static DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = GetSqlConnection()) // Sửa cách gọi GetSqlConnection
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Thực hiện truy vấn không trả về kết quả
        public void SetData(string query, string msg)
        {
            using (SqlConnection con = GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // sử dụng để thêm, cập nhật, hoặc xóa dữ liệu trong cơ sở dữ liệu mà không trả về kết quả.
        public void SetDataWithParams(string query, SqlParameter[] parameters, string successMessage)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                cmd.ExecuteNonQuery();//Thực thi truy vấn mà không trả về dữ liệu.
                MessageBox.Show(successMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public DataSet GetDataWithParams(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);//Thêm các tham số vào truy vấn
                }
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                return ds;
            }
        }

        public static void RunSQL(string sql, params SqlParameter[] parameters)
        {
            try
            {
                // Sử dụng 'using' để đảm bảo tài nguyên được giải phóng
                using (SqlConnection con = GetSqlConnection())
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void RunSQL1(string query, SqlParameter[] parameters)
        {
            // Tạo kết nối với cơ sở dữ liệu
          //  string connectionString = @"Data Source=ASUS\ASUS;Initial Catalog=Pharmacy;Integrated Security=True"; // Đảm bảo thay thế với chuỗi kết nối của bạn
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters); // Thêm các tham số vào câu lệnh SQL

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery(); // Thực thi câu lệnh SQL
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string CreateMaHD()
        {
            DateTime now = DateTime.Now;  // Lấy thời gian hiện tại
            string maHD ="HD" + now.ToString("yyyyMMddHHmmss");  // Định dạng: yyyyMMddHHmmss (Năm tháng ngày giờ phút giây)
            return maHD;
        }

        public string GenerateMaNCC()
        {
            // Logic để sinh mã nhà cung cấp mới (ví dụ: NCC001, NCC002, ...)
            string prefix = "NCC";
            int nextNumber = GetNextNCCNumber();
            return $"{prefix}{nextNumber:D3}"; // Đảm bảo rằng mã có 3 chữ số
        }
        public string GenerateMaKH()
        {
          
                // Truy vấn để lấy mã khách hàng lớn nhất hiện tại
                string query = "SELECT MAX(MaKH) FROM KhachHang";
                object result = ExecuteScalar(query);

                // Nếu chưa có khách hàng nào trong DB, bắt đầu với mã KH001
                if (result == DBNull.Value)
                {
                    return "KH001";
                }

                // Lấy giá trị mã khách hàng cuối cùng và tăng lên 1
                string maxMaKH = result.ToString();
                int numericPart = int.Parse(maxMaKH.Substring(2)); // Lấy phần số sau "KH"
                numericPart++; // Tăng phần số lên 1
                return "KH" + numericPart.ToString("D3"); // Format lại thành KH001, KH002, etc.          
        }
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;//Khởi tạo một biến result để lưu trữ giá trị trả về từ truy vấn.
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Thêm các tham số nếu có
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                conn.Open();
                result = command.ExecuteScalar();
            }
            return result;//Trả về giá trị lấy được.
        }

        private int GetNextNCCNumber()
        {
            string query = "SELECT COUNT(*) FROM NhaCungCap";
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return (int)cmd.ExecuteScalar() + 1; // Số lượng hiện tại + 1
            }
        }


        public void FillCombo(string query, ComboBox cbo, string valueMember, string displayMember, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetSqlConnection())  // Mở kết nối
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);  // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);  // Nếu có tham số, thêm vào lệnh
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);  // Tạo SqlDataAdapter từ lệnh SqlCommand
                    DataTable table = new DataTable();  // Khởi tạo DataTable để chứa kết quả truy vấn
                    conn.Open();  // Mở kết nối đến cơ sở dữ liệu
                    da.Fill(table);  // Điền dữ liệu vào DataTable

                    cbo.DataSource = table;  // Đặt nguồn dữ liệu cho ComboBox
                    cbo.ValueMember = valueMember;  // Gán ValueMember
                    cbo.DisplayMember = displayMember;  // Gán DisplayMember
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi điền dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool CheckKey(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ASUS\ASUS;Initial Catalog=Pharmacy;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Trả về true nếu tìm thấy bản ghi
                }
            }
        }

        public static string GetFieldValues(string sql, params SqlParameter[] parameters)
        {
            string value = "";
            try
            {
                using (SqlConnection conn = GetSqlConnection()) // Đảm bảo GetSqlConnection được định nghĩa đúng
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Thêm các tham số truy vấn
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())//Di chuyển con trỏ tới dòng dữ liệu đầu tiên.
                            // Nếu có dữ liệu, thực hiện các thao tác đọc.
                        {
                            value = reader[0]?.ToString(); // Lấy giá trị cột đầu tiên nếu có, sử dụng toán tử ? tránh giá trị null
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá trị trường: " + ex.Message);
            }
            return value;//Trả về giá trị đã lấy được dưới dạng chuỗi.
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            if (string.IsNullOrEmpty(sNumber))
            {
                return "Không đồng";
            }

            sNumber = sNumber.Replace(",", "").Trim();

            if (!long.TryParse(sNumber, out long number) || number == 0) //Sử dụng TryParse để chuyển đổi chuỗi thành số kiểu long
            {
                return "Không đồng";//Nếu không chuyển đổi được hoặc số là 0, trả về "Không đồng".
            }

            string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');//Mảng các số từ 0 đến 9 dưới dạng chữ.
            string[] units = { "", " nghìn", " triệu", " tỷ" };//Các đơn vị tiền tệ tương ứng với từng nhóm 3 chữ số (đơn vị, nghìn, triệu, tỷ).

            string result = "";
            int unitIndex = 0; //Chỉ số xác định đơn vị tương ứng (nghìn, triệu...).

            while (sNumber.Length > 0)
            {
                int end = sNumber.Length;
                int start = end - 3 >= 0 ? end - 3 : 0;
                string part = sNumber.Substring(start, end - start);
                sNumber = sNumber.Substring(0, start);

                string partText = ConvertThreeDigits(part, mNumText);
                if (!string.IsNullOrEmpty(partText))
                {
                    result = partText + units[unitIndex] + " " + result;
                }

                unitIndex++;
            }

            result = result.Trim();
            result = result.Replace("mươi một", "mươi mốt");
            result = result.Replace("mươi bốn", "mươi tư");
            result = result.Replace("linh bốn", "linh tư");
            result = result.Replace("mươi năm", "mươi lăm");
            result = result.Replace("mười năm", "mười lăm");

            result = char.ToUpper(result[0]) + result.Substring(1) + " đồng";

            return result;
        }

        private static string ConvertThreeDigits(string sNumber, string[] mNumText)
        {
            int length = sNumber.Length;
            string result = "";

            if (length == 3)
            {
                int hundreds = int.Parse(sNumber[0].ToString());
                if (hundreds != 0)
                {
                    result += mNumText[hundreds] + " trăm";
                }
                else
                {
                    result += "không trăm";
                }

                sNumber = sNumber.Substring(1);
                length--;
            }

            if (length == 2)
            {
                int tens = int.Parse(sNumber[0].ToString());
                if (tens != 0)
                {
                    result += " " + mNumText[tens] + " mươi";
                }
                else
                {
                    result += " linh";
                }

                sNumber = sNumber.Substring(1);
                length--;
            }

            if (length == 1)
            {
                int ones = int.Parse(sNumber[0].ToString());
                result += " " + mNumText[ones];
            }

            result = result.Replace("không trăm linh", "").Replace("không trăm", "").Trim();

            return result;
        }
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        // Chuyển đổi từ PM sang dạng 24h
        public static string ConvertTimeTo24(string hour)
        {
            /*  if (int.TryParse(hour, out int h) && h >= 1 && h <= 12)
              {
                  return (h + 12).ToString("00");
              }

              return hour;*/
            //Chuyển đổi từ PM sang dạng 24h
      
                string h = "";
                switch (hour)
                {
                    case "1":
                        h = "13";
                        break;
                    case "2":
                        h = "14";
                        break;
                    case "3":
                        h = "15";
                        break;
                    case "4":
                        h = "16";
                        break;
                    case "5":
                        h = "17";
                        break;
                    case "6":
                        h = "18";
                        break;
                    case "7":
                        h = "19";
                        break;
                    case "8":
                        h = "20";
                        break;
                    case "9":
                        h = "21";
                        break;
                    case "10":
                        h = "22";
                        break;
                    case "11":
                        h = "23";
                        break;
                    case "12":
                        h = "0";
                        break;
                }
                return h;            
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=ASUS\ASUS;Initial Catalog=Pharmacy;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        // Thực thi lệnh SQL và trả về số dòng bị ảnh hưởng
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc hiển thị thông báo
                    throw new Exception($"Lỗi khi thực thi SQL: {ex.Message}");
                }
            }
        }
      

        // Hàm chuyển số nguyên thành chữ (ví dụ: 123 -> "một trăm hai mươi ba")
        public static string ConvertToWords(int number)
        {
            string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] tens = { "", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
            string[] hundreds = { "", "một trăm", "hai trăm", "ba trăm", "bốn trăm", "năm trăm", "sáu trăm", "bảy trăm", "tám trăm", "chín trăm" };

            if (number == 0)
                return "Không";

            string result = "";

            // Phân tích từng phần (hàng trăm, hàng chục, hàng đơn vị)
            if (number / 100 > 0)
            {
                result += hundreds[number / 100] + " ";
                number %= 100;
            }

            if (number / 10 > 0)
            {
                result += tens[number / 10] + " ";
                number %= 10;
            }

            if (number > 0)
            {
                result += units[number] + " ";
            }

            return result.Trim();
        }

    }
}
