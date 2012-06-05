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
using System.Reflection;
using NCB.Library;

namespace NCB
{
	/// <summary>
	/// Interaction logic for DeckWindow.xaml
	/// </summary>
	public partial class DeckWindow : Window
	{
        public MenuWindow parent;
        public Player player;

        public DeckWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;
		}

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

		private void stockDown(object sender, System.Windows.RoutedEventArgs e)
		{
            ImageLibrary img = new ImageLibrary();
            ImageContainerStock.Source = img.Load("images/default_card.png");
		}

		private void stockUp(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void activeUp(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void activeDown(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}
	}
}