using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Oracle.DataAccess.Client;
using System.Drawing;
using System.IO;
using Oracle.DataAccess.Types;

namespace FP_PBD_2
{
    public class koneksi
    {
        public koneksi()
        {
        }
        
        private OracleConnection conn;
        

        private string OracleServer = "Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));"
             + "User Id=final_project;Password=1234;";

        
        public bool Open()
        {
            try
            {
                conn = new OracleConnection();
                conn.ConnectionString = OracleServer;
                conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public OracleDataReader ExecuteReader(string sql)
        {
            try
            {
                OracleDataReader reader;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                OracleTransaction mytransaction = conn.BeginTransaction();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        public String generateID(String prefix, String nameTable, int indexColumn, int lenght)
        {
            Open();
            int count = 1;
            string ratusan;


            String sql = "Select * From " + nameTable;
            OracleDataReader reader = ExecuteReader(sql);
            List<int> index = new List<int>();

            //mengambil data dari database
            while (reader.Read())
            {

                index.Add(int.Parse(reader.GetString(indexColumn).Substring(prefix.Length, lenght).Trim()));

            };

            //mengurutkan data yang telah diambil
            index.Sort();

            //mencari data akhir dari database, setalah itu menggenerate setelahnya
            for (int i = 1; i <= index.Count; i++)
            {
                if (index[i - 1] != i)
                {
                    count = i;
                    break;
                }
                count = i + 1;
            }

            //menutup koneksi
            Close();
            //Tambahan agar bentuk kode sama dengan bentuk awalnya.
            if (count < 100)
                ratusan = "0";
            else ratusan = "";

            return prefix + ratusan + count;
        }
        // memasukkan file berupa gambar pada server
        public void InsertBlob(string sql, string fileName)
        {
            try
            {
                byte[] blob = new byte[0];
                OracleParameter blobParameter = new OracleParameter("BlobParameter", OracleDbType.Blob);

                if (!fileName.Equals(""))
                {
                    FileStream fs = new FileStream(@fileName, FileMode.Open, FileAccess.Read);
                    blob = new byte[fs.Length];
                    fs.Read(blob, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                }
                else
                {
                    blobParameter.Value = null;
                }
                blobParameter.Value = blob;
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(blobParameter);
                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CekBlob(string sql, string tabel,string name_column, string keyparameter, string keyvalue)
        {
            BitmapImage image = new BitmapImage();
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            OracleParameter Blob = new OracleParameter("Blob", OracleDbType.Blob);
            Blob.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Blob);
            cmd.ExecuteNonQuery();
            byte[] byteData = new byte[0];
            byteData = (byte[])((OracleBlob)(cmd.Parameters[0].Value)).Value;
            if (byteData.Length == 0)
            {
                
                string path = @"C:\Documents and Settings\My XP\My Documents\My Pictures\untitled.jpg";
                string s = "update " + tabel + " set " + name_column + " = :BlobParameter where " + keyparameter + " = '" + keyvalue + "'";
                
                InsertBlob(s,path);
            }
            
            
        }

        public BitmapImage ShowBlob(string sql)
        {
            BitmapImage image = new BitmapImage();
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            OracleParameter Blob = new OracleParameter("Blob", OracleDbType.Blob);
            Blob.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Blob);
            cmd.ExecuteNonQuery();
            byte[] byteData = new byte[0];

            byteData = (byte[])((OracleBlob)(cmd.Parameters[0].Value)).Value;


            MemoryStream ms = new MemoryStream(byteData);
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();


            return image;


        }

        public List<string> GetData(string sql,string kolom)
        {
            List<string> data = new List<string>();
            Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader[kolom].ToString());
            }
            reader.Close();
            Close();
            if (data.Count == 0) { data.Add("<kosong>"); } // error handling jika list<string>data "kosong"
            return data;
        }

        public List<string> GetData_date(string sql)
        {
            List<string> data = new List<string>();
            Open();

            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data.Add(reader.GetDateTime(0).ToLongDateString().ToString());
            }
            reader.Close();
            Close();

            return data;
        }



    }
}