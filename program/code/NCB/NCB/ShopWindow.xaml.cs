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
	/// Interaction logic for ShopWindow.xaml
	/// </summary>
	public partial class ShopWindow : Window
	{
        public MenuWindow parent;
        public Player player;
        public ShopWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;
            MouseDown += delegate { DragMove(); };
		}

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}
	}
}