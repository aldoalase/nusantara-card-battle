using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using serverBaru;
using Oracle.DataAccess.Client;

namespace serverBaru
{
    public partial class Form1 : Form
    {
        koneksi con;
        ConnectionManager connection;
      
        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            con = new koneksi();
            connection = new ConnectionManager();
        }

        private void usrTombol_Click(object sender, EventArgs e)
        {
            string usrpass = "";
            try
            {
                string sql = " select * from usr u where u.usr_name = '"+usrBox.Text+"' ";
                con.Open();
                OracleDataReader read = con.ExecuteReader(sql);
                con.ExecuteNonQuery(sql);
                if (read.Read())
                {
                    usrpass = (string)read["usr_pass"];
                }
                con.Close();
                if (usrpass == passBox.Text)
                    MessageBox.Show("berhasil login");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
