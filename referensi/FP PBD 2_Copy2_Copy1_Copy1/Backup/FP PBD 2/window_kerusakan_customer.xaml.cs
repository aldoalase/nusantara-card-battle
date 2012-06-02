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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Data;

namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for window_kerusakan_customer.xaml
	/// </summary>
	public partial class window_kerusakan_customer : Window
	{
        string idAdmin;
        koneksi konek;
        DataSet ds;
		public window_kerusakan_customer(string id)
		{
			this.InitializeComponent();
            idAdmin = id;
            ds = new DataSet();
            konek = new koneksi();
            List<string> a;
            a = konek.GetData("select id_paket from paket where no_laporan_kerusakan is not null", "id_paket");
            id_paket.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                id_paket.Items.Add(a[i]);
            }

            
			// Insert code required on object creation below this point.
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

        private bool executeDataSet(string sql, DataGridView DGV)
        {
            konek = new koneksi();
            if (konek.Open())
            {
                DGV.AutoGenerateColumns = true;
                ds = konek.ExecuteDataSet(sql);
                if (ds == null) return false;
                DGV.DataSource = ds;
                DGV.DataMember = "result";
                konek.Close();
                return true;
            }
            return false;
        }
        private void fresh()
        {
            executeDataSet("select id_pengiriman, tanggal_tracking, alat_angkut, lokasi_tracking, keterangan_tracking from tracking where id_pegawai ='" + idAdmin + "'", DataGridView);
        }
        private void back_customer(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back_menu_customer =new Window3(idAdmin);
			back_menu_customer.Show();
			this.Close();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.

			Window report_kerusakan = new report_kerusakan(idAdmin, id_paket.Text);
			report_kerusakan.Show();
			this.Close();
		}

        private void lihat_Click(object sender, RoutedEventArgs e)
        {
            fresh();
        }
	}
}