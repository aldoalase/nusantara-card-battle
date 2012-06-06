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
using NCB.Library;

namespace NCB
{
	/// <summary>
	/// Interaction logic for ShopWindow.xaml
	/// </summary>
	public partial class ShopWindow : Window
	{
        public MenuWindow parent;
        public Player player;
        public List<Card> cards = new List<Card>();
        private int selectedCard = 0;
        public ShopWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;
		}

        private void prepareCards()
        {
            ModelCard mc = new ModelCard();
            cards = mc.loadCards();
            ImageLibrary img = new ImageLibrary();
            cardPreviewSmall.Source = img.Load("kartu/" + cards[selectedCard] + ".png");
            cardPreviewBig.Source = img.Load("kartu/" + cards[selectedCard] + ".png");
        }

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}
	}
}