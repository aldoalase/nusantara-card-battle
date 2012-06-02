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
	/// Interaction logic for coba_koneksi.xaml
	/// </summary>
	public partial class coba_koneksi : Window
	{
		Koneksi konek = new Koneksi();
		public coba_koneksi()
		{
			this.InitializeComponent();
			
			
			// Insert code required on object creation below this point.
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			konek.Open();
			OracleDataReader reader = konek.ExecuteReader ("select NAMA_PEGAWAI from PEGAWAI where ID_PEGAWAI = 'K001'" );
			if (!reader.HasRows) 
				MessageBox.Show("Kosong");
			else
				while (reader.Read())
					text1.Text= (reader.GetString(0));
				
				
			
		}
	}
}