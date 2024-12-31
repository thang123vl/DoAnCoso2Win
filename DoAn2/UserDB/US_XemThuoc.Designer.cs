namespace DoAn2.UserDB
{
    partial class US_XemThuoc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_XemThuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkConHan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkHetHan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.txtNhaCungCap = new System.Windows.Forms.TextBox();
            this.txtDanhMuc = new System.Windows.Forms.TextBox();
            this.dgvDanhSachThuoc = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.pictureBoxThuoc = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRA CỨU THÔNG TIN";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 5;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTimKiem.Location = new System.Drawing.Point(366, 305);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(138, 45);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhà Cung Cấp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhóm Thuốc:";
            // 
            // chkConHan
            // 
            this.chkConHan.AutoSize = true;
            this.chkConHan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkConHan.CheckedState.BorderRadius = 0;
            this.chkConHan.CheckedState.BorderThickness = 0;
            this.chkConHan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkConHan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.chkConHan.Location = new System.Drawing.Point(183, 150);
            this.chkConHan.Name = "chkConHan";
            this.chkConHan.Size = new System.Drawing.Size(101, 26);
            this.chkConHan.TabIndex = 7;
            this.chkConHan.Text = "Còn Hạn";
            this.chkConHan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkConHan.UncheckedState.BorderRadius = 0;
            this.chkConHan.UncheckedState.BorderThickness = 0;
            this.chkConHan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // chkHetHan
            // 
            this.chkHetHan.AutoSize = true;
            this.chkHetHan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkHetHan.CheckedState.BorderRadius = 0;
            this.chkHetHan.CheckedState.BorderThickness = 0;
            this.chkHetHan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkHetHan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.chkHetHan.Location = new System.Drawing.Point(407, 150);
            this.chkHetHan.Name = "chkHetHan";
            this.chkHetHan.Size = new System.Drawing.Size(97, 26);
            this.chkHetHan.TabIndex = 8;
            this.chkHetHan.Text = "Hết Hạn";
            this.chkHetHan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkHetHan.UncheckedState.BorderRadius = 0;
            this.chkHetHan.UncheckedState.BorderThickness = 0;
            this.chkHetHan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Enabled = false;
            this.txtNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaCungCap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNhaCungCap.Location = new System.Drawing.Point(183, 187);
            this.txtNhaCungCap.Multiline = true;
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.Size = new System.Drawing.Size(321, 29);
            this.txtNhaCungCap.TabIndex = 10;
            // 
            // txtDanhMuc
            // 
            this.txtDanhMuc.Enabled = false;
            this.txtDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanhMuc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDanhMuc.Location = new System.Drawing.Point(183, 259);
            this.txtDanhMuc.Multiline = true;
            this.txtDanhMuc.Name = "txtDanhMuc";
            this.txtDanhMuc.Size = new System.Drawing.Size(321, 29);
            this.txtDanhMuc.TabIndex = 11;
            // 
            // dgvDanhSachThuoc
            // 
            this.dgvDanhSachThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachThuoc.Location = new System.Drawing.Point(33, 391);
            this.dgvDanhSachThuoc.Name = "dgvDanhSachThuoc";
            this.dgvDanhSachThuoc.RowHeadersWidth = 51;
            this.dgvDanhSachThuoc.RowTemplate.Height = 24;
            this.dgvDanhSachThuoc.Size = new System.Drawing.Size(1073, 444);
            this.dgvDanhSachThuoc.TabIndex = 12;
            this.dgvDanhSachThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachThuoc_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Đơn Giá:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Enabled = false;
            this.txtDonGia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDonGia.Location = new System.Drawing.Point(183, 319);
            this.txtDonGia.Multiline = true;
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(155, 29);
            this.txtDonGia.TabIndex = 14;
            // 
            // pictureBoxThuoc
            // 
            this.pictureBoxThuoc.Location = new System.Drawing.Point(580, 41);
            this.pictureBoxThuoc.Name = "pictureBoxThuoc";
            this.pictureBoxThuoc.Size = new System.Drawing.Size(526, 325);
            this.pictureBoxThuoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxThuoc.TabIndex = 15;
            this.pictureBoxThuoc.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nhập từ khóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.txtTimKiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(183, 89);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "Search.........";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(321, 43);
            this.txtTimKiem.TabIndex = 17;
            // 
            // US_XemThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxThuoc);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDanhSachThuoc);
            this.Controls.Add(this.txtDanhMuc);
            this.Controls.Add(this.txtNhaCungCap);
            this.Controls.Add(this.chkHetHan);
            this.Controls.Add(this.chkConHan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Name = "US_XemThuoc";
            this.Size = new System.Drawing.Size(1174, 874);
            this.Load += new System.EventHandler(this.US_XemThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CheckBox chkConHan;
        private Guna.UI2.WinForms.Guna2CheckBox chkHetHan;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.TextBox txtNhaCungCap;
        private System.Windows.Forms.TextBox txtDanhMuc;
        private System.Windows.Forms.DataGridView dgvDanhSachThuoc;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxThuoc;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
    }
}
