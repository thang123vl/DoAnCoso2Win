using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2.UserDB
{
    public partial class US_Dashbord : UserControl
    {
        public US_Dashbord()
        {
            InitializeComponent();

        }

        private void US_Dashbord_Load(object sender, EventArgs e)
        {

  /*          // Cấu hình Timer để di chuyển label
            timerLabelMove.Interval = 10; // Mỗi 20ms cập nhật vị trí một lần
            timerLabelMove.Tick += TimerLabelMove_Tick; // Gán sự kiện Tick
            timerLabelMove.Start(); // Bắt đầu Timer*/

        }
        private void TimerLabelMove_Tick(object sender, EventArgs e)
        {
/*            // Di chuyển label từ trái qua phải
            lblChayNgang.Left += labelSpeed;

            // Kiểm tra nếu label vượt qua biên form, thì di chuyển lại về bên trái
            if (lblChayNgang.Left > maxX)
            {
                lblChayNgang.Left = -lblChayNgang.Width; // Di chuyển label về bên trái ngoài cùng
            }*/
        }
       // private Timer timerLabelMove = new Timer(); // Khai báo Timer
/*
        private int labelSpeed = 1; // Tốc độ di chuyển của label
        private int maxX = 1000; // Vị trí tối đa của label (khi label chạy hết chiều ngang của form)*/
        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {         
                // Thiết lập đường dẫn video
                axWindowsMediaPlayer1.URL = @"D:\DoAn2\DoAn2\Image\Mua thuốc thời 4.0 cùng Pharmacity - Nhà Thuốc Pharmacity (1080p, h264, youtube).mp4";

                // Tùy chọn tự động phát
                axWindowsMediaPlayer1.settings.autoStart = true;

                // Ẩn giao diện điều khiển nếu cần
                axWindowsMediaPlayer1.uiMode = "none";

                // Tắt âm thanh
                axWindowsMediaPlayer1.settings.volume = 0;

                // Lặp lại video
                axWindowsMediaPlayer1.settings.setMode("loop", true);        
        }
    }
}
