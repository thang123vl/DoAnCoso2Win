namespace DoAn2
{
    partial class frmNews
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNews));
            this.btnGetNews = new Guna.UI2.WinForms.Guna2Button();
            this.webViewNews = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.webViewNews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetNews
            // 
            this.btnGetNews.Animated = true;
            this.btnGetNews.BackColor = System.Drawing.Color.Transparent;
            this.btnGetNews.BorderRadius = 10;
            this.btnGetNews.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGetNews.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGetNews.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGetNews.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGetNews.FillColor = System.Drawing.Color.Blue;
            this.btnGetNews.Font = new System.Drawing.Font("Century", 13.8F);
            this.btnGetNews.ForeColor = System.Drawing.Color.White;
            this.btnGetNews.IndicateFocus = true;
            this.btnGetNews.Location = new System.Drawing.Point(12, 113);
            this.btnGetNews.Name = "btnGetNews";
            this.btnGetNews.Size = new System.Drawing.Size(180, 45);
            this.btnGetNews.TabIndex = 1;
            this.btnGetNews.Text = "News";
            this.btnGetNews.UseTransparentBackground = true;
            this.btnGetNews.Click += new System.EventHandler(this.btnGetNews_Click);
            // 
            // webViewNews
            // 
            this.webViewNews.AllowExternalDrop = true;
            this.webViewNews.CreationProperties = null;
            this.webViewNews.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewNews.Location = new System.Drawing.Point(334, 12);
            this.webViewNews.Name = "webViewNews";
            this.webViewNews.Size = new System.Drawing.Size(1642, 988);
            this.webViewNews.TabIndex = 3;
            this.webViewNews.ZoomFactor = 1D;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(12, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(316, 41);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 44);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(316, 52);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellDoubleClick);
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 992);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.webViewNews);
            this.Controls.Add(this.btnGetNews);
            this.Controls.Add(this.dgvProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNews";
            this.Text = "Tin Tức";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webViewNews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnGetNews;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewNews;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}