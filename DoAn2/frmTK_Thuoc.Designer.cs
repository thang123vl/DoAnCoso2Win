namespace DoAn2
{
    partial class frmTK_Thuoc
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTK_Thuoc));
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.lblHetHan = new System.Windows.Forms.Label();
            this.lblConHan = new System.Windows.Forms.Label();
            this.lblThuocGanHetHan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // chartThongKe
            // 
            this.chartThongKe.BackColor = System.Drawing.Color.RosyBrown;
            this.chartThongKe.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 80F;
            chartArea1.InnerPlotPosition.Width = 80F;
            chartArea1.InnerPlotPosition.X = 10F;
            chartArea1.InnerPlotPosition.Y = 10F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 90F;
            chartArea1.Position.Width = 90F;
            chartArea1.Position.X = 5F;
            chartArea1.Position.Y = 5F;
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Location = new System.Drawing.Point(23, 47);
            this.chartThongKe.Name = "chartThongKe";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThongKe.Series.Add(series1);
            this.chartThongKe.Size = new System.Drawing.Size(686, 436);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "chart1";
            // 
            // btnThongKe
            // 
            this.btnThongKe.BorderRadius = 10;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageSize = new System.Drawing.Size(35, 35);
            this.btnThongKe.Location = new System.Drawing.Point(298, 500);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(152, 60);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // lblHetHan
            // 
            this.lblHetHan.BackColor = System.Drawing.Color.Peru;
            this.lblHetHan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHetHan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHetHan.Location = new System.Drawing.Point(436, 225);
            this.lblHetHan.Name = "lblHetHan";
            this.lblHetHan.Size = new System.Drawing.Size(247, 31);
            this.lblHetHan.TabIndex = 20;
            this.lblHetHan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConHan
            // 
            this.lblConHan.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblConHan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConHan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConHan.Location = new System.Drawing.Point(436, 166);
            this.lblConHan.Name = "lblConHan";
            this.lblConHan.Size = new System.Drawing.Size(247, 31);
            this.lblConHan.TabIndex = 21;
            this.lblConHan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThuocGanHetHan
            // 
            this.lblThuocGanHetHan.BackColor = System.Drawing.Color.Red;
            this.lblThuocGanHetHan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblThuocGanHetHan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuocGanHetHan.Location = new System.Drawing.Point(436, 281);
            this.lblThuocGanHetHan.Name = "lblThuocGanHetHan";
            this.lblThuocGanHetHan.Size = new System.Drawing.Size(269, 31);
            this.lblThuocGanHetHan.TabIndex = 22;
            this.lblThuocGanHetHan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTK_Thuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(736, 581);
            this.Controls.Add(this.lblThuocGanHetHan);
            this.Controls.Add(this.lblConHan);
            this.Controls.Add(this.lblHetHan);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.chartThongKe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTK_Thuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TK_Thuốc";
            this.Load += new System.EventHandler(this.frmTK_Thuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private System.Windows.Forms.Label lblHetHan;
        private System.Windows.Forms.Label lblConHan;
        private System.Windows.Forms.Label lblThuocGanHetHan;
    }
}