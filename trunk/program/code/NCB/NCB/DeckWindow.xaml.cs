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
        public List<Player_Card> activeDeck = new List<Player_Card>();
        public int selectedCardStock = 0;
        public int selectedActiveDeck = 0;

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
            for(int i = 0, j = 0, k = 0; i< cards.Count; i++){
                if (cards[i].PLAYER_CARD_ACTIVE){
                    activeDeck[j] = cards[i];
                    j++;
                }else{
                    cardStock[k] = cards[i];
                    k++;
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
            if (selectedCardStock + 1 < cardStock.Count)
            {
                selectedCardStock++;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardStock[selectedCardStock] + ".png");
            }
		}

		private void stockUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedCardStock - 1 > 0)
            {
                selectedCardStock--;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardStock[selectedCardStock] + ".png");
            }
		}

		private void activeUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedActiveDeck - 1 > 0)
            {
                selectedActiveDeck--;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + activeDeck[selectedActiveDeck] + ".png");
            }
		}

		private void activeDown(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedActiveDeck + 1 < activeDeck.Count)
            {
                selectedActiveDeck++;
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + activeDeck[selectedActiveDeck] + ".png");
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