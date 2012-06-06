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
using NCB.Model;
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
        public List<Player_Card> cards = new List<Player_Card>();
        public List<Player_Card> cardStock = new List<Player_Card>();
        public List<Player_Card> cardDeck = new List<Player_Card>();
        public int activeCardStock = 0;
        public int activeCardDeck = 0;

        public DeckWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;

            this.loadCard(this.player.PLAYER_ID);
		}

        private void loadCard(int _playerId)
        {
            ModelPlayer_Card mpc = new ModelPlayer_Card();
            cards = mpc.loadPlayerCard(_playerId);
            for(int i = 0; i < cards.Count; i++){
                if (cards[i].PLAYER_CARD_ACTIVE){
                    cardDeck[cardDeck.Count + 1] = cards[i];
                }else{
                    cardStock[cardStock.Count + 1] = cards[i];
                }
            }
        }

        private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

		private void stockDown(object sender, System.Windows.RoutedEventArgs e)
		{
            if (activeCardStock + 1 < cardStock.Count)
            {
                activeCardStock++;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardStock[activeCardStock] + ".png");
            }
		}

		private void stockUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (activeCardStock - 1 > 0)
            {
                activeCardStock--;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardStock[activeCardStock] + ".png");
            }
		}

		private void activeUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (activeCardDeck - 1 > 0)
            {
                activeCardDeck--;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardDeck[activeCardDeck] + ".png");
            }
		}

		private void activeDown(object sender, System.Windows.RoutedEventArgs e)
		{
            if (activeCardDeck + 1 < cardDeck.Count)
            {
                activeCardDeck++;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardDeck[activeCardDeck] + ".png");
            }
		}

        private void InsertDeckButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InsertStockButton_Click(object sender, RoutedEventArgs e)
        {

        }
	}
}