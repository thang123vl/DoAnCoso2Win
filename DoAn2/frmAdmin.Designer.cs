namespace DoAn2
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bảngĐiềuKhiểnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse4 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse5 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse6 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse7 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse8 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.uS_XemThuoc1 = new DoAn2.UserDB.US_XemThuoc();
            this.uS_AddThuoc1 = new DoAn2.UserDB.US_AddThuoc();
            this.uC_ViewUser1 = new DoAn2.AdminDB.UC_ViewUser();
            this.uC_HoaDon1 = new DoAn2.AdminDB.UC_HoaDon();
            this.uC_DasbBord1 = new DoAn2.AdminDB.UC_DasbBord();
            this.uC_AddUser1 = new DoAn2.AdminDB.UC_AddUser();
            this.uC_XemNV1 = new DoAn2.AdminDB.UC_XemNV();
            this.uC_AddUser2 = new DoAn2.AdminDB.UC_AddUser();
            this.uS_NhaCungCap1 = new DoAn2.UserDB.US_NhaCungCap();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-4, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 915);
            this.panel1.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblUserName.Location = new System.Drawing.Point(84, 851);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(147, 40);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Animated = true;
            this.btnLogOut.AutoRoundedCorners = true;
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BorderRadius = 21;
            this.btnLogOut.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.btnLogOut.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.SystemColors.GrayText;
            this.btnLogOut.Font = new System.Drawing.Font("Century", 12F);
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.HoverState.FillColor = System.Drawing.Color.White;
            this.btnLogOut.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogOut.IndicateFocus = true;
            this.btnLogOut.Location = new System.Drawing.Point(3, 846);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogOut.PressedDepth = 50;
            this.btnLogOut.Size = new System.Drawing.Size(82, 45);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.UseTransparentBackground = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.Color.White;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(66, 190);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(130, 41);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this.panel1;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.TargetControl = this.panel2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uS_NhaCungCap1);
            this.panel2.Controls.Add(this.uS_XemThuoc1);
            this.panel2.Controls.Add(this.uS_AddThuoc1);
            this.panel2.Controls.Add(this.uC_ViewUser1);
            this.panel2.Controls.Add(this.uC_HoaDon1);
            this.panel2.Controls.Add(this.uC_DasbBord1);
            this.panel2.Controls.Add(this.uC_AddUser1);
            this.panel2.Controls.Add(this.uC_XemNV1);
            this.panel2.Controls.Add(this.uC_AddUser2);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(230, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 916);
            this.panel2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bảngĐiềuKhiểnToolStripMenuItem,
            this.thêmNgườiDùngToolStripMenuItem,
            this.traCứuToolStripMenuItem,
            this.thoátToolStripMenuItem,
            this.cungCấpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1178, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bảngĐiềuKhiểnToolStripMenuItem
            // 
            this.bảngĐiềuKhiểnToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bảngĐiềuKhiểnToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bảngĐiềuKhiểnToolStripMenuItem.Name = "bảngĐiềuKhiểnToolStripMenuItem";
            this.bảngĐiềuKhiểnToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.bảngĐiềuKhiểnToolStripMenuItem.Text = "Bảng điều khiển";
            this.bảngĐiềuKhiểnToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bảngĐiềuKhiểnToolStripMenuItem.Click += new System.EventHandler(this.bảngĐiềuKhiểnToolStripMenuItem_Click);
            // 
            // thêmNgườiDùngToolStripMenuItem
            // 
            this.thêmNgườiDùngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemNgườiDùngToolStripMenuItem,
            this.thêmNhânViênToolStripMenuItem,
            this.thêmTàiKhoảnToolStripMenuItem});
            this.thêmNgườiDùngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thêmNgườiDùngToolStripMenuItem.Name = "thêmNgườiDùngToolStripMenuItem";
            this.thêmNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.thêmNgườiDùngToolStripMenuItem.Text = "Nhân sự";
            // 
            // xemNgườiDùngToolStripMenuItem
            // 
            this.xemNgườiDùngToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemNgườiDùngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xemNgườiDùngToolStripMenuItem.Image")));
            this.xemNgườiDùngToolStripMenuItem.Name = "xemNgườiDùngToolStripMenuItem";
            this.xemNgườiDùngToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F12)));
            this.xemNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.xemNgườiDùngToolStripMenuItem.Text = "Xem người dùng";
            this.xemNgườiDùngToolStripMenuItem.Click += new System.EventHandler(this.xemNgườiDùngToolStripMenuItem_Click);
            // 
            // thêmNhânViênToolStripMenuItem
            // 
            this.thêmNhânViênToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thêmNhânViênToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thêmNhânViênToolStripMenuItem.Image")));
            this.thêmNhânViênToolStripMenuItem.Name = "thêmNhânViênToolStripMenuItem";
            this.thêmNhânViênToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F13)));
            this.thêmNhânViênToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.thêmNhânViênToolStripMenuItem.Text = "Thêm nhân viên";
            this.thêmNhânViênToolStripMenuItem.Click += new System.EventHandler(this.thêmNhânViênToolStripMenuItem_Click);
            // 
            // thêmTàiKhoảnToolStripMenuItem
            // 
            this.thêmTàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thêmTàiKhoảnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thêmTàiKhoảnToolStripMenuItem.Image")));
            this.thêmTàiKhoảnToolStripMenuItem.Name = "thêmTàiKhoảnToolStripMenuItem";
            this.thêmTàiKhoảnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F14)));
            this.thêmTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.thêmTàiKhoảnToolStripMenuItem.Text = "Thêm tài khoản";
            this.thêmTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thêmTàiKhoảnToolStripMenuItem_Click);
            // 
            // traCứuToolStripMenuItem
            // 
            this.traCứuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnToolStripMenuItem});
            this.traCứuToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traCứuToolStripMenuItem.Name = "traCứuToolStripMenuItem";
            this.traCứuToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.traCứuToolStripMenuItem.Text = "Tra cứu";
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hóaĐơnToolStripMenuItem.Image")));
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F10)));
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa Đơn ";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmThuốcToolStripMenuItem,
            this.xemThuốcToolStripMenuItem});
            this.thoátToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.thoátToolStripMenuItem.Text = "Thuốc";
            // 
            // thêmThuốcToolStripMenuItem
            // 
            this.thêmThuốcToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thêmThuốcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thêmThuốcToolStripMenuItem.Image")));
            this.thêmThuốcToolStripMenuItem.Name = "thêmThuốcToolStripMenuItem";
            this.thêmThuốcToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.thêmThuốcToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.thêmThuốcToolStripMenuItem.Text = "Thêm Thuốc";
            this.thêmThuốcToolStripMenuItem.Click += new System.EventHandler(this.thêmThuốcToolStripMenuItem_Click);
            // 
            // xemThuốcToolStripMenuItem
            // 
            this.xemThuốcToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemThuốcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xemThuốcToolStripMenuItem.Image")));
            this.xemThuốcToolStripMenuItem.Name = "xemThuốcToolStripMenuItem";
            this.xemThuốcToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.xemThuốcToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.xemThuốcToolStripMenuItem.Text = "Xem Thuốc";
            this.xemThuốcToolStripMenuItem.Click += new System.EventHandler(this.xemThuốcToolStripMenuItem_Click);
            // 
            // cungCấpToolStripMenuItem
            // 
            this.cungCấpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhàCungCấpToolStripMenuItem});
            this.cungCấpToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cungCấpToolStripMenuItem.Name = "cungCấpToolStripMenuItem";
            this.cungCấpToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.cungCấpToolStripMenuItem.Text = "Cung Cấp";
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhàCungCấpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhàCungCấpToolStripMenuItem.Image")));
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F19)));
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà Cung Cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.TargetControl = this.panel2;
            // 
            // guna2Elipse4
            // 
            this.guna2Elipse4.TargetControl = this.panel2;
            // 
            // guna2Elipse5
            // 
            this.guna2Elipse5.TargetControl = this.panel2;
            // 
            // guna2Elipse6
            // 
            this.guna2Elipse6.TargetControl = this.panel2;
            // 
            // guna2Elipse7
            // 
            this.guna2Elipse7.TargetControl = this.panel2;
            // 
            // guna2Elipse8
            // 
            this.guna2Elipse8.TargetControl = this.panel2;
            // 
            // uS_XemThuoc1
            // 
            this.uS_XemThuoc1.BackColor = System.Drawing.Color.SeaShell;
            this.uS_XemThuoc1.Location = new System.Drawing.Point(0, 32);
            this.uS_XemThuoc1.Name = "uS_XemThuoc1";
            this.uS_XemThuoc1.Size = new System.Drawing.Size(1174, 874);
            this.uS_XemThuoc1.TabIndex = 10;
            // 
            // uS_AddThuoc1
            // 
            this.uS_AddThuoc1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uS_AddThuoc1.Location = new System.Drawing.Point(0, 32);
            this.uS_AddThuoc1.Name = "uS_AddThuoc1";
            this.uS_AddThuoc1.Size = new System.Drawing.Size(1174, 874);
            this.uS_AddThuoc1.TabIndex = 9;
            // 
            // uC_ViewUser1
            // 
            this.uC_ViewUser1.Location = new System.Drawing.Point(0, 32);
            this.uC_ViewUser1.Name = "uC_ViewUser1";
            this.uC_ViewUser1.Size = new System.Drawing.Size(1174, 821);
            this.uC_ViewUser1.TabIndex = 8;
            // 
            // uC_HoaDon1
            // 
            this.uC_HoaDon1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uC_HoaDon1.Location = new System.Drawing.Point(0, 32);
            this.uC_HoaDon1.Name = "uC_HoaDon1";
            this.uC_HoaDon1.Size = new System.Drawing.Size(1174, 821);
            this.uC_HoaDon1.TabIndex = 7;
            // 
            // uC_DasbBord1
            // 
            this.uC_DasbBord1.BackColor = System.Drawing.Color.White;
            this.uC_DasbBord1.Location = new System.Drawing.Point(0, 32);
            this.uC_DasbBord1.Name = "uC_DasbBord1";
            this.uC_DasbBord1.Size = new System.Drawing.Size(1174, 821);
            this.uC_DasbBord1.TabIndex = 6;
            // 
            // uC_AddUser1
            // 
            this.uC_AddUser1.Location = new System.Drawing.Point(0, 32);
            this.uC_AddUser1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_AddUser1.Name = "uC_AddUser1";
            this.uC_AddUser1.Size = new System.Drawing.Size(1174, 821);
            this.uC_AddUser1.TabIndex = 5;
            // 
            // uC_XemNV1
            // 
            this.uC_XemNV1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.uC_XemNV1.Location = new System.Drawing.Point(0, 32);
            this.uC_XemNV1.Name = "uC_XemNV1";
            this.uC_XemNV1.Size = new System.Drawing.Size(1174, 821);
            this.uC_XemNV1.TabIndex = 4;
            // 
            // uC_AddUser2
            // 
            this.uC_AddUser2.Location = new System.Drawing.Point(328, 89);
            this.uC_AddUser2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_AddUser2.Name = "uC_AddUser2";
            this.uC_AddUser2.Size = new System.Drawing.Size(8, 92);
            this.uC_AddUser2.TabIndex = 3;
            // 
            // uS_NhaCungCap1
            // 
            this.uS_NhaCungCap1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uS_NhaCungCap1.Location = new System.Drawing.Point(0, 32);
            this.uS_NhaCungCap1.Name = "uS_NhaCungCap1";
            this.uS_NhaCungCap1.Size = new System.Drawing.Size(1174, 874);
            this.uS_NhaCungCap1.TabIndex = 11;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1406, 886);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Admin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label lblUserName;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse4;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bảngĐiềuKhiểnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmNgườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemNgườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCứuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private AdminDB.UC_AddUser uC_AddUser2;
        private AdminDB.UC_XemNV uC_XemNV1;
        private AdminDB.UC_ViewUser uC_ViewUser1;
        private AdminDB.UC_HoaDon uC_HoaDon1;
        private AdminDB.UC_DasbBord uC_DasbBord1;
        private AdminDB.UC_AddUser uC_AddUser1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse6;
        private UserDB.US_XemThuoc uS_XemThuoc1;
        private UserDB.US_AddThuoc uS_AddThuoc1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse7;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse8;
        private UserDB.US_NhaCungCap uS_NhaCungCap1;
    }
}