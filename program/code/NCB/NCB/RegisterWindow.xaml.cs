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

using RandomPassword;

using NCB.Model;

namespace NCB
{
	/// <summary>
	/// Interaction logic for RegisterWindow.xaml
	/// </summary>
	public partial class RegisterWindow : Window
	{
        
		public RegisterWindow()
		{
			this.InitializeComponent();
            
			// Insert code required on object creation below this point.
		}

		private void create_button(object sender, System.Windows.RoutedEventArgs e)
		{
            ModelPlayer mp = new ModelPlayer();
            GeneratePassword gp = new GeneratePassword();
            string simpan = gp.generatorPassword();
            Window notify = new Notification("password anda adalah : " + simpan);
            notify.Show();
            mp.RegisterPlayer(InputUsername.Text,simpan);
            
			// TODO: Add event handler implementation here.
		}

        //private void cancel_button(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    LoginWindow login = new LoginWindow();
        //    this.Hide();
        //    login.Show();
        //    // TODO: Add event handler implementation here.
        //}

		private void cancel_button(object sender, System.Windows.RoutedEventArgs e)
		{
            LoginWindow login = new LoginWindow();
            this.Hide();
            login.Show();
			// TODO: Add event handler implementation here.
		}
	}
}