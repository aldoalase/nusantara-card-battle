using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Oracle.DataAccess.Client;


namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for data_personal_pegawai.xaml
	/// </summary>
	public partial class data_personal_pegawai : Window
	{
		 
		koneksi konek;
        string statement;
        DataSet ds;
        string idAdmin;
        string path;
     
		public data_personal_pegawai(string id)
		{		
			ds = new DataSet();
			this.InitializeComponent();
        
            idAdmin = id;
            inisialisasi();
            tampil();
            konek = new koneksi();
            konek.Open();
            statement = "begin select picture_pegawai into :blob from pegawai where id_pegawai ='" + idAdmin + "'; end;";
            konek.CekBlob(statement, "pegawai", "picture_pegawai", "id_pegawai", idAdmin);
            konek.Close();
		}
		
		private void inisialisasi()
        {
            b_nama.Text = "";
            b_id.Text = "";
            b_alamat.Text = "";
            b_notelp.Text = "";
            b_pass.Text = "";
            Header.Content = "WELCOME";

        }
        private bool executeNonQuery(string sql)
        {
            int affected;
            konek = new koneksi();
            if (konek.Open())
            {
                affected = konek.ExecuteNonQuery(sql);
                konek.Close();
                return true;
            }
            return false;
        }
        private void tampil()
        {
            konek = new koneksi();
            Ascii85 a = new Ascii85();
            OracleDataReader reader;
            konek.Open();
            reader = konek.ExecuteReader("select password_pegawai from pegawai where id_pegawai ='"+ idAdmin +"'");
            reader.Read();
            if (reader.HasRows)
            {
                byte[] decoded = a.Decode(reader.GetString(0)); 
                b_pass.Text= Encoding.ASCII.GetString(decoded);
            }
            else b_pass.Text="";
            reader.Close();
          
            b_id.Text= idAdmin;
            b_nama.Text = konek.GetData("select nama_pegawai from pegawai where id_pegawai ='" + idAdmin + "'","nama_pegawai")[0];
            b_alamat.Text = konek.GetData("select alamat_pegawai from pegawai where id_pegawai ='" + idAdmin + "'","alamat_pegawai")[0];
            b_notelp.Text = konek.GetData("select no_telp_pegawai from pegawai where id_pegawai ='" + idAdmin + "'","no_telp_pegawai")[0];
            Header.Content = "Selamat Datang, " + b_nama.Text;
            konek.Close();

            konek.Open();
            statement = "begin select picture_pegawai into :blob from pegawai where id_pegawai ='" + idAdmin + "'; end;";
            pic.Source = konek.ShowBlob(statement);//masih cacad
            konek.Close();

        }
		
		

		private void back(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back_pegawai = new Window2(idAdmin);
			back_pegawai.Show();
			this.Close();
		}

		private void edit_pegawai_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.Ascii85 a = new Ascii85();
            if (b_nama.Text.Length > 20 || b_notelp.Text.Length > 20 || b_alamat.Text.Length > 50 || b_pass.Text.Length > 32 )
			{
				MessageBox.Show("Terjadi kesalahan dalam input data", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
				else
			{
				Ascii85 a = new Ascii85();
				string s = b_pass.Text;
				byte[] ba = Encoding.ASCII.GetBytes(s);
				string encoded = a.Encode(ba);
				konek.Open();
				statement = "update pegawai set nama_pegawai = '"
					+ b_nama.Text + "', no_telp_pegawai ='"
					+ b_notelp.Text + "', alamat_pegawai = '"
					+ b_alamat.Text + "', password_pegawai = '"
					+ encoded +"' where id_pegawai = '" + idAdmin + "'";
	
	
				
				if (executeNonQuery(statement))
				{
					MessageBox.Show("Data berhasil diganti");
					konek.Open();
					konek.InsertBlob("update pegawai set picture_pegawai = :BlobParameter where id_pegawai = '" + idAdmin + "'", path);
					konek.Close();
				}
				else MessageBox.Show("Data tidak berhasil diganti");
			}
		}

		private void browse_pic_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			 Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                path = dlg.FileName;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(path);
                img.EndInit();
                pic.Source = img;
            }
		}

		private void b_id_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void b_nama_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if (b_nama.Text.Length > 20)
			{
				b_nama.Background = Brushes.Red;
			}
			else
				b_nama.Background = Brushes.White;
		}

		private void b_pass_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if (b_pass.Text.Length > 32)
			{
				b_pass.Background = Brushes.Red;
			}
			else
				b_pass.Background = Brushes.White;
		}

		private void b_notelp_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if (b_notelp.Text.Length > 20)
			{
				b_notelp.Background = Brushes.Red;
			}
			else
				b_notelp.Background = Brushes.White;
		}

		private void b_alamat_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if (b_alamat.Text.Length > 50)
			{
				b_alamat.Background = Brushes.Red;
			}
			else
				b_alamat.Background = Brushes.White;
		}
	}
}