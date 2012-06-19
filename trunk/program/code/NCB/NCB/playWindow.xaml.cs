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
using System.Windows.Media.Animation;
using NCB.Library;
using NCB.Model;

namespace NCB
{
	/// <summary>
	/// Interaction logic for playWindow.xaml
	/// </summary>
	public partial class PlayWindow : Window
	{
        private WaitingRoomWindow parent;
	    private Player player1;
	    private Player player2;

	    private LinkedList<Player_Card> player1cards = new LinkedList<Player_Card>();
        private LinkedList<Player_Card> player2cards = new LinkedList<Player_Card>();

        private LinkedList<Card> test = new LinkedList<Card>();
        private List<Card> player1hand = new List<Card>();
        private List<Card> player2hand = new List<Card>();
        private List<Card> player1char = new List<Card>();
        private List<Card> player2char = new List<Card>();

	    private int selectedIndex;

        private ImageLibrary img = new ImageLibrary();
		public PlayWindow(WaitingRoomWindow _parent, Player _player1, Player _player2)
		{
			this.InitializeComponent();
		    this.parent = _parent;
		    this.player1 = _player1;
		    this.player2 = _player2;
			// Insert code required on object creation below this point.
            deckPlayerAnimated.IsEnabled = false;
            MouseDown += delegate { DragMove(); };
            GetCards();
            init();
		}

        public void GetCards()
        {
            ModelPlayer_Card playerCard = new ModelPlayer_Card();
            for (int i = 0; i < 40; i++)
            {
                player1cards.AddLast(playerCard.LoadActiveCards(player1.PLAYER_ID)[i]);
                player2cards.AddLast(playerCard.LoadActiveCards(player2.PLAYER_ID)[i]);
            }
        }

        public void init()
        {
            ModelCard card = new ModelCard();
            for(int i = 0; i < 5; i++)
            {
                player1hand.Add(card.getCard(player1cards.Last.Value.Card.CARD_ID));
                player1cards.RemoveLast();
            }
            reload();
        }

        public void reload()
        {
            //deckPlayer.Source = img.Load("kartu/default_card.png");
            if (player1hand.Count >= 1)
            {
                hand1.Source = img.Load("kartu/" + player1hand[0].CARD_ID.ToString() + ".png");
            }
            if (player1hand.Count >= 2)
            {
                hand2.Source = img.Load("kartu/" + player1hand[1].CARD_ID.ToString() + ".png");
            }
            if (player1hand.Count >= 3)
            {
                hand3.Source = img.Load("kartu/" + player1hand[2].CARD_ID.ToString() + ".png");
            }
            if (player1hand.Count >= 4)
            {
                hand4.Source = img.Load("kartu/" + player1hand[3].CARD_ID.ToString() + ".png");
            }
            if (player1hand.Count >= 5)
            {
                hand5.Source = img.Load("kartu/" + player1hand[4].CARD_ID.ToString() + ".png");
            }
            if (player1hand.Count >= 6)
            {
                hand6.Source = img.Load("kartu/" + player1hand[5].CARD_ID.ToString() + ".png");
            }
            if (player1hand.Count >= 7)
            {
                hand7.Source = img.Load("kartu/" + player1hand[6].CARD_ID.ToString() + ".png");
            }


            //load gambar field
            if (player1char.Count >= 1)
            {
                hand1.Source = img.Load("kartu/" + player1hand[0].CARD_ID.ToString() + ".png");
            }
            if (player1char.Count >= 2)
            {
                hand2.Source = img.Load("kartu/" + player1hand[1].CARD_ID.ToString() + ".png");
            }
            if (player1char.Count >= 3)
            {
                hand3.Source = img.Load("kartu/" + player1hand[2].CARD_ID.ToString() + ".png");
            }
            if (player1char.Count >= 4)
            {
                hand4.Source = img.Load("kartu/" + player1hand[3].CARD_ID.ToString() + ".png");
            }
            if (player1char.Count >= 5)
            {
                hand5.Source = img.Load("kartu/" + player1hand[4].CARD_ID.ToString() + ".png");
            }
        }

		private void PlayButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			deckPlayerAnimated.IsEnabled= true;
			Storyboard sb = this.FindResource("deckPlayerLoaded") as Storyboard;
        	sb.Begin();

		}

		private void ThrowButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Storyboard sb = this.FindResource("kuburanPlayerLoaded") as Storyboard;
        	sb.Begin();
		}

	    private void hand1Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if(player1hand.Count >= 1)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[0].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
	        selectedIndex = 0;
		}

		private void hand2button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand.Count >= 2)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[1].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
            selectedIndex = 1;

		}

		private void hand3Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand.Count >= 3)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[2].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
            selectedIndex = 2;
		}

		private void hand4Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand.Count >= 4)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[3].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
            selectedIndex = 3;
		}

		private void hand5Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand.Count >= 5)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[4].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
            selectedIndex = 4;
		}

		private void hand6Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand.Count >= 6)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[5].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
            selectedIndex = 5;
		}

		private void hand7Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand.Count >= 7)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[6].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/default_card.png");
            }
            selectedIndex = 6;
		}
	}
}