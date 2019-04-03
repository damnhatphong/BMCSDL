using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        string connString = ConfigurationManager.ConnectionStrings["ConnectionStringQLSV"].ConnectionString;
        private string MaNV { get; set; }
        public frmQuanLySV(string manv)
        {
            InitializeComponent();
            MaNV = manv;
           
        }

        private void frmQuanLySV_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    string queryString = "SELECT sv.MASV,sv.HOTEN,sv.NGAYSINH,sv.DIACHI FROM SINHVIEN sv, LOP l WHERE sv.MALOP = l.MALOP and MANV = N'" + MaNV + "'";
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
                catch (Exception ex)
                {
                    MessageBox.Show("Please solve this error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
