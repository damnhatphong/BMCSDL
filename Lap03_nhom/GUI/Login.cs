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
using Lap03_nhom.Encryptor;

namespace Lap03_nhom
{
    public partial class Login : Form
    {
        string connString = ConfigurationManager.ConnectionStrings["ConnectionStringQLSV"].ConnectionString;

        public Login()
        {
            InitializeComponent();

        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                /*try
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
                /*SqlCommand command2 = new SqlCommand();
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

                    /*frmMenuChucNang chucnang = new frmMenuChucNang(dataTable.Rows[0]["MANV"].ToString());
                    chucnang.Show();*/

                /*using (frmMenuChucNang chucnang = new frmMenuChucNang(dataTable.Rows[0]["MANV"].ToString()))
                    if (chucnang.ShowDialog() == DialogResult.OK)
                    {
                        this.Hide();
                        Application.Run(new frmMenuChucNang(dataTable.Rows[0]["MANV"].ToString()));
                        this.Show();
                    }

                da.Dispose();
                conn.Close();

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
        }*/

                //Phần sửa lại login
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "NHANVIEN_LOGIN";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@USERNAME", System.Data.SqlDbType.NVarChar).Value = txtUSN.Text;
                    command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.NVarChar).Value = SHA1Encryptor.getSHA1Hash(txtPWD.Text);

                    //Lấy mã nhân viên nhờ data adapter
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);

                    SqlDataReader reader = command.ExecuteReader();
                    //Nếu có khớp 
                    if (reader.HasRows)
                    {

                        MessageBox.Show("Login successfully!", "Have a great day! :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Dùng using để chương trình nếu có thoát thì thoát hoàn toàn
                        using (frmMenuChucNang chucnang = new frmMenuChucNang(dataTable.Rows[0]["MANV"].ToString()))
                            if (chucnang.ShowDialog() == DialogResult.OK)
                            {
                                //Ẩn form
                                this.Hide();
                                Application.Run(new frmMenuChucNang(dataTable.Rows[0]["MANV"].ToString()));
                                //Hiện form sau khi frmMenuChucNang thoát ra 
                                this.Show();
                            }
                        //Đóng reader lại
                        reader.Close();
                        return;
                    }
                    //Còn không khớp thì báo lỗi
                    else
                    {
                        MessageBox.Show("Login failed! Incorrect username or password", "Failed:(", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    reader.Close();
                } 
                //Chỉ catch mỗi lỗi kết nối
                catch (Exception ex) 
                {
                    MessageBox.Show("Please solve this error: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
