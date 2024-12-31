using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2.AdminDB
{
    public partial class UC_DasbBord : UserControl
    {
        Functions fn = new Functions();
        String query;
        DataSet ds;
        public UC_DasbBord()
        {
            InitializeComponent();
        }

        private void UC_DasbBord_Load(object sender, EventArgs e)
        {
            query = "Select count (UserRole) from TaiKhoan where UserRole ='Admin'";
            ds = fn.GetData(query);
            setlabel(ds, lblAdmin); //dem admin co bao nhieu + setlabel

            query = "Select count (UserRole) from TaiKhoan where UserRole ='User'";
            ds = fn.GetData(query);
            setlabel(ds, lblUser);//dem user co bao nhieu + setlabel

        }

        private void setlabel(DataSet ds, Label lbl)
        {
            if (ds.Tables[0].Rows.Count !=  0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                lbl.Text = "0";
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_DasbBord_Load(this, null);//load lai bang DashBord
        }
    }
}
