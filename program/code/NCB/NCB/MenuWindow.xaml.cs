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

namespace NCB
{
	/// <summary>
	/// Interaction logic for MenuWindow.xaml
	/// </summary>
	public partial class MenuWindow : Window
	{
		public MenuWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void doLogout(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
			Window login = new LoginWindow();
			login.Show();
		}
	}
}