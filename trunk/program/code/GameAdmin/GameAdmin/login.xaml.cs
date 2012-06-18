using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;
using MySql.Data.MySqlClient;
using System.Collections;
using GameAdmin.Model;

namespace GameAdmin
{
	/// <summary>
	/// Interaction logic for login.xaml
	/// </summary>
	public partial class login : Window
	{
		public login()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void loginButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			  ModelPlayer mp = new ModelPlayer();
            List<Player> players = mp.loginAdmin(loginBox.Text, passwordBox.Password);
            if (players.Count == 1 && addRadio.IsChecked == true)
            {
                Window menu = new editCard();
                menu.Show();
                this.Hide();
            } else if (players.Count == 1 && editRadio.IsChecked == true)
            {
                Window menu = new addCard();
                menu.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("login salah");
            }
		}

		private void exitButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			this.Close();
		}
	}
}