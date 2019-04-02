using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap03_nhom
{
    public partial class frmMenuChucNang : Form
    {
        private string MaNV { get; set; }
        public frmMenuChucNang(string manv)
        {
            InitializeComponent();
            MaNV = manv;
            label1.Text = MaNV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*frmThongTinLopHoc lophoc = new frmThongTinLopHoc(MaNV);
            lophoc.Show();*/
            using (frmThongTinLopHoc lophoc = new frmThongTinLopHoc(MaNV))
                if (lophoc.ShowDialog() == DialogResult.OK)                
                    Application.Run(new frmThongTinLopHoc(MaNV));
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmQuanLySV quanlysv = new frmQuanLySV(MaNV);
            quanlysv.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNhapDiemThi nhapdiem = new frmNhapDiemThi(MaNV);
            nhapdiem.ShowDialog();
        }
    }
}
