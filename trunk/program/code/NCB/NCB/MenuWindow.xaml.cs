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
        public LoginWindow parent;
        public Player player;
        public MenuWindow(LoginWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;
            MouseDown += delegate { DragMove(); };
		}

		private void doLogout(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

		private void showDeck(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Hide();
            Window deck = new DeckWindow(this, this.player);
			deck.Show();
		}

		private void showShop(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Hide();
            Window shop = new ShopWindow(this, this.player);
			shop.Show();
		}

		private void showProfile(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Hide();
            Window profile = new ProfileWindow(this, this.player);
			profile.Show();
		}
	}
}