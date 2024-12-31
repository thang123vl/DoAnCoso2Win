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

namespace DoAn2.UserDB
{
    public partial class US_ThongKe : UserControl
    {
        Functions fn = new Functions();
        public US_ThongKe()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

           
        }

        private void btnThongKeNV_Click(object sender, EventArgs e)
        {
          
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void doanhThuThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonHoa mN_HoaDon = new frmDonHoa();
            mN_HoaDon.Show();
        }

        private void lblSoHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
