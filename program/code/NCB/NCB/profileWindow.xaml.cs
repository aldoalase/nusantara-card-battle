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
            MouseDown += delegate { DragMove(); };
		}

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

        private void doSave(object sender, System.Windows.RoutedEventArgs e)
        {
            ModelPlayer mp = new ModelPlayer();
            mp.UpdatePass(player, passbox.Password);
            Window notify = new Notification("password changed");
            notify.Show();
            // TODO: Add event handler implementation here.
        }

        public void updatepass()
        {
            ModelPlayer mp = new ModelPlayer();
            mp.UpdatePass(player, passbox.Password);
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