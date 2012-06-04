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

namespace NCB
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
    public partial class LoginWindow : Window
    {
        private List<Player> players = new List<Player>();

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
            DbConnection conn = new DbConnection();
            var factory = conn.CreateSessionFactory("PlayerMap");
            using (var session = factory.OpenSession())
            {
                players = session.Query<Player>()
                       //.OrderBy(c => c.PLAYER_NAME)
                       .ToList();
            }

			bool authenticate = false;
            for (int i = 0; i < players.Count; i++)
            {
                if (TextBoxUsername.Text.Equals(players[i].PLAYER_NAME) && TextBoxPassword.Password.Equals(players[i].PLAYER_PASSWORD))
                {
                    authenticate = true;
                    break;
                }
            }
			if (authenticate)
            {
                Window menu = new MenuWindow();
                menu.Show();
                this.Hide();
            }
            else
            {
                TextBoxUsername.Text = "salah";
            }
        }

        
    }
}