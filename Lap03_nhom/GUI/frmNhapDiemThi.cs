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
   
    public partial class frmNhapDiemThi : Form
    {
        string connString = ConfigurationManager.ConnectionStrings["ConnectionStringQLSV"].ConnectionString;
        private string MaNV { get; set; }
        public frmNhapDiemThi(string manv)
        {

            InitializeComponent();
            MaNV = manv;
        }

        private void frmNhapDiemThi_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    string queryString = "SELECT MAHP FROM HOCPHAN";
                    SqlCommand command2 = new SqlCommand(queryString, conn);
                    SqlDataAdapter ad = new SqlDataAdapter(command2);
                    DataTable dataTable = new DataTable();
                    ad.Fill(dataTable);
                    List<string> list = new List<string>();
                    foreach (var x in dataTable.AsEnumerable())
                    {
                        list.Add(x["MAHP"].ToString());
                    }
                    cbHocPhan.DataSource = list;

                    queryString = "SELECT MASV FROM SINHVIEN WHERE MALOP = (SELECT MALOP FROM LOP WHERE MANV = N'" + MaNV + "')";
                    command2 = new SqlCommand(queryString, conn);
                    ad = new SqlDataAdapter(command2);
                    dataTable = new DataTable();
                    ad.Fill(dataTable);
                    list = new List<string>();
                    foreach (var x in dataTable.AsEnumerable())
                    {
                        list.Add(x["MASV"].ToString());
                    }
                    cbSinhVien.DataSource = list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please solve this error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    string masv = cbSinhVien.Text;
                    string mahp = cbHocPhan.Text;
                    string diem = txtDiemThi.Text;

                    conn.Open();
                    string queryString = "EXECUTE SP_NHAPDIEM '" + masv + "','" + mahp + "','" + diem + "','" + MaNV + "'";
                    SqlCommand command2 = new SqlCommand(queryString, conn);
                    command2.ExecuteReader();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please solve this error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
