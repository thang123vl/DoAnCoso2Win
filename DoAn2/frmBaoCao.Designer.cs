namespace DoAn2
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.lblTongSoLuong = new System.Windows.Forms.Label();
            this.btnInBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.cboBaoCao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblTongSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTongSoLuong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoLuong.Location = new System.Drawing.Point(269, 551);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(322, 35);
            this.lblTongSoLuong.TabIndex = 34;
            this.lblTongSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BorderRadius = 5;
            this.btnInBaoCao.BorderThickness = 1;
            this.btnInBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInBaoCao.FillColor = System.Drawing.Color.Red;
            this.btnInBaoCao.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnInBaoCao.ForeColor = System.Drawing.Color.Black;
            this.btnInBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnInBaoCao.Image")));
            this.btnInBaoCao.ImageSize = new System.Drawing.Size(25, 25);
            this.btnInBaoCao.Location = new System.Drawing.Point(517, 94);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(76, 42);
            this.btnInBaoCao.TabIndex = 35;
            this.btnInBaoCao.Text = "In";
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderThickness = 2;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.SystemColors.HotTrack;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTimKiem.Location = new System.Drawing.Point(28, 95);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(116, 42);
            this.btnTimKiem.TabIndex = 31;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Animated = true;
            this.txtTimKiem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(161, 98);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(350, 36);
            this.txtTimKiem.TabIndex = 32;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(27, 171);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.Size = new System.Drawing.Size(564, 373);
            this.dgvBaoCao.TabIndex = 33;
            // 
            // cboBaoCao
            // 
            this.cboBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.cboBaoCao.BorderThickness = 2;
            this.cboBaoCao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaoCao.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBaoCao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBaoCao.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.cboBaoCao.ForeColor = System.Drawing.Color.Black;
            this.cboBaoCao.ItemHeight = 30;
            this.cboBaoCao.Location = new System.Drawing.Point(161, 30);
            this.cboBaoCao.Name = "cboBaoCao";
            this.cboBaoCao.Size = new System.Drawing.Size(405, 36);
            this.cboBaoCao.TabIndex = 36;
            this.cboBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboBaoCao_SelectedIndexChanged);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXemBaoCao.BorderRadius = 10;
            this.btnXemBaoCao.BorderThickness = 2;
            this.btnXemBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemBaoCao.FillColor = System.Drawing.SystemColors.Info;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.Black;
            this.btnXemBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnXemBaoCao.Image")));
            this.btnXemBaoCao.ImageSize = new System.Drawing.Size(25, 25);
            this.btnXemBaoCao.Location = new System.Drawing.Point(28, 27);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(116, 42);
            this.btnXemBaoCao.TabIndex = 37;
            this.btnXemBaoCao.Text = "Xem BC";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(620, 604);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.cboBaoCao);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.lblTongSoLuong);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTongSoLuong;
        private Guna.UI2.WinForms.Guna2Button btnInBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private Guna.UI2.WinForms.Guna2ComboBox cboBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnXemBaoCao;
    }
}