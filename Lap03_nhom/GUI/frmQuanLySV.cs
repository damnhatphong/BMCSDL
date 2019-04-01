using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap03_nhom
{
    public partial class frmQuanLySV : Form
    {
        private string MaNV { get; set; }
        public frmQuanLySV(string manv)
        {
            InitializeComponent();
            MaNV = manv;
           
        }

        private void frmQuanLySV_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=PHONG;Initial Catalog=QLSV_NHOM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string queryString = "SELECT MASV,HOTEN,NGAYSINH,DIACHI FROM SINHVIEN WHERE MALOP = (SELECT MALOP FROM LOP WHERE MANV = N'" + MaNV + "')";
                SqlCommand command2 = new SqlCommand(queryString, conn);
                SqlDataAdapter ad = new SqlDataAdapter(command2);
                DataTable dataTable = new DataTable();
                BindingSource bindingsource = new BindingSource();
                ad.Fill(dataTable);
                bindingsource.DataSource = dataTable;
               
                dgvSinhVien.Columns.Clear();
                dgvSinhVien.AutoGenerateColumns = true;
                dgvSinhVien.DataSource = bindingsource;
                cbNhanVien.Text = MaNV;
                cbNhanVien.Enabled = false;
            }
        }
    }
}
