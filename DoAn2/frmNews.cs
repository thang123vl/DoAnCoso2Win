using System;
using System.Windows.Forms;
using OpenQA.Selenium;//điều khiển trình duyệt và thực hiện các thao tác tự động hóa.
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;//xử lý bất đồng bộ, tải trang web trong Selenium mà không làm chậm ứng dụng của bạn.
using System.Collections.Generic;


namespace DoAn2
{
    public partial class frmNews : Form
    {
        public frmNews()
        {
            InitializeComponent();
        }


        // Phương thức cấu hình ChromeOptions an toàn và linh hoạt
        private ChromeOptions ConfigureChromeOptions()
        {
            var chromeOptions = new ChromeOptions(); //dùng để cấu hình các tùy chọn cho trình duyệt Chrome khi khởi tạo WebDriver.

            // Các tùy chọn an toàn và nâng cao
            chromeOptions.AddArgument("--headless"); // Chế độ không giao diện, cho phép trình duyệt chạy mà không cần giao diện đồ họa (UI)
            chromeOptions.AddArgument("--no-sandbox"); // Tránh lỗi sandbox, giúp ngăn chặn các quy trình độc hại.
            chromeOptions.AddArgument("--disable-dev-shm-usage"); // Giảm thiểu sự cố bộ nhớ

            // Bỏ qua các lỗi chứng chỉ SSL
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--allow-insecure-localhost");
            chromeOptions.AddArgument("--disable-web-security");//vô hiệu hóa một số tính năng bảo mật trong Chrome.

            // Cài đặt proxy nếu cần thiết
            // chromeOptions.Proxy = new Proxy(); 

            return chromeOptions;
        }


        [Obsolete]
        public void GetProductsFromMedshop(string url, DataGridView dgvProducts)
        {
            try
            {
                // Cấu hình ChromeOptions chi tiết hơn
                var chromeOptions = new ChromeOptions();
   /*             chromeOptions.AddArgument("--headless");*/
                chromeOptions.AddArgument("--disable-gpu");
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--ignore-certificate-errors");

                // Thêm các header để giảm khả năng bị chặn
                chromeOptions.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;// giúp ẩn cửa sổ command prompt khi chạy trình duyệt Chrome.

                using (IWebDriver driver = new ChromeDriver(driverService, chromeOptions))
                {
                    // Tăng thời gian chờ
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                    try
                    {
                        driver.Navigate().GoToUrl(url);
                    }
                    catch (Exception navEx)
                    {
                        MessageBox.Show($"Lỗi điều hướng: {navEx.Message}");
                        return;
                    }

                    // Thử các selector khác nhau
                    string[] selectors = new string[] {
                        "div.product-item",
                        ".product-item",
                        "div[class*='product']",
                        "//div[contains(@class, 'product')]"
                    };

                    IReadOnlyCollection<IWebElement> productElements = null;

                    foreach (var selector in selectors)
                    {
                        try
                        {
                            if (selector.StartsWith("//"))
                            {
                                // Nếu là XPath
                                productElements = driver.FindElements(By.XPath(selector));
                            }
                            else
                            {
                                // Nếu là CSS Selector
                                productElements = driver.FindElements(By.CssSelector(selector));
                            }

                            if (productElements != null && productElements.Count > 0)
                            {
                                break;
                            }
                        }
                        catch { }
                    }

                    // Xóa dữ liệu cũ
                    dgvProducts.Invoke((MethodInvoker)delegate
                    {
                        dgvProducts.Rows.Clear();
                    });

                    // Xử lý từng sản phẩm
                    foreach (var product in productElements)
                    {
                        try
                        {
                            // Thử các selector khác nhau cho tên sản phẩm
                            var nameElement = FindElementSafely(product, new string[] {
                                "h3.product-name > a",
                                ".product-name a",
                                "a.product-title",
                                "//a[contains(@class, 'product-name')]"
                            });

                            if (nameElement == null) continue;

                            string name = nameElement.Text.Trim();
                            string link = nameElement.GetAttribute("href");

                            // Thử các selector khác nhau cho giá
                            var priceElement = FindElementSafely(product, new string[] {
                                "div.product-price > strong",
                                ".price",
                                "span.product-price",
                                "//span[contains(@class, 'price')]"
                            });

                            string price = priceElement != null ? priceElement.Text.Trim() : "Không xác định";

                            // Thêm vào DataGridView
                            dgvProducts.Invoke((MethodInvoker)delegate
                            {
                                dgvProducts.Rows.Add(name, price, link);
                            });
                        }
                        catch (Exception productEx)
                        {
                            Console.WriteLine($"Lỗi xử lý sản phẩm: {productEx.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn: {ex.Message}");
            }
        }

        // Phương thức hỗ trợ tìm phần tử an toàn
        private IWebElement FindElementSafely(IWebElement parent, string[] selectors)
        {
            foreach (var selector in selectors)
            {
                try
                {
                    IWebElement element;
                    if (selector.StartsWith("//"))
                    {
                        element = parent.FindElement(By.XPath(selector));
                    }
                    else
                    {
                        element = parent.FindElement(By.CssSelector(selector));
                    }
                    return element;
                }
                catch { }
            }
            return null;
        }

        private async void frmNews_Load(object sender, EventArgs e)
        { // Kiểm tra và đảm bảo WebView2 đã được khởi tạo
            if (webViewNews.CoreWebView2 == null)
            {
                await webViewNews.EnsureCoreWebView2Async();
            }

            // Cấu hình WebView2, nếu cần
            webViewNews.CoreWebView2.Settings.IsScriptEnabled = true; // Bật JavaScript
            webViewNews.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true; // Bật menu mặc định (nếu muốn)
            webViewNews.CoreWebView2.Settings.IsWebMessageEnabled = true; // Bật tính năng WebMessage (nếu cần)

            // Hiển thị một trang web mặc định nếu cần
            webViewNews.CoreWebView2.Navigate("https://www.medshop.vn");
        }

        [Obsolete]
        private void btnGetNews_Click(object sender, EventArgs e)
        {
            // URL mặc định (nên để người dùng nhập)
            string url = "https://www.medshop.vn";

            // Chạy trên luồng riêng để không chặn giao diện
            Task.Run(() =>
            {
                GetProductsFromMedshop(url, dgvProducts);
            });
        }
        private async void dgvNews_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra dòng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                // Lấy liên kết từ cột thứ 3 (index 2)
                var linkCell = dgvProducts.Rows[e.RowIndex].Cells[2];

                if (linkCell.Value != null)
                {
                    string link = linkCell.Value.ToString();

                    // Đảm bảo WebView2 đã được khởi tạo
                    if (webViewNews.CoreWebView2 == null)
                    {
                        await webViewNews.EnsureCoreWebView2Async();
                    }

                    // Điều hướng đến liên kết
                    webViewNews.CoreWebView2.Navigate(link);
                }
            }
        }
    }
}
