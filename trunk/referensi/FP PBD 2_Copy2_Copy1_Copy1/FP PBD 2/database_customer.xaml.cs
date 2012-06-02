using System;
using System.Data;
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
using Oracle.DataAccess.Client;
namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for database_customer.xaml
	/// </summary>
	public partial class database_customer : Window
	{
		string idPegawai;
		string path;
		koneksi konek;
		string statement;
		DataSet ds;

       
		public database_customer(string id)
		{
			this.InitializeComponent();
			ds = new DataSet();
			konek = new koneksi();
			idPegawai = id;
           
			inisialisasi();
		}
		
		private void inisialisasi()
        {
            /*generate ID*/
            id_customer.Text = konek.generateID("P", "pengirim", 0, 3);
            konek.Close();

			nama_customer.Text= "";
			password_customer.Text= "";
			alamat_customer.Text= "";
			kota_customer.Text= "";
			telpon_customer.Text= "";
			email_customer.Text= "";
			
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


		private void back_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back = new Window2(idPegawai);
			back.Show();
			this.Close();
		}

		private void insert_customer(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			konek.Open();
			Ascii85 a = new Ascii85();
			string s = password_customer.Text;
			byte[] ba = Encoding.ASCII.GetBytes(s);
			string encoded = a.Encode(ba);
			
			statement = "insert into pengirim values ('"+ id_customer.Text +"','" + nama_customer.Text + "','" + alamat_customer.Text + "','" + kota_customer.Text + "','" + telpon_customer.Text + "','" + email_customer.Text + "','" + encoded + "', empty_blob(),'0' )";
			MessageBox.Show(statement);
			if (executeNonQuery(statement))
			{
				MessageBox.Show("Data berhasil ditambahkan");
				konek.Open();
				konek.InsertBlob("update pengirim set picture_customer = :Blobparameter where id_customer ='" + id_customer.Text + "'", path);
				konek.Close();
			}
			else MessageBox.Show("Data Gagal Ditambahkan");
			
			inisialisasi();
						
		}

		private void reset_data(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			inisialisasi();
		}

		private void browse_foto(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.Filter = "Image File (*.jpg;*.bmp;*.gif*.png)|*.jpg;*.bmp;*.gif;*.png";
			
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

		private void id_customer_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void nama_customer_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			if (nama_customer.Text.Length > 20)
			{
				nama_customer.Background = Brushes.Red;
			}
			else
				nama_customer.Background = Brushes.White;

		}
		
		
	}
}