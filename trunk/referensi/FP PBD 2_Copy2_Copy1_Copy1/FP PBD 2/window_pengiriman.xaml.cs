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
	/// Interaction logic for window_pengiriman.xaml
	/// </summary>
    public partial class window_pengiriman : Window
    {
        string idAdmin;
        koneksi konek;
        string statement;
        List<string> a;

        public window_pengiriman(string id)
        {
            this.InitializeComponent();
            idAdmin = id;
            konek = new koneksi();

            inisialisasi();
            // Insert code required on object creation below this point.
        }
        private void inisialisasi()
        {
            //TRANSAKSI
            id_Transaksi.IsEnabled = false;
            tanggal.IsEnabled = true;
            _event.IsEnabled = true;
            id_combo.IsEnabled = true;
            nama.IsEnabled = true;
            alamat.IsEnabled = true;
            kode_pos.IsEnabled = true;
            layanan.IsEnabled = true;
            asal.IsEnabled = true;
            tujuan.IsEnabled = true;

            konek.Open();
            id_Transaksi.Text = konek.generateID("TR", "transaksi_pengiriman", 0, 3);
            konek.Close();
            tanggal.Text = System.DateTime.Today.ToLongDateString().ToString();
            _event.Text = "";
            //combo pengirim
            a = konek.GetData("select id_customer from pengirim", "id_customer");
            id_combo.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                id_combo.Items.Add(a[i]);
            }
            nama.Text = "";
            alamat.Text = "";
            kode_pos.Text = "";
            //layanan
            a = konek.GetData("select nama_layanan from jenis_layanan", "nama_layanan");
            layanan.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                layanan.Items.Add(a[i]);
            }
            // kota asal dan tujuan
            a = konek.GetData("select nama_kota from kota_pengiriman", "nama_kota");
            asal.Items.Clear();
            tujuan.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                asal.Items.Add(a[i]);
                tujuan.Items.Add(a[i]);
            }

            //PAKET
            id_paket.IsEnabled = false;
            barang_jenis.IsEnabled = false;
            barang_nm.IsEnabled = false;
            barang_harga.IsEnabled = false;
            p.IsEnabled = false;
            l.IsEnabled = false;
            t.IsEnabled = false;
            berat.IsEnabled = false;
            b_insert.IsEnabled = false;
            b_del.IsEnabled = false;
            b_submit.IsEnabled = false;

            konek.Open();
            id_paket.Text = konek.generateID("S", "paket", 0, 3);
            konek.Close();
            // jenis barang		
            a = konek.GetData("select jenis_barang from jenis_barang", "jenis_barang");
            barang_jenis.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                barang_jenis.Items.Add(a[i]);

            }
            barang_nm.Text = "";
            barang_harga.Text = "";
            p.Text = ""; l.Text = ""; t.Text = "";
            berat.Text = "";
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
        private bool cekInput_transaksi()
        {
            if (nama.Text == "") return false;
            if (alamat.Text == "") return false;
            if (kode_pos.Text == "") return false;
            if (layanan.Text == "") return false;
            if (asal.Text == "") return false;
            if (tujuan.Text == "") return false;
            return true;

        }

        private bool cekInput_paket()
        {
            if (barang_jenis.Text == "") return false;
            if (barang_nm.Text == "") return false;
            if (barang_harga.Text == "") return false;
            if (p.Text == "" || l.Text == "" || t.Text == "" || berat.Text == "") return false;
            return true;
        }
        private void masu(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }


        private void back_menu_pegawai(object sender, System.Windows.RoutedEventArgs e)
        {
            if (list_paket.Items.Count == 0)
            {
                MessageBoxResult result = MessageBox.Show("Apakah ingin membatalkan transaksi Pengiriman?", "Tanya", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    statement = "delete from transaksi_pengiriman where id_pengiriman='" + id_Transaksi.Text + "'";
                    executeNonQuery(statement);
                    Window back_menu_pegawai = new Window2(idAdmin);
                    back_menu_pegawai.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Hapus semua data Paket", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void b_insert_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (barang_nm.Text.Length > 20 || barang_harga.Text.Length > 20 || p.Text.Length > 6 || l.Text.Length > 6 || berat.Text.Length > 6)
            {
                System.Windows.MessageBox.Show("Terjadi kesalahan dalam input data", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (cekInput_paket())
                {
                    string jenis = konek.GetData("select id_jenis_barang from jenis_barang where jenis_barang='" + barang_jenis.Text + "'", "id_jenis_barang")[0];

                    statement = "insert into paket values ('" +
                                id_paket.Text + "','" +
                                jenis + "','','" +
                                id_Transaksi.Text + "','" +
                                barang_nm.Text + "','" +
                                p.Text + "','" + l.Text + "','" + t.Text + "','" +
                                berat.Text + "','" +
                                barang_harga.Text + "')";

                    if (executeNonQuery(statement))
                    {
                        MessageBox.Show("Data Berhasil ditambahkan");
                        list_paket.Items.Add(id_paket.Text);
                    }
                    else MessageBox.Show("Data Gagal ditambahkan");
                    konek.Open();
                    id_paket.Text = konek.generateID("S", "paket", 0, 3);
                    konek.Close();
                    barang_jenis.Text = "";
                    barang_nm.Text = "";
                    barang_harga.Text = "";
                    p.Text = ""; l.Text = ""; t.Text = ""; berat.Text = "";

                }
                else MessageBox.Show("Input belum lengkap", "Peringantan", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void to_paket_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (nama.Text.Length > 20 || alamat.Text.Length > 50 || kode_pos.Text.Length > 10)
            {
                System.Windows.MessageBox.Show("Terjadi kesalahan dalam input data", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (cekInput_transaksi())
                {
                    string p_lay = konek.GetData("select id_layanan from jenis_layanan where nama_layanan='" + layanan.Text + "'", "id_layanan")[0];
                    string k_asal = konek.GetData("select kode_kota from kota_pengiriman where nama_kota ='" + asal.Text + "'", "kode_kota")[0];
                    string k_tujuan = konek.GetData("select kode_kota from kota_pengiriman where nama_kota ='" + tujuan.Text + "'", "kode_kota")[0];
                    string bea = "H" + k_asal + k_tujuan;
                    string tgl, bulan, tahun, jam, menit, detik;

                    tgl = System.DateTime.Now.Day.ToString();
                    bulan = System.DateTime.Now.Month.ToString();
                    tahun = System.DateTime.Now.Year.ToString();
                    jam = System.DateTime.Now.Hour.ToString();
                    menit = System.DateTime.Now.Minute.ToString();
                    detik = System.DateTime.Now.Second.ToString();

                    statement = "insert into transaksi_pengiriman values ('" +
                            id_Transaksi.Text + "','" +
                            idAdmin + "','" +
                            p_lay + "','" +
                            bea + "','','" +
                            id_combo.Text + "',to_timestamp('" + tgl + "-" + bulan + "-" + tahun + " " + jam + ":" + menit + ":" + detik + "', 'DD-MM-YY HH24:MI:SS'),'" +
                            nama.Text + "','" +
                            alamat.Text + "','" +
                            kode_pos.Text + "')";

                    
                    //transaksi
                    id_Transaksi.IsEnabled = false;
                    tanggal.IsEnabled = false;
                    _event.IsEnabled = false;
                    id_combo.IsEnabled = false;
                    nama.IsEnabled = false;
                    alamat.IsEnabled = false;
                    kode_pos.IsEnabled = false;
                    layanan.IsEnabled = false;
                    asal.IsEnabled = false;
                    tujuan.IsEnabled = false;

                    //paket
                    id_paket.IsEnabled = false;
                    barang_jenis.IsEnabled = true;
                    barang_nm.IsEnabled = true;
                    barang_harga.IsEnabled = true;
                    p.IsEnabled = true;
                    l.IsEnabled = true;
                    t.IsEnabled = true;
                    berat.IsEnabled = true;
                    b_insert.IsEnabled = true;
                    b_del.IsEnabled = true;
                    b_submit.IsEnabled = true;

                    if (executeNonQuery(statement))
                    {
                        MessageBox.Show("Data Berhasil ditambahkan");
                    }
                    else MessageBox.Show("Data Gagal ditambahkan");


                }
                else MessageBox.Show("Input belum lengkap", "Peringantan", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void b_del_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (list_paket.Items.Count != 0)
            {
                //memilih items paling atas
                string cari = list_paket.Items[0].ToString();
                a.Clear();
                for (int i = 0; i < list_paket.Items.Count; i++)
                {
                    MessageBox.Show(cari);
                    if (i == 0) continue;
                    a.Add(list_paket.Items[i].ToString());
                }
                list_paket.Items.Clear();
                for (int i = 0; i < a.Count; i++)
                {
                    list_paket.Items.Add(a[i]);
                }
                statement = "delete from paket where id_paket='" + cari + "'";
                executeNonQuery(statement);

                konek.Open();
                id_paket.Text = konek.generateID("S", "paket", 0, 3);
                konek.Close();
            }
            else MessageBox.Show("Data Kosong", "Peringantan", MessageBoxButton.OK, MessageBoxImage.Error);



        }

        private void nama_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (nama.Text.Length > 20)
            {
                nama.Background = Brushes.Red;
            }
            else
                nama.Background = Brushes.White;

        }

        private void alamat_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (alamat.Text.Length > 50)
            {
                alamat.Background = Brushes.Red;
            }
            else
                alamat.Background = Brushes.White;

        }

        private void kode_pos_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (kode_pos.Text.Length > 10)
            {
                kode_pos.Background = Brushes.Red;
            }
            else
                kode_pos.Background = Brushes.White;

        }

        private void barang_nm_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (barang_nm.Text.Length > 20)
            {
                barang_nm.Background = Brushes.Red;
            }
            else
                barang_nm.Background = Brushes.White;

        }

        private void barang_harga_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (barang_harga.Text.Length > 20)
            {
                barang_harga.Background = Brushes.Red;
            }
            else
                barang_harga.Background = Brushes.White;


        }

        private void p_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (p.Text.Length > 6)
            {
                p.Background = Brushes.Red;
            }
            else
                p.Background = Brushes.White;

        }

        private void l_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (l.Text.Length > 6)
            {
                l.Background = Brushes.Red;
            }
            else
                l.Background = Brushes.White;

        }

        private void t_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (t.Text.Length > 6)
            {
                t.Background = Brushes.Red;
            }
            else
                t.Background = Brushes.White;

        }

        private void berat_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (berat.Text.Length > 6)
            {
                berat.Background = Brushes.Red;
            }
            else
                berat.Background = Brushes.White;

        }

        private int cek_tahunBaru()
        {
            if ((System.DateTime.Today.Month.ToString()) == "12")
            {

                if ((System.DateTime.Today.Day.ToString()) == "25") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "26") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "27") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "28") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "29") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "30") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "31") return 1;
            }
            else if ((System.DateTime.Today.Month.ToString()) == "1")
            {
                if ((System.DateTime.Today.Day.ToString()) == "1") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "2") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "3") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "4") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "5") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "6") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "7") return 1;
            }
            return 0;
        }

        private int cek_Kemerdekaan()
        {
            if ((System.DateTime.Today.Month.ToString()) == "8")
            {
                if ((System.DateTime.Today.Day.ToString()) == "10") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "11") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "12") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "13") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "14") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "15") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "16") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "17") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "18") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "19") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "20") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "21") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "22") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "23") return 1;
                if ((System.DateTime.Today.Day.ToString()) == "24") return 1;
            }
            return 0;
        }

        private void b_submit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            double berat;
            double layanan;
            double tmbh;
            double bea;
            double total = 0;

            // TODO: Add event handler implementation here.
            MessageBoxResult result = MessageBox.Show("Apakah sudah selesai mengisi data ?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //memastikan event Tahun Baru
                if (cek_tahunBaru() == 1) statement = "update transaksi_pengiriman set id_event = '1' where id_pengiriman = '" + id_Transaksi.Text + "'";

                //memastikan event Kemerdekaan
                else if (cek_Kemerdekaan() == 1) statement = "update transaksi_pengiriman set id_event = '2' where id_pengiriman = '" + id_Transaksi.Text + "'";
                else statement = "update transaksi_pengiriman set id_event = '0' where id_pengiriman = '" + id_Transaksi.Text + "'";


                if (executeNonQuery(statement))
                {
                    MessageBox.Show("Data Berhasil ditambahkan");
                }
                else MessageBox.Show("Data Gagal ditambahkan");
                for (int i = 0; i < list_paket.Items.Count; i++)
                {

                    konek = new koneksi();
                    konek.Open();
                    //getberat
                    //getlayanan
                    //getbiaya_tambahan
                    //bea pengiriman
                    berat = double.Parse(konek.GetData("select berat from paket where id_paket ='" + list_paket.Items[i] + "'", "berat")[0]);
                    layanan = double.Parse(konek.GetData("select lay.nilai_layanan as nlay  from paket p, transaksi_pengiriman tk, jenis_layanan lay where id_paket = '" + list_paket.Items[i] + "' and p.id_pengiriman = tk.id_pengiriman and tk.id_layanan = lay.id_layanan", "nlay")[0]);
                    tmbh = double.Parse(konek.GetData("select b.biaya_tambahan as biaya from paket p, jenis_barang b where p.id_paket = '" + list_paket.Items[i] + "' and p.id_jenis_barang = b.id_jenis_barang", "biaya")[0]);
                    bea = double.Parse(konek.GetData("select b.harga_per_kg as harga from transaksi_pengiriman t, bea_pengiriman b where t.id_bea_pengiriman = b.id_bea_pengiriman and t.id_pengiriman = '" + id_Transaksi.Text + "'", "harga")[0]);
                    konek.Close();
                    total = total + (berat * bea) + tmbh + (berat * bea) * layanan;

                }
                MessageBox.Show("Harga Total : " + total.ToString(), "Pembayaran Total : ", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            //MessageBox.Show("Keluarin Report Harga");
            Window report = new report_pengiriman(idAdmin, id_Transaksi.Text);
            report.Show();
            this.Close();

        }
    }
}