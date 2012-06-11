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

        public void init()
        {
            for(int i = 0; i < 7; i++)
            {
                player1hand.Add(player1cards.Last.Value.Card);
                player1cards.RemoveLast();
            }
            //reload();
        }

        public void reload()
        {
            ImageLibrary img = new ImageLibrary();
            if (player1hand[0].CARD_ID != null)
            {
                hand1.Source = img.Load("kartu/" + player1hand[0].CARD_ID.ToString() + ".png");
            }
            if (player1hand[1].CARD_ID != null)
            {
                hand2.Source = img.Load("kartu/" + player1hand[1].CARD_ID.ToString() + ".png");
            }
            if (player1hand[2].CARD_ID != null)
            {
                hand3.Source = img.Load("kartu/" + player1hand[2].CARD_ID.ToString() + ".png");
            }
            if (player1hand[3].CARD_ID != null)
            {
                hand4.Source = img.Load("kartu/" + player1hand[3].CARD_ID.ToString() + ".png");
            }
            if (player1hand[4].CARD_ID != null)
            {
                hand5.Source = img.Load("kartu/" + player1hand[4].CARD_ID.ToString() + ".png");
            }
            if (player1hand[5].CARD_ID != null)
            {
                hand6.Source = img.Load("kartu/" + player1hand[5].CARD_ID.ToString() + ".png");
            }
            if (player1hand[6].CARD_ID != null)
            {
                hand7.Source = img.Load("kartu/" + player1hand[6].CARD_ID.ToString() + ".png");
            }
        }

        public void GetCards()
        {
            ModelPlayer_Card playerCard = new ModelPlayer_Card();
            
                for(int i = 0; i < 40; i++)
                {
                    player1cards.AddLast(playerCard.LoadPlayerCard(player1.PLAYER_ID)[i]);
                    player2cards.AddLast(playerCard.LoadPlayerCard(player2.PLAYER_ID)[i]);
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
	}
}