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
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window
	{
  
        string idAdmin;
        int login;
        string statement;
		public Window2(string id)
		{
            idAdmin = id;
            
			this.InitializeComponent();
            
        
            
			
			// Insert code required on object creation below this point.
		}

		private void exit(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.Close();
		}

		private void move(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.DragMove();
		}

		private void window_pengiriman(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window pengiriman = new window_pengiriman(idAdmin);
			pengiriman.Show();
			this.Close();
		}

		private void window_penjualan(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window penjualan =new window_penjualan(idAdmin);
			penjualan.Show();
			this.Close();
		}

		private void window_tracking(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window tracking =new window_tracking(idAdmin);
			tracking.Show();
			this.Close();
		}

		private void window_kerusakan(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window kerusakan =new window_kerusakan(idAdmin);
			kerusakan.Show();
			this.Close();
		}

		private void logout_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			MessageBoxResult result = MessageBox.Show("Apakah anda yakin akan keluar?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Yes)
			{
   			 // Yes code here
			 Window logout = new Window1();
			 logout.Show();
			 this.Close();
			}
		}

		private void button_database_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window database_customer = new database_customer(idAdmin);
			database_customer.Show();
			this.Close();
			
		}

		private void edit_personal(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window personal_pegawai = new data_personal_pegawai(idAdmin);
			personal_pegawai.Show();
			this.Close();
		}
	}
}