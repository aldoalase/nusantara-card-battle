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
        private int cardStockCount = 0;
        private int activeDeckCount = 0;
        private int selectedCardStock = 0;
        private int selectedActiveDeck = 0;
        private int maxDeck = 40;
        private ModelPlayer_Card model = new ModelPlayer_Card();

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

            cards = this.model.LoadPlayerCard(_playerId);
            activeDeck = cards.Where(item => item.PLAYER_CARD_ACTIVE).ToList();
            cardStock = cards.Where(item => !item.PLAYER_CARD_ACTIVE).ToList();
            cardStockCount = cardStock.Count;
            activeDeckCount = activeDeck.Count;
            //MessageBox.Show(cardStock[selectedCardStock].Card.CARD_NAME.ToString());
            ImageLibrary img = new ImageLibrary();
            if (activeDeckCount == 0) {
                ImageContainerDeck.Source = img.Load("images/default_card.png");
            } else {
                ImageContainerDeck.Source = img.Load("kartu/" + activeDeck[selectedActiveDeck].Card.CARD_ID.ToString() + ".png");
            }

            if (cardStockCount == 0) {
                ImageContainerStock.Source = img.Load("images/default_card.png");
            }else {
                ImageContainerStock.Source = img.Load("kartu/" + cardStock[selectedCardStock].Card.CARD_ID.ToString() + ".png");
            }

            this.setTitleText();
        }

        private void setTitleText()
        {
            String s = "CARD STOCK";
            if (selectedCardStock == 0 && cardStockCount == 0){
                s = s + " (0/0)";
            }else{
                s = s + " (" + (selectedCardStock + 1).ToString() + "/" + cardStock.Count.ToString() + ")";
            }
            cardStockText.Text = s;

            s = "ACTIVE DECK";
            if (selectedActiveDeck == 0 && activeDeckCount == 0)
            {
                s = s + " (0/0)";
            }
            else
            {
                s = s + " (" + (selectedActiveDeck + 1).ToString() + "/" + activeDeck.Count.ToString() + ")";
            }
            activeDeckText.Text = s;
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
                String cardId = cardStock[selectedCardStock].Card.CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardId + ".png");
                this.setTitleText();
            }
		}

		private void stockUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedCardStock - 1 >= 0)
            {
                selectedCardStock--;
                String cardId = cardStock[selectedCardStock].Card.CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerStock.Source = img.Load("kartu/" + cardId + ".png");
                this.setTitleText();
            }
		}

		private void activeUp(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedActiveDeck - 1 >= 0)
            {
                selectedActiveDeck--;
                String cardId = activeDeck[selectedActiveDeck].Card.CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerDeck.Source = img.Load("kartu/" + cardId + ".png");
                this.setTitleText();
            }
		}

		private void activeDown(object sender, System.Windows.RoutedEventArgs e)
		{
            if (selectedActiveDeck + 1 < activeDeck.Count)
            {
                selectedActiveDeck++;
                String cardId = activeDeck[selectedActiveDeck].Card.CARD_ID.ToString();
                ImageLibrary img = new ImageLibrary();
                ImageContainerDeck.Source = img.Load("kartu/" + cardId + ".png");
                this.setTitleText();
            }
		}

        private void InsertDeckButton_Click(object sender, RoutedEventArgs e)
        {
            //set current stock to active -> send to deck
            if (cardStock.Count > 0 && activeDeck.Count < maxDeck)
            {
                cardStock[selectedCardStock].PLAYER_CARD_ACTIVE = true;
                this.Process("update", cardStock[selectedCardStock]);
            }
        }

        private void InsertStockButton_Click(object sender, RoutedEventArgs e)
        {
            //set current deck to inactive -> send to stock
            if (activeDeck.Count > 0)
            {
                activeDeck[selectedActiveDeck].PLAYER_CARD_ACTIVE = false;
                this.Process("update", activeDeck[selectedActiveDeck]);
            }
        }

        private void Process(String action, Player_Card current)
        {
            this.model.Process(action, current);

            //int _selectedActiveDeck = selectedActiveDeck;
            //int _selectedCardStock = selectedCardStock;
            this.loadCard(this.player.PLAYER_ID);
            //this.selectedActiveDeck = (_selectedActiveDeck > activeDeckCount ? activeDeckCount : _selectedActiveDeck);
            //this.selectedCardStock = (_selectedCardStock > cardStockCount ? cardStockCount : _selectedCardStock);
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            double cardPrice = cardStock[selectedCardStock].Card.CARD_PRICE;
            this.model.Process("delete", cardStock[selectedCardStock]);

            ModelPlayer mp = new ModelPlayer();
            this.player.PLAYER_MONEY = this.player.PLAYER_MONEY + cardPrice;
            mp.Process("update", this.player);

            this.loadCard(this.player.PLAYER_ID);

            Notification n = new Notification("Your money : " + this.player.PLAYER_MONEY.ToString());
            n.ShowDialog();
        }
	}
}