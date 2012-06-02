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
	/// Interaction logic for window_penjualan.xaml
	/// </summary>
	public partial class window_penjualan : Window
	{
        string idAdmin;
		koneksi konek;
        string statement;
        string id_struk;
        DataSet ds;
        List<string> a,b;
        public DataTable tabel;
        string tgl, bulan, tahun, jam, menit, detik;

        
		public window_penjualan(string id)
		{
			this.InitializeComponent();
            idAdmin = id;
            
			ds = new DataSet();
            konek = new koneksi();         
            inisialisasi();
    		// Insert code required on object creation below this point.
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
		
		 private void inisialisasi()
        {
           
            //combo id barang pos
            a = konek.GetData("select id_barang_pos, nama_barang_pos from barang_pos", "id_barang_pos");   
            id_barang.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                id_barang.Items.Add(a[i]);
            }
            jum.Text = "";
            Total.Text = "0";
            Total.IsEnabled = false;
            Lunas.IsEnabled = false;


            //generate id_struk
            konek.Open();
            id_struk= konek.generateID("TB", "Transaksi_pembelian", 0, 3);
            struk.Content = "Struk No : " +  id_struk;
            konek.Close();

            //tanggal Transaksi
            tanggal.Content = System.DateTime.Now.ToLongDateString().ToString();
            
            //membuat transaksi pembelian baru
            tabel = new DataTable();
            tabel.Columns.Add("ID Barang", typeof(String));
            tabel.Columns.Add("Nama_Barang", typeof(String));
            tabel.Columns.Add("Harga@Barang", typeof(String));
            tabel.Columns.Add("Jumlah pembelian", typeof(String));
            
            

            tgl = System.DateTime.Now.Day.ToString();
            bulan = System.DateTime.Now.Month.ToString();
            tahun = System.DateTime.Now.Year.ToString();
            jam = System.DateTime.Now.Hour.ToString();
            menit = System.DateTime.Now.Minute.ToString();
            detik = System.DateTime.Now.Second.ToString();
            statement = "insert into transaksi_pembelian values ('" +
                         id_struk + "','" +
                         idAdmin + "',to_timestamp('" + tgl + "-" + bulan + "-" + tahun + " " + jam + ":" + menit + ":" + detik + "', 'DD-MM-YY HH24:MI:SS'))";
            executeNonQuery(statement);
        }
		
		



		private void b_tambah_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			int stok= int.Parse(konek.GetData("select stok from barang_pos where id_barang_pos ='"+ id_barang.Text+"'","stok")[0]);

            if (stok >= int.Parse(jum.Text))
            {
                if (id_barang.Text != "" && jum.Text != "")
                {
                    DataRow dr = tabel.NewRow();
                    dr[0] = id_barang.Text;
                    dr[1] = konek.GetData("select nama_barang_pos from barang_pos where id_barang_pos = '" + id_barang.Text + "'", "nama_barang_pos")[0];
                    dr[2] = konek.GetData("select harga_barang_pos from barang_pos where id_barang_pos = '" + id_barang.Text + "'", "harga_barang_pos")[0];
                    dr[3] = jum.Text;
                    tabel.Rows.Add(dr);
                    DataGridView.AutoGenerateColumns = true;
                    DataGridView.DataSource = tabel.DefaultView;
                }
                else System.Windows.MessageBox.Show("Data Kurang Lengkap", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else System.Windows.MessageBox.Show("Stok hanya =" + stok + ". Harap mengurangi jumlah pembelian Anda", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
          
			
		}

		private void b_finish_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			int sub_total = 0;
            MessageBoxResult result = System.Windows.MessageBox.Show("Apakah isian sudah benar ?", "Tanya", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < DataGridView.Rows.Count - 1; i++)
                {
                    
                    statement = "insert into detail_barang_pos values ('" +
                                id_struk + "','" +
                                DataGridView[0, i].Value.ToString().Trim() + "','" +
                                DataGridView[3, i].Value.ToString().Trim() + "')";
                    executeNonQuery(statement);
                    statement = "update barang_pos set stok = stok - " +
                                  DataGridView[3, i].Value.ToString().Trim() + " where id_barang_pos = '" +
                                  DataGridView[0, i].Value.ToString().Trim() + "'";
                    executeNonQuery(statement);
                    sub_total = sub_total + (int.Parse(DataGridView[2, i].Value.ToString().Trim()) * int.Parse(DataGridView[3, i].Value.ToString().Trim()));
                }
                Total.Text = sub_total.ToString();
				total_pembayaran.Content = sub_total.ToString();
				
            }

            button.IsEnabled = false;
            DataGridView.Enabled = false;
            jum.IsEnabled = false;
            id_barang.IsEnabled = false;
            b_finish.IsEnabled = false;
            b_tambah.IsEnabled = false;
            Lunas.IsEnabled = true;
		}

		private void Lunas_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window rpt_penjualan = new report_pembelian(idAdmin,id_struk);
			rpt_penjualan.Show();
			this.Close();
			
		}

		private void back_penjualan(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			 MessageBoxResult result = System.Windows.MessageBox.Show("Apakah ingin membatalkan transaksi Pengiriman?","Tanya",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                statement = "delete from transaksi_pembelian where id_struk='" + id_struk + "'";
                executeNonQuery(statement);
                Window back_menu_pegawai = new Window2(idAdmin);
                back_menu_pegawai.Show();
                this.Close();

            }

		}
	}
}