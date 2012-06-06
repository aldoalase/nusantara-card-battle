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

using NCB.Model;

namespace NCB
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MessageBox.Show("test");
        }

        private void ButtonExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.Close();
        }

        private void doLogin(object sender, System.Windows.RoutedEventArgs e)
        {
            ModelPlayer mp = new ModelPlayer();
            List<Player> players = mp.login(TextBoxUsername.Text, TextBoxPassword.Password);
            if (players.Count == 1)
            {
                Window menu = new MenuWindow(this, players[0]);
                menu.Show();
                this.Hide();
            } else {
                Window notify = new Notification("invalid username password");
                notify.Show();
            }
        }

        private void do_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        	// TODO: Add event handler implementation here.
        }

        
    }
}