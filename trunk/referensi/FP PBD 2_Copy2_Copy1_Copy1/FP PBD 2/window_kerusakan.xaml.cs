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

namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for window_kerusakan.xaml
	/// </summary>
	public partial class window_kerusakan : Window
	{
        string idAdmin;
        string kirim="";
		string statement;
        koneksi konek;
        List<string> a;
       
		public window_kerusakan(string id)
		{
            
            idAdmin = id;
			this.InitializeComponent();
            konek = new koneksi();
            
            keterangan.Text = "";
            no_transaksi.Text = "";

            a = konek.GetData("select id_pengiriman from tracking where keterangan_tracking = 'Rusak' and id_pegawai ='"+ idAdmin +"'", "id_pengiriman");
            no_transaksi.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                no_transaksi.Items.Add(a[i]);
            }
            pegawai.Text = idAdmin;
            //generate id_tracking
            konek.Open();
            no_surat.Text = konek.generateID("L", "laporan_kerusakan_barang", 0, 3);
			
            konek.Close();
            tanggal.Content = System.DateTime.Now.ToLongDateString().ToString();
			

		}

		private void back_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back_menu_pegawai =new Window2(idAdmin);
			back_menu_pegawai.Show();
			this.Close();
		}
	}
}