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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
        koneksi konek;
        string statement;
		
        DataSet ds;
        
		public Window1()
		{
            ds = new DataSet();
            this.InitializeComponent();
            fill_combo();
            konek = new koneksi();
            //MessageBox.Show(System.DateTime.Today.ToShortDateString());
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

		private void PsdLayer1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.DragMove();
		}

		private void exit(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            konek.Open();
            Ascii85 a = new Ascii85();
            string s = passwordBox.Password;
            byte[] ba = Encoding.ASCII.GetBytes(s);
            string encoded = a.Encode(ba);
            OracleDataReader reader;

            /*-----------------------------*/
            //user_name.Text = "K002";
            //passwordBox.Password = "2";
            //s = passwordBox.Password;
            //Login_sebagai.Text = "Karyawan";
            /*----------------------------*/

            int jabatan;
            if (user_name.Text!="" && Login_sebagai.Text!="")
            {
                if (Login_sebagai.Text == "Administrator" || Login_sebagai.Text == "Karyawan")
                {
                    if (Login_sebagai.Text == "Administrator") jabatan = 0;
                    else jabatan = 1;
                    statement = "select password_pegawai from pegawai where id_pegawai = '" + user_name.Text + "' and id_Jabatan = '" + jabatan + "' and id_status ='1'";
                    reader = konek.ExecuteReader(statement);
                    reader.Read();
                    if (!reader.HasRows)
                        MessageBox.Show("ID Name dan Password tidak valid", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        if (encoded == reader.GetString(0) && jabatan ==0)
                        {
                            MessageBox.Show("SELAMAT ADMIN MASUK", "Informasi", MessageBoxButton.OK, MessageBoxImage.Information);
                            Window admin = new menu_adminxaml(user_name.Text);
                            admin.Show();
                            konek.Close();
                            this.Close();
                        }
                        else if (encoded == reader.GetString(0) && jabatan == 1)
                        {
                            MessageBox.Show("SELAMAT KARYAWAN MASUK", "Informasi", MessageBoxButton.OK, MessageBoxImage.Information);
                            Window karyawan = new Window2(user_name.Text);
                            karyawan.Show();
                            konek.Close();
                            this.Close();
                        }
                        else MessageBox.Show("ID Name dan Password tidak valid", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (Login_sebagai.Text == "Anggota")
                {
                    statement = "select password_customer from pengirim where id_customer = '" + user_name.Text + "'";
                    //MessageBox.Show(statement);
                    reader = konek.ExecuteReader(statement);
                    reader.Read();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("ID Name dan Password tidak valid", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (encoded == reader.GetString(0))
                        {
                            MessageBox.Show("SELAMAT User MASUK", "Informasi", MessageBoxButton.OK, MessageBoxImage.Information);
                            Window user = new Window3(user_name.Text);
                            user.Show();
                            konek.Close();
                            this.Close();
                        }
                        else MessageBox.Show("ID Name dan Password tidak valid", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else MessageBox.Show("ID Name dan Password tidak valid", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            konek.Close();
            
		}

		private void exit_app(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			MessageBoxResult result = MessageBox.Show("Apakah anda yakin akan keluar?", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Yes)
			{
			this.Close();
			}
		}

        private void fill_combo()
        {
            Login_sebagai.Items.Add("Administrator");
            Login_sebagai.Items.Add("Karyawan");
            Login_sebagai.Items.Add("Anggota");
        }
    }
}