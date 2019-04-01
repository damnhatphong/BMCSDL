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
using Lap03_nhom.Encryptor;

namespace Lap03_nhom
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=PHONG;Initial Catalog=QLSV_NHOM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    conn.Open();
                    /*
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "SINHVIEN_LOGIN";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    /*SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@USERNAME";
                    parameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                    parameter.Direction = System.Data.ParameterDirection.Input;
                    parameter.Value = /
                    command.Parameters.Add("@USERNAME", System.Data.SqlDbType.NVarChar).Value = txtUSN.Text;
                    command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.NVarChar).Value = txtPWD;//MD5Encryptor.getMd5Hash(txtPWD.Text);
                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                      
                        lbMessage.Text = "Login Successfully";
                        reader.Close();                      
                        return;
                    }
                    reader.Close();
                    */
                    SqlCommand command2 = new SqlCommand();
                    command2.Connection = conn;
                    command2.CommandText = "NHANVIEN_LOGIN";
                    command2.CommandType = System.Data.CommandType.StoredProcedure;                   
                    command2.Parameters.Add("@USERNAME", System.Data.SqlDbType.NVarChar).Value = txtUSN.Text;
                    command2.Parameters.Add("@PASSWORD", System.Data.SqlDbType.NVarChar).Value = SHA1Encryptor.getSHA1Hash(txtPWD.Text);

                    
                    //SqlDataReader reader2 = command2.ExecuteReader();
                    SqlDataAdapter da = new SqlDataAdapter(command2);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
     
                    if (dataTable.Rows != null)
                    {
                        lbMessage.Text = "Login Successfully";
                      
                        frmMenuChucNang chucnang = new frmMenuChucNang(dataTable.Rows[0]["MANV"].ToString());
                        chucnang.Show();

                        da.Dispose();
                        conn.Close();
                        this.Hide();
                        //reader2.Close();
                       
                    }
                    else
                    {
                        lbMessage.Text = "Login failed";
                        //reader2.Close();                        
                    }
                    da.Dispose();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lbMessage.Text = "Unhandled Error: "+ ex.Message;
                }
            }
        }
    }
}
