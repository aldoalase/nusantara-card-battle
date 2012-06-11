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

using NCB.Model;

namespace NCB
{
	/// <summary>
	/// Interaction logic for playWindow.xaml
	/// </summary>
	public partial class PlayWindow : Window
	{
	    private Player player1;
	    private Player player2;

	    private List<Player_Card> player1cards;
        private List<Player_Card> player2cards;
		public PlayWindow(Player _player1, Player _player2)
		{
			this.InitializeComponent();
		    player1 = _player1;
		    player2 = _player2;
			// Insert code required on object creation below this point.
            deckPlayerAnimated.IsEnabled = false;
            MouseDown += delegate { DragMove(); };
            GetCards();
		}

        public void GetCards()
        {
            ModelPlayer_Card playerCard = new ModelPlayer_Card();
            player1cards = playerCard.LoadPlayerCard(player1.PLAYER_ID);
            player2cards = playerCard.LoadPlayerCard(player2.PLAYER_ID);
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