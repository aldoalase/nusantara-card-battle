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
using System.Linq;
using NCB.Model;
using NCB.Library;

namespace NCB
{
	/// <summary>
	/// Interaction logic for DeckWindow.xaml
	/// </summary>
	public partial class DeckWindow : Window
	{
        private MenuWindow parent;
        private Player player;
        private List<Player_Card> cards = new List<Player_Card>();
        private List<Player_Card> cardStock = new List<Player_Card>();
        private List<Player_Card> activeDeck = new List<Player_Card>();
        private int selectedCardStock = 0;
        private int selectedActiveDeck = 0;
        private int maxDeck = 40;

        public DeckWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;

            this.loadCard(this.player.PLAYER_ID);
            MouseDown += delegate { DragMove(); };
		}

        private void loadCard(int _playerId)
        {
            //reset property
            cards.Clear();
            activeDeck.Clear();
            cardStock.Clear();
            selectedActiveDeck = 0; //this will reset activedesk back to first card
            selectedCardStock = 0; //this will reset cardstock back to first card

            ModelPlayer_Card mpc = new ModelPlayer_Card();
            cards = mpc.LoadPlayerCard(_playerId);
            activeDeck = cards.Where(item => item.PLAYER_CARD_ACTIVE).ToList();
            cardStock = cards.Where(item => !item.PLAYER_CARD_ACTIVE).ToList();
            /*
            for(int i = 0; i< cards.Count; i++){
                if (cards[i].PLAYER_CARD_ACTIVE){
                    activeDeck[activeDeck.Count + 1] = cards[i];
                }else{
                    cardStock[cardStock.Count + 1] = cards[i];
                }
            }
            */
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
                String cardId = cardStock[selectedCardStock].PLAYER_CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardId + ".png");
            }
		}

		private void stockUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedCardStock - 1 >= 0)
            {
                selectedCardStock--;
                String cardId = cardStock[selectedCardStock].PLAYER_CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardId + ".png");
            }
		}

		private void activeUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedActiveDeck - 1 >= 0)
            {
                selectedActiveDeck--;
                String cardId = activeDeck[selectedActiveDeck].PLAYER_CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerDeck.Source = img.Load("kartu/" + cardId + ".png");
            }
		}

		private void activeDown(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedActiveDeck + 1 < activeDeck.Count)
            {
                selectedActiveDeck++;
                String cardId = activeDeck[selectedActiveDeck].PLAYER_CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerDeck.Source = img.Load("kartu/" + cardId + ".png");
            }
		}

        private void InsertDeckButton_Click(object sender, RoutedEventArgs e)
        {
            //set current stock to active -> send to deck
            if (cardStock.Count > 0 && activeDeck.Count < maxDeck)
                this.Process(cardStock[selectedCardStock], true);
        }

        private void InsertStockButton_Click(object sender, RoutedEventArgs e)
        {
            //set current deck to inactive -> send to stock
            if(activeDeck.Count > 0)
                this.Process(activeDeck[selectedActiveDeck], false);
        }

        private void Process(Player_Card current, bool val)
        {
            current.PLAYER_CARD_ACTIVE = val;

            ModelPlayer_Card mpc = new ModelPlayer_Card();
            mpc.Process("update", current);

            this.loadCard(this.player.PLAYER_ID);
        }
	}
}