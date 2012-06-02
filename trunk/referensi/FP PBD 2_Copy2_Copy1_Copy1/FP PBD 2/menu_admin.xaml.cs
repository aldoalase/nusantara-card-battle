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
using Oracle.DataAccess.Client;

namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for menu_adminxaml.xaml
	/// </summary>
	public partial class menu_adminxaml : Window
	{
        koneksi konek;
        string idAdmin;
        
		public menu_adminxaml(string id)
		{
			this.InitializeComponent();
            konek = new koneksi();
            idAdmin = id;

            cekTracking();
		}

        private void cekTracking()
        {
            List<string> blmTracking = konek.GetData("select id_pengiriman from(select t1.id_pengiriman,t2.* from transaksi_pengiriman t1 left outer join (select id_pengiriman as kirim from tracking where keterangan_tracking != 'Proses') t2  on t1.id_pengiriman = t2.kirim) where kirim is null order by id_pengiriman","id_pengiriman");
            for (int i = 0; i < blmTracking.Count; i++)
            {
                if (blmTracking[i] != "<kosong>")
                MessageBox.Show("Kiriman No : "+blmTracking[i]+ " belum sampai ke penerima","Info",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                
            }
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void click_exit(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.Close();
		}

		private void move(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.DragMove();
		}

		private void masuk_database_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window data_pegawai = new Window4(idAdmin);
			data_pegawai.Show();
			this.Close();
		}

		private void masuk_database_barang(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window data_barang = new database_barang(idAdmin);
			data_barang.Show();
			this.Close();
		}

		private void database_keuangan(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window data_keuangan = new database_keuangan(idAdmin);
			data_keuangan.Show();
			this.Close();
		}

		private void back_login(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			MessageBoxResult result = MessageBox.Show("Apakah anda yakin akan keluar?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Yes)
			{
   			 // Yes code here
			 Window logout = new Window1();
			 logout.Show();
			 this.Close();
			}
		}

		private void personalisasi(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window personal =new data_personal(idAdmin);
			personal.Show();
			this.Close();
		}

		
	}
}