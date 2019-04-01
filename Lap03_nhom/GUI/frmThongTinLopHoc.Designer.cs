namespace Lap03_nhom
{
    partial class frmThongTinLopHoc
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
            this.label3 = new System.Windows.Forms.Label();
            this.boNhanVien = new System.Windows.Forms.ComboBox();
            this.dgvThongTinLopHop = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinLopHop)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nhân Viên";
            // 
            // boNhanVien
            // 
            this.boNhanVien.FormattingEnabled = true;
            this.boNhanVien.Location = new System.Drawing.Point(252, 21);
            this.boNhanVien.Name = "boNhanVien";
            this.boNhanVien.Size = new System.Drawing.Size(131, 21);
            this.boNhanVien.TabIndex = 11;
            // 
            // dgvThongTinLopHop
            // 
            this.dgvThongTinLopHop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTinLopHop.Location = new System.Drawing.Point(12, 69);
            this.dgvThongTinLopHop.Name = "dgvThongTinLopHop";
            this.dgvThongTinLopHop.Size = new System.Drawing.Size(575, 284);
            this.dgvThongTinLopHop.TabIndex = 12;
            // 
            // frmThongTinLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 450);
            this.Controls.Add(this.dgvThongTinLopHop);
            this.Controls.Add(this.boNhanVien);
            this.Controls.Add(this.label3);
            this.Name = "frmThongTinLopHoc";
            this.Text = "Thông tin lớp học";
            this.Load += new System.EventHandler(this.frmThongTinLopHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinLopHop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boNhanVien;
        private System.Windows.Forms.DataGridView dgvThongTinLopHop;
    }
}