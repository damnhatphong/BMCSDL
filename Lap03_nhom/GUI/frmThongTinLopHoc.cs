﻿using System;
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
    public partial class frmThongTinLopHoc : Form
    {
        private string MaNV { get; set; }
        public frmThongTinLopHoc(string manv)
        {
            InitializeComponent();
            MaNV = manv;

        }

        private void frmThongTinLopHoc_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=QLSV;User ID=SA;Password=Moccacute36"))
            {

                try
                {
                    string queryString = "SELECT * FROM LOP WHERE LOP.MANV = N'" + MaNV + "'";
                    SqlCommand command2 = new SqlCommand(queryString, conn);
                    SqlDataAdapter ad = new SqlDataAdapter(command2);
                    DataTable dataTable = new DataTable();
                    BindingSource bindingsource = new BindingSource();
                    ad.Fill(dataTable);
                    bindingsource.DataSource = dataTable;
                    dgvThongTinLopHop.Columns.Clear();
                    dgvThongTinLopHop.AutoGenerateColumns = true;
                    dgvThongTinLopHop.DataSource = bindingsource;
                    boNhanVien.Text = MaNV;
                    boNhanVien.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please solve this error: "+ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
