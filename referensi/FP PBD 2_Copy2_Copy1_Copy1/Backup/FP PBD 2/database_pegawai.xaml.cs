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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        string idAdmin;
        string path;
        koneksi konek;
        string statement;
        DataSet ds;
        List<string> a;
        
        public Window4(string id)
        {
            ds = new DataSet();
            this.InitializeComponent();
            konek = new koneksi();
            idAdmin = id;
            
            inisialisasi();

        }

        private void inisialisasi()
        {
            /*generate ID*/
            user_name.Text = konek.generateID("K", "Pegawai", 0, 3);
            konek.Close();

            /*mengisi combobox.posisi*/
            a = konek.GetData("select nama_jabatan from jabatan","nama_jabatan");
            e_naikjabatan.Items.Clear();
            posisi.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                e_naikjabatan.Items.Add(a[i]);
                posisi.Items.Add(a[i]);

            }


            /*reset text*/
            nm_pegawai.Text = "";
            pass.Text = "";
            alamat.Text = "";
            no_telp.Text = "";
            posisi.Text = "";

            inisialisasi_edit();

        }

        private void inisialisasi_edit()
        {
            /*inisialisasi Text*/
            e_alamat.Text = "";
            e_jabatan.Text = "";
            e_nm_pegawai.Text = "";
            e_telpon.Text = "";
            e_jabatan.Text = "";
            e_tgl_masuk.Text = "";
            e_jabatan.IsEnabled = false;
            e_naikjabatan.IsEnabled = false;
            combo_pegawai.Text = "";

            /*reset tombol*/
            r_pass.IsEnabled = false;
            ganti.IsEnabled = false;
            b_delete.IsEnabled = false;
            b_edit.IsEnabled = false;
            b_photo.IsEnabled = false;
            b_reset.IsEnabled = false;

            /*isi Combo Edit*/
            a = konek.GetData("select id_pegawai from pegawai where id_status = 1","id_pegawai");
            combo_pegawai.Items.Clear();
            konek.Open();
            for (int i = 0; i < a.Count; i++)
            {
                combo_pegawai.Items.Add(a[i]);
            }
            konek.Close();

        }

        private void back(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Window back_admin = new menu_adminxaml(idAdmin);
            back_admin.Show();
            this.Close();
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


        /*TAB CONTROL : INSERT*/
        private void insert_b_Click(object sender, RoutedEventArgs e)
        {
            if (nm_pegawai.Text.Length > 20 || alamat.Text.Length > 50 || no_telp.Text.Length > 20)
			{
				System.Windows.MessageBox.Show("Terjadi kesalahan dalam input data", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			else
			{
				konek.Open();
				Ascii85 a = new Ascii85();
				string s = pass.Text;
				byte[] ba = Encoding.ASCII.GetBytes(s);
				string encoded = a.Encode(ba);
				string date = System.DateTime.Today.ToShortDateString();
	
				int jabatan;
				if (posisi.Text == "ADMINISTRATOR") jabatan = 0;
				else if (posisi.Text == "KARYAWAN") jabatan = 1;
				else jabatan = -1;
	
				statement = "insert into pegawai values ('" +
							user_name.Text + "',1," +
							jabatan + ",'" +
							nm_pegawai.Text + "','" +
							alamat.Text + "','" +
							no_telp.Text + "','" +
							encoded + "',empty_blob(),to_date('" +
							date + "','MM-DD-YY'),'',0)";
				
				if (executeNonQuery(statement))
				{
					MessageBox.Show("Data Berhasil ditambahkan");
					konek.Open();
					konek.InsertBlob("update pegawai set picture_pegawai = :BlobParameter where id_pegawai = '" + user_name.Text + "'", path);
					konek.Close();
	
				}
				else MessageBox.Show("Data Gagal ditambahkan");
	
				inisialisasi();
			}
        }

        private void reset_b_Click(object sender, RoutedEventArgs e)
        {
            inisialisasi();
        }

        private void up_foto_Click(object sender, RoutedEventArgs e)
        {
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

        /*TAB CONTROL : EDIT*/
        private void lihat_Click(object sender, RoutedEventArgs e)
        {
            if (combo_pegawai.Text != "")
            {
                //MessageBox.Show(combo_pegawai.Text);
                e_nm_pegawai.Text = konek.GetData("select nama_pegawai from pegawai where id_pegawai ='" + combo_pegawai.Text + "'","nama_pegawai")[0];
                e_alamat.Text = konek.GetData("select alamat_pegawai from pegawai where id_pegawai ='" + combo_pegawai.Text + "'","alamat_pegawai")[0];
                e_telpon.Text = konek.GetData("select no_telp_pegawai from pegawai where id_pegawai ='" + combo_pegawai.Text + "'","no_telp_pegawai")[0];
                e_tgl_masuk.Text = konek.GetData_date("select tgl_masuk from pegawai where id_pegawai ='" + combo_pegawai.Text + "'")[0];
                e_jabatan.Text = konek.GetData("select jabatan.nama_jabatan as nama_jabatan from pegawai, jabatan where id_pegawai = '" + combo_pegawai.Text + "' and pegawai.id_jabatan = jabatan.id_jabatan","nama_jabatan")[0];

                /*set tombol*/
                r_pass.IsEnabled = true;
                ganti.IsEnabled = true;
                b_delete.IsEnabled = true;
                b_edit.IsEnabled = true;
                b_photo.IsEnabled = true;
                b_reset.IsEnabled = true;

                showPhoto();


            }
            else MessageBox.Show("Silahkan Isi Data Terlebih dahulu", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void b_reset_Click(object sender, RoutedEventArgs e)
        {
            inisialisasi();
        }

 

        private void ganti_Click(object sender, RoutedEventArgs e)
        {
            e_jabatan.IsEnabled = true;
            e_jabatan.Text = e_naikjabatan.Text;
            e_naikjabatan.IsEnabled = true;
            e_jabatan.IsEnabled = false;
        }

        private void r_pass_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Apakah ingin me-reset password??", "Tanya", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Ascii85 a = new Ascii85();
                string s = combo_pegawai.Text;
                byte[] ba = Encoding.ASCII.GetBytes(s);
                string encoded = a.Encode(ba);
                
                konek.Open();
                statement = "update pegawai set password_pegawai = '" + encoded + "' where id_pegawai ='" + combo_pegawai.Text + "'";
                if (executeNonQuery(statement))
                    MessageBox.Show("Data Diganti");
                else MessageBox.Show("Data Gagal");
                konek.Close();
                MessageBox.Show("Password Berhasil di Reset", "Hasil", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            int jabatan;
            if (e_jabatan.Text == "KARYAWAN") jabatan = 1;
            else if (e_jabatan.Text == "ADMINISTRATOR") jabatan = 0;
            else jabatan = -1;

            statement = "update pegawai set nama_pegawai = '"
                + e_nm_pegawai.Text + "', no_telp_pegawai ='"
                + e_telpon.Text + "', id_jabatan = "
                + jabatan + ", alamat_pegawai = '"
                + e_alamat.Text + "' where id_pegawai = '" + combo_pegawai.Text + "'";
            
            if (executeNonQuery(statement))
            {
                MessageBox.Show("Data berhasil diganti");
                konek.Open();
                konek.InsertBlob("update pegawai set picture_pegawai = :BlobParameter where id_pegawai = '" + combo_pegawai.Text + "'", path);
                konek.Close();
            }
            else MessageBox.Show("Data tidak berhasil diganti");
        }

        private void b_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Apakah mau memberhentikan pegawai ini ?", "Peringatan", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string date = System.DateTime.Today.ToLongDateString().ToString();
                statement = "update pegawai set id_status = 0, tgl_keluar = to_date('" + System.DateTime.Today.ToShortDateString().ToString() + "','DD/MM/YYYY') where id_pegawai = '" + combo_pegawai.Text + "'";
                MessageBox.Show(statement);
                if (executeNonQuery(statement))
                {
                    MessageBox.Show("Instruksi berhasil dilaksanakan");
                }
                else MessageBox.Show("Error", "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else MessageBox.Show("Permintaan Dibatalkan", "Informasi", MessageBoxButton.OK, MessageBoxImage.Information);

        }


        private void b_photo_Click(object sender, RoutedEventArgs e)
        {
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
                e_pic.Source = img;
            }
        }

        private void showPhoto()
        {
            konek.Open();
            statement = "begin select picture_pegawai into :blob from pegawai where id_pegawai ='" + combo_pegawai.Text + "'; end;";
            e_pic.Source = konek.ShowBlob(statement);
            konek.Close();
        }

        private void nm_pegawai_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (nm_pegawai.Text.Length > 20)
			{
				nm_pegawai.Background = Brushes.Red;
			}
			else
				nm_pegawai.Background = Brushes.White;
        }

        private void pass_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (pass.Text.Length > 20)
			{
				pass.Background = Brushes.Red;
			}
			else
				pass.Background = Brushes.White;
        }

        private void alamat_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (alamat.Text.Length > 50)
			{
				alamat.Background = Brushes.Red;
			}
			else
				alamat.Background= Brushes.White;
        }

        private void no_telp_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (no_telp.Text.Length > 20)
			{
				no_telp.Background = Brushes.Red;
			}
			else
				no_telp.Background = Brushes.White;
        }

        private void e_nm_pegawai_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (e_nm_pegawai.Text.Length > 20)
			{
				e_nm_pegawai.Background = Brushes.Red;
			}
			else
				e_nm_pegawai.Background = Brushes.White;
        }

        private void e_alamat_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (e_alamat.Text.Length > 20)
			{
				e_alamat.Background = Brushes.Red;
			}
			else
				e_alamat.Background = Brushes.White;
        }

        private void e_telpon_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (e_telpon.Text.Length > 20)
			{
				e_telpon.Background = Brushes.Red;
			}
			else
				e_telpon.Background = Brushes.White;
        }
		

       
        





    }
}