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
	/// Interaction logic for window_tracking_customer.xaml
	/// </summary>
	public partial class window_tracking_customer : Window
	{
        string idAdmin;
        koneksi konek;
        string statement;
        DataSet ds;
        List<string> a;
        
		public window_tracking_customer(string id)
		{
			this.InitializeComponent();
            konek = new koneksi();
            
            idAdmin = id;
            ds = new DataSet();
            inisialisasi();
            
			// Insert code required on object creation below this point.
		}

        private void inisialisasi()
        {
            if (idAdmin != "")
            {
                a = konek.GetData("select id_pengiriman from transaksi_pengiriman where id_customer = '" + idAdmin + "'", "id_pengiriman");
                combo_paket.Items.Clear();
                for (int i = 0; i < a.Count; i++)
                {
                    combo_paket.Items.Add(a[i]);
                }
            }
            else System.Windows.MessageBox.Show("Error", "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void back_customer(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back_menu_customer =new Window3(idAdmin);
			back_menu_customer.Show();
			this.Close();
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

        private void lihat_Click(object sender, RoutedEventArgs e)
        {
            if (combo_paket.Text != "")
            {
                executeDataSet("select p.nama_pegawai,t.tanggal_tracking,t.alat_angkut,t.lokasi_tracking, t.keterangan_tracking from tracking t, pegawai p where t.id_pengiriman = '"+combo_paket.Text+"' and t.id_pegawai= p.id_pegawai order by t.id_tracking", DataGridView);
            }
            else System.Windows.MessageBox.Show("Pilih Transaksi Pengiriman", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			Window report = new report_tracking(idAdmin, combo_paket.Text);
			report.Show();
			this.Close();
        }
	}
}