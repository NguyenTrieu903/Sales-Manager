
namespace Final_test_CodeFirst
{
    partial class frmDoanhThu
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
            this.dgvHDon = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtdoanhthu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHDon
            // 
            this.dgvHDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdCus,
            this.IdEm,
            this.DateBill,
            this.Total});
            this.dgvHDon.Location = new System.Drawing.Point(83, 81);
            this.dgvHDon.Name = "dgvHDon";
            this.dgvHDon.RowHeadersWidth = 51;
            this.dgvHDon.RowTemplate.Height = 24;
            this.dgvHDon.Size = new System.Drawing.Size(749, 307);
            this.dgvHDon.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Mã hóa đơn";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // IdCus
            // 
            this.IdCus.DataPropertyName = "IdCus";
            this.IdCus.HeaderText = "Mã khách hàng";
            this.IdCus.MinimumWidth = 6;
            this.IdCus.Name = "IdCus";
            this.IdCus.Width = 125;
            // 
            // IdEm
            // 
            this.IdEm.DataPropertyName = "IdEm";
            this.IdEm.HeaderText = "Mã nhân viên";
            this.IdEm.MinimumWidth = 6;
            this.IdEm.Name = "IdEm";
            this.IdEm.Width = 125;
            // 
            // DateBill
            // 
            this.DateBill.DataPropertyName = "DateBill";
            this.DateBill.HeaderText = "Ngày xuất";
            this.DateBill.MinimumWidth = 6;
            this.DateBill.Name = "DateBill";
            this.DateBill.Width = 125;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Tổng tiền";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 125;
            // 
            // txtdoanhthu
            // 
            this.txtdoanhthu.Location = new System.Drawing.Point(208, 412);
            this.txtdoanhthu.Name = "txtdoanhthu";
            this.txtdoanhthu.Size = new System.Drawing.Size(179, 22);
            this.txtdoanhthu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(97, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doanh thu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 75);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(330, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng doanh thu";
            // 
            // btnTrove
            // 
            this.btnTrove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTrove.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrove.ForeColor = System.Drawing.Color.Red;
            this.btnTrove.Location = new System.Drawing.Point(714, 396);
            this.btnTrove.Name = "btnTrove";
            this.btnTrove.Size = new System.Drawing.Size(118, 44);
            this.btnTrove.TabIndex = 9;
            this.btnTrove.Text = "Trở về";
            this.btnTrove.UseVisualStyleBackColor = false;
            this.btnTrove.Click += new System.EventHandler(this.btnTrove_Click);
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 443);
            this.ControlBox = false;
            this.Controls.Add(this.btnTrove);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdoanhthu);
            this.Controls.Add(this.dgvHDon);
            this.Name = "frmDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDoanhThu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCus;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txtdoanhthu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrove;
    }
}