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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Oracle.DataAccess.Client;



namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for database_barang.xaml
	/// </summary>
	public partial class database_barang : Window
	{
        string idAdmin;
        koneksi konek;
        string statement;
        DataSet ds;
        List<string> a;
 
		public database_barang(string id)
		{
            ds = new DataSet();
			this.InitializeComponent();
            konek = new koneksi();
           
            idAdmin = id;
            inisialisasi();
            
			
		}

		private void back_admin(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back = new menu_adminxaml(idAdmin);
			back.Show();
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
            /*generate ID*/
            idBarang.Text = konek.generateID("B", "barang_pos", 0, 3);
            konek.Close();
            fresh();
            /*reset password*/
            nmBarang.Text = "";
            hrgBarang.Text = "";
            stokBarang.Text = "";
            
            /*inisialisasi edit*/
            e_nm_barang.Text = "";
            e_stok_barang.Text = "";
            e_harga_barang.Text = "";

            a = konek.GetData("select id_barang_pos from barang_pos", "id_barang_pos");
            idlist.Items.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                idlist.Items.Add(a[i]);
            }
        }

        
        private void fresh()
        {
            executeDataSet("Select * from barang_pos", DataGridView);
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {

            if (nmBarang.Text.Length > 20 || hrgBarang.Text.Length > 20 || stokBarang.Text.Length > 10)
			{
				System.Windows.MessageBox.Show("Terjadi kesalahan dalam input data", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			else
			{
				statement = "insert into barang_pos values ('" +
							idBarang.Text + "','" +
							nmBarang.Text + "','" +
							hrgBarang.Text + "','" +
							stokBarang.Text +"')";
				
				if (executeNonQuery(statement))
				{
					System.Windows.MessageBox.Show("Data Berhasil ditambahkan");
	
				}
				else System.Windows.MessageBox.Show("Data Gagal ditambahkan");
				inisialisasi();
			}
        
        }

        private void reet_Click(object sender, RoutedEventArgs e)
        {
            inisialisasi();
        }


        private void view_Click(object sender, RoutedEventArgs e)
        {
            string data = idlist.SelectedItem.ToString();
            e_nm_barang.Text = konek.GetData("select nama_barang_pos from barang_pos where id_barang_pos = '" + data + "'", "nama_barang_pos")[0];
            e_harga_barang.Text = konek.GetData("select harga_barang_pos from barang_pos where id_barang_pos = '" + data + "'", "harga_barang_pos")[0];
            e_stok_barang.Text = konek.GetData("select stok from barang_pos where id_barang_pos = '" + data + "'", "stok")[0];
            
        }

        private void e_edit_Click(object sender, RoutedEventArgs e)
        {
            if (e_nm_barang.Text.Length > 20 || e_harga_barang.Text.Length > 20 || e_stok_barang.Text.Length > 20)
			{
				System.Windows.MessageBox.Show("Terjadi kesalahan dalam input data", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			else
			{
				statement = "update barang_pos set nama_barang_pos ='" +
							e_nm_barang.Text + "', harga_barang_pos ='" +
							e_harga_barang.Text + "', stok ='" +
							e_stok_barang.Text + "' where id_barang_pos = '"+idlist.SelectedItem.ToString()+"'";
				
				if (executeNonQuery(statement))
				{
					System.Windows.MessageBox.Show("Data Berhasil diubah");
	
				}
				else System.Windows.MessageBox.Show("Data Gagal diubah");
				inisialisasi();
			}
        }

        private void e_del_Click(object sender, RoutedEventArgs e)
        {
            statement = "update barang_pos set stok = 0 where id_barang_pos = '" + idlist.SelectedItem.ToString() + "'";

            if (executeNonQuery(statement))
            {
                System.Windows.MessageBox.Show("Data Berhasil diubah");

            }
            else System.Windows.MessageBox.Show("Data Gagal diubah");
            inisialisasi();
        }

        private void e_reset_Click(object sender, RoutedEventArgs e)
        {
            inisialisasi();
        }

        private void nmBarang_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (nmBarang.Text.Length > 20)
			{
				nmBarang.Background = Brushes.Red;
			}
			else
				nmBarang.Background = Brushes.White;
			
        }

        private void hrgBarang_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (hrgBarang.Text.Length > 50)
			{
				hrgBarang.Background = Brushes.Red;
			}
			else
				hrgBarang.Background = Brushes.White;
        }

        private void stokBarang_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (stokBarang.Text.Length > 10)
			{
				stokBarang.Background = Brushes.Red;
			}
			else
				stokBarang.Background = Brushes.White;
        }

        private void e_nm_barang_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (e_nm_barang.Text.Length > 20)
			{
				e_nm_barang.Background = Brushes.Red;
			}
			else
				e_nm_barang.Background = Brushes.White;
        }

        private void e_harga_barang_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (e_harga_barang.Text.Length > 20)
			{
				e_harga_barang.Background = Brushes.Red;
			}
			else
				e_harga_barang.Background = Brushes.White;
        }

        private void e_stok_barang_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (e_stok_barang.Text.Length > 20)
			{
				e_stok_barang.Background = Brushes.Red;
			}
			else
				e_stok_barang.Background = Brushes.White;
        }

	}
}