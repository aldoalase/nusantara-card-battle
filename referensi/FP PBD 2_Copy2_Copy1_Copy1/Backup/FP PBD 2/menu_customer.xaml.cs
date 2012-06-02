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
	/// Interaction logic for Window3.xaml
	/// </summary>
	public partial class Window3 : Window
	{
        string idCustomer;
       
        string statement;
		public Window3(string id)
		{
            idCustomer = id;
			this.InitializeComponent();
            person.IsEnabled = false;
            
            
			
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

		private void window_tracking_pegawai(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window tracking_customer =new window_tracking_customer(idCustomer);
			tracking_customer.Show();
			this.Close();
		}

		private void window_kerusakan_customer(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window kerusakan_customer =new window_kerusakan_customer(idCustomer);
			kerusakan_customer.Show();
			this.Close();
		}

		private void logout_customer(object sender, System.Windows.RoutedEventArgs e)
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

		private void personal(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			MessageBox.Show(idCustomer);
			/*Window edit_personal = new percobaan(idCustomer,login);
			edit_personal.Show();
			this.Close();*/
		}

	}
}