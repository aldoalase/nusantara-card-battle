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
	/// Interaction logic for database_keuangan.xaml
	/// </summary>
	public partial class database_keuangan : Window
	{
        string idAdmin;
        
		public database_keuangan(string id)
		{
			this.InitializeComponent();
            idAdmin = id;
            
			// Insert code required on object creation below this point.
		}

		private void back_admin(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window back = new menu_adminxaml(idAdmin);
			back.Show();
			this.Close();
		}
	}
}