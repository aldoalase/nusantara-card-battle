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
	/// Interaction logic for notification.xaml
	/// </summary>
	public partial class Notification : Window
	{
        public Notification(String _msg)
		{
			this.InitializeComponent();
            pesan.Text = _msg;
		}

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}