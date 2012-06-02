using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Shapes;

namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for window_tracking.xaml
	/// </summary>
	public partial class window_tracking : Window
	{
        string idAdmin;
        koneksi konek;
        string statement;
        DataSet ds;
        List<string> a;
        
		public window_tracking(string id)
		{
            ds = new DataSet();
			this.InitializeComponent();
            konek = new koneksi();
           
            idAdmin = id;
            inisialisasi();
			
			// Insert code required on object creation below this point.
		}
        private void inisialisasi()
        {
            //generate id_tracking
            konek.Open();
            idtracking.Content = konek.generateID("T", "Tracking", 0, 3);
            konek.Close();

            tanggal.Content = System.DateTime.Now.ToLongDateString().ToString();

            //combo idpengiriman
            a = konek.GetData("select id_pengiriman from(select t1.id_pengiriman,t2.* from transaksi_pengiriman t1 left outer join (select id_pengiriman as kirim from tracking where keterangan_tracking != 'Proses') t2  on t1.id_pengiriman = t2.kirim) where kirim is null order by id_pengiriman","id_pengiriman");
            idpengiriman.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                idpengiriman.Items.Add(a[i]);
            }
            alatangkut.Items.Add("Mobil");
            alatangkut.Items.Add("Motor");
            alatangkut.Items.Add("Kereta Api");
            alatangkut.Items.Add("Pesawat");

            lokasi.Text = "";
            keterangan.Text = "";
            keterangan.Items.Add("Sampai Tujuan");
            keterangan.Items.Add("Proses");
            keterangan.Items.Add("Rusak");
          
            DataGridView.Enabled = false;
            fresh();
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
            executeDataSet("select id_pengiriman, tanggal_tracking, alat_angkut, lokasi_tracking, keterangan_tracking from tracking where id_pegawai ='"+ idAdmin +"'", DataGridView);
        }
		
		private void back_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back_menu_pegawai =new Window2(idAdmin);
			back_menu_pegawai.Show();
			this.Close();
		}
		
        private bool cekInput()
        {
            if (idpengiriman.Text == "") return false;
            if (alatangkut.Text == "") return false;
            if (lokasi.Text == "") return false;
            if (keterangan.Text == "") return false;
            return true;
        }
		
        private void b_insert_Click(object sender, RoutedEventArgs e)
        {
            if (cekInput())
            {
                statement = "insert into tracking values ('" +
                            idtracking.Content + "','" +
                            idAdmin + "','" +
                            idpengiriman.Text + "',sysdate,'" +
                            alatangkut.Text + "','" +
                            lokasi.Text + "','" +
                            keterangan.Text + "')";
                System.Windows.MessageBox.Show(statement);
                executeNonQuery(statement);
                Window back_menu_pegawai = new Window2(idAdmin);
                back_menu_pegawai.Show();
                this.Close();

            }
            else System.Windows.MessageBox.Show("Data Kurang Lengkap", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void lihat_Click(object sender, RoutedEventArgs e)
        {
            int limit;
            int limit_lay;
            tujuan.Content = konek.GetData("select k.nama_kota as nama_kota from transaksi_pengiriman t , bea_pengiriman b,kota_pengiriman k where t.id_bea_pengiriman = b.id_bea_pengiriman and b.tujuan = k.kode_kota and t.id_pengiriman = '"+ idpengiriman.Text+"'","nama_kota")[0];
            Layanan.Content= konek.GetData("select l.nama_layanan as lay from transaksi_pengiriman t, jenis_layanan l where t.id_layanan = l.id_layanan and t.id_pengiriman = '"+idpengiriman.Text+"'","lay")[0];
            
            if (Layanan.Content.ToString() =="BIASA") limit_lay = 3;
            else if (Layanan.Content.ToString()=="EXPRESS") limit_lay = 2;
            else if (Layanan.Content.ToString()=="KILAT") limit_lay = 1;
            else limit_lay = -1;

            limit = limit_lay + int.Parse(konek.GetData("select to_char(tanggal_transaksi,'DD')as tgl from transaksi_pengiriman where id_pengiriman = '"+idpengiriman.Text+"'","tgl")[0]);
            if (System.DateTime.Now.Day < limit) deadline.Content= "MELEBIHI DEADLINE";
            else deadline.Content= limit.ToString();
            
            executeDataSet("select id_pengiriman, tanggal_tracking, alat_angkut, lokasi_tracking, keterangan_tracking from tracking where id_pengiriman ='"+ idpengiriman.Text +"'", DataGridView);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            fresh();
        }
    }
}