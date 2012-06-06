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

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

using NCB.Model;

namespace NCB
{
	/// <summary>
	/// Interaction logic for profileWindow.xaml
	/// </summary>
	public partial class ProfileWindow : Window
	{
        public MenuWindow parent;
        public Player player;
        public ProfileWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;

            showDetail();
		}

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

        public void updatepass()
        {
            ModelPlayer mp = new ModelPlayer();
            mp.UpdatePass(player, passbox.Password);
            /*
             * mu operasi yg ada hubungannya sama db tak pindah ke model ya
            DbConnection conn = new DbConnection();
            var factory = conn.CreateSessionFactory("Player_CardMap");

            using (var session = factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    player = session.Get<Player>(player.PLAYER_ID);
                    player.PLAYER_PASSWORD = passbox.Password;
                    tx.Commit();
                }
            }
            */
        }

        public void showDetail()
        {
            userPlayer.Text = player.PLAYER_NAME.ToString();
            winPlayer.Text = player.PLAYER_WIN.ToString();
            losePlayer.Text = player.PLAYER_LOSE.ToString();
            moneyPlayer.Text = player.PLAYER_MONEY.ToString();
        }


	}
}