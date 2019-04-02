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
            label1.Text = "Tên đăng nhập: "+MaNV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmThongTinLopHoc lophoc = new frmThongTinLopHoc(MaNV))
                if (lophoc.ShowDialog() == DialogResult.OK)                
                    Application.Run(new frmThongTinLopHoc(MaNV));
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            /*using (Login login = new Login())
                if (login.ShowDialog() == DialogResult.OK)
                    Application.Run(new Login());*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(frmQuanLySV quanlysv = new frmQuanLySV(MaNV))
                if (quanlysv.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmQuanLySV(MaNV));
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frmNhapDiemThi nhapdiem = new frmNhapDiemThi(MaNV))
                if (nhapdiem.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmNhapDiemThi(MaNV));
                    
        }
    }
}
