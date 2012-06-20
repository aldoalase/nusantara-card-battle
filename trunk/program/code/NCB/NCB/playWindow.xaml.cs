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

	    private int handIndex = 7;
	    private int charIndex = 0;
	    private int enemyIndex;
	    private int charAttack;

	    private int phase = 0;
	    private bool turn;
	    private bool cardset;
	    private bool attacking;

        private ImageLibrary img = new ImageLibrary();
        public PlayWindow(WaitingRoomWindow _parent, Player _player1, Player _player2)
        {
            //ModelPlayer mp = new ModelPlayer();
            //List<Player> players = mp.login("ararenja", "alase21");
            //this.player1 = players[0];
            //this.player2 = players[0];

            this.InitializeComponent();
            this.parent = _parent;
            this.player1 = _player1;
            this.player2 = _player2;
            // Insert code required on object creation below this point.
            deckPlayerAnimated.IsEnabled = false;
            MouseDown += delegate { DragMove(); };
            GetTurn();
            GetCards();
            init();

            player2char[0] = player2hand[0];
            reload();
        }

        public void GetTurn()
        {
            turn = true;
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
                player2hand.Add(card.getCard(player1cards.Last.Value.Card.CARD_ID));
                player2cards.RemoveLast();
                player1char.Add(null);
                player2char.Add(null);
            }
            player1hand.Add(null);
            player1hand.Add(null);
            player2hand.Add(null);
            player2hand.Add(null);
            reload();
        }

        public void SetCard()
        {
            if (turn)
            {
                if (phase == 0)
                {
                    if (!cardset)
                    {
                        if (charIndex < 5)
                        {
                            if (handIndex >= 0 && handIndex <= 6 && player1hand[handIndex] != null)
                            {
                                player1char[charIndex] = player1hand[handIndex];
                                player1hand[handIndex] = null;
                                for (int i = handIndex; i < 6; i++)
                                {
                                    player1hand[i] = player1hand[i + 1];
                                    player1hand[i + 1] = null;
                                }
                                charIndex++;
                                reload();
                                handIndex = 7;
                                cardset = true;
                            }
                            else
                            {
                                Notification not = new Notification("Pilih kartu terlebih dahulu");
                                not.ShowDialog();
                            }

                        }
                        else
                        {
                            Notification not = new Notification("field penuh");
                            not.ShowDialog();
                        }
                    }
                    else
                    {
                        Notification not = new Notification("kamu sudah menaruh kartu");
                        not.ShowDialog();
                    }
                }
                else
                {
                    Notification not = new Notification("ini bukan saat menaruh kartu");
                    not.ShowDialog();
                }
            }
        }

        public int Attack(Card attacker, Card defender)
        {
            if(turn)
            {
                if (defender.CARD_DEFENSE == attacker.CARD_STRENGTH)
                {
                    charAttack = 99;
                    attacking = true;
                    return 0;
                }
                else if (defender.CARD_DEFENSE - attacker.CARD_STRENGTH <= 0)
                {
                    charAttack = 99;
                    attacking = true;
                    return 1;
                }
                else if (defender.CARD_DEFENSE - attacker.CARD_STRENGTH >= 0)
                {
                    charAttack = 99;
                    attacking = true;
                    return 2;
                }
            }
            MessageBox.Show("giliran musuh");
            return 99;
            
        }

        public void EndPhase()
        {
            
            if(phase == 1)
            {
                Notification not = new Notification("sudah tidak ada phase lagi, end turn");
                not.ShowDialog();
            }
            else
            {
                phase++;
                reload();
            }

            
            //MessageBox.Show(phase.ToString());
        }

        public void EndTurn()
        {
            //turn = false;
            handIndex = 7;
            phase = 0;
            cardset = false;
            attacking = false;
            reload();
        }

        public void reload()
        {
            if(turn)
            {
                if(phase == 0)
                {
                    phaseLabel.Text = "Set Card Phase";
                }
                else
                {
                    phaseLabel.Text = "Attack Phase";
                }
            }
            else
            {
                phaseLabel.Text = "Giliran Lawan";
            }

            //deckPlayer.Source = img.Load("kartu/9.png");
            if (player1hand[0] != null)
            {
                hand1.Source = img.Load("kartu/" + player1hand[0].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand1.Source = img.Load("kartu/4.png"); ;
            }

            if (player1hand[1] != null)
            {
                hand2.Source = img.Load("kartu/" + player1hand[1].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand2.Source = img.Load("kartu/4.png"); ;
            }

            if (player1hand[2] != null)
            {
                hand3.Source = img.Load("kartu/" + player1hand[2].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand3.Source = img.Load("kartu/4.png"); ;
            }

            if (player1hand[3] != null)
            {
                hand4.Source = img.Load("kartu/" + player1hand[3].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand4.Source = img.Load("kartu/4.png"); ;
            }

            if (player1hand[4] != null)
            {
                hand5.Source = img.Load("kartu/" + player1hand[4].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand5.Source = img.Load("kartu/4.png"); ;
            }

            if (player1hand[5] != null)
            {
                hand6.Source = img.Load("kartu/" + player1hand[5].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand6.Source = img.Load("kartu/4.png"); ;
            }

            if (player1hand[6] != null)
            {
                hand7.Source = img.Load("kartu/" + player1hand[6].CARD_ID.ToString() + ".png");
            }
            else
            {
                hand7.Source = img.Load("kartu/4.png"); ;
            }



            //load gambar field
            if (player1char[0] != null)
            {
                char1player.Source = img.Load("kartu/" + player1char[0].CARD_ID.ToString() + ".png");
            }
            if (player1char[1] != null)
            {
                char2player.Source = img.Load("kartu/" + player1char[1].CARD_ID.ToString() + ".png");
            }
            if (player1char[2] != null)
            {
                char3player.Source = img.Load("kartu/" + player1char[2].CARD_ID.ToString() + ".png");
            }
            if (player1char[3] != null)
            {
                char4player.Source = img.Load("kartu/" + player1char[3].CARD_ID.ToString() + ".png");
            }
            if (player1char[4] != null)
            {
                char5player.Source = img.Load("kartu/" + player1char[4].CARD_ID.ToString() + ".png");
            }

            //load gambar field enemy
            if (player2char[0] != null)
            {
                char1enemy.Source = img.Load("kartu/" + player2char[0].CARD_ID.ToString() + ".png");
            }
            if (player2char[1] != null)
            {
                char2enemy.Source = img.Load("kartu/" + player2char[1].CARD_ID.ToString() + ".png");
            }
            if (player2char[2] != null)
            {
                char3enemy.Source = img.Load("kartu/" + player2char[2].CARD_ID.ToString() + ".png");
            }
            if (player2char[3] != null)
            {
                char4enemy.Source = img.Load("kartu/" + player2char[3].CARD_ID.ToString() + ".png");
            }
            if (player2char[4] != null)
            {
                char5enemy.Source = img.Load("kartu/" + player2char[4].CARD_ID.ToString() + ".png");
            }
        }

		private void PlayButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			deckPlayerAnimated.IsEnabled= true;
			Storyboard sb = this.FindResource("deckPlayerLoaded") as Storyboard;
        	sb.Begin();
            SetCard();

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
            if (player1hand[0] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[0].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
	        handIndex = 0;
		}

		private void hand2button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand[1] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[1].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
            handIndex = 1;

		}

		private void hand3Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand[2] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[2].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
            handIndex = 2;
		}

		private void hand4Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand[3] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[3].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
            handIndex = 3;
		}

		private void hand5Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand[4] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[4].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
            handIndex = 4;
		}

		private void hand6Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand[5] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[5].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
            handIndex = 5;
		}

		private void hand7Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (player1hand[6] != null)
            {
                ImageLarge.Source = img.Load("kartu/" + player1hand[6].CARD_ID.ToString() + ".png");
            }
            else
            {
                ImageLarge.Source = img.Load("kartu/4.png");
            }
            handIndex = 6;
		}

		private void endPhaseButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            EndPhase();
			
		}

		private void endTurnButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            EndTurn();
		}

		private void char1Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                charAttack = 0;
                MessageBox.Show("test");
            }
		}

		private void char2Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                charAttack = 1;
            }
		}

		private void char3Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                charAttack = 2;
            }
		}

		private void char4Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                charAttack = 3;
            }
		}

		private void char5Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                charAttack = 4;
            }
		}


        //Enemy Button
		private void char1enemyButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		    if(phase == 1)
		    {
                if (!attacking)
                {
                    if (charAttack != 99)
                    {
                        enemyIndex = 0;
                        int hasil = Attack(player1char[charAttack], player2char[enemyIndex]);
                        if (hasil == 1)
                        {
                            MessageBox.Show("Win");
                        }
                        else if (hasil == 2)
                        {
                            MessageBox.Show("lose");
                        }
                        else if (hasil == 0)
                        {
                            MessageBox.Show("draw");
                        }
                    }
                    else
                    {
                        Notification not = new Notification("pilih penyerang dulu");
                        not.ShowDialog();
                    }
                }
                else
                {
                    Notification not = new Notification("kamu sudah menyerang");
                    not.ShowDialog();
                }
		    }
		}

		private void char2enemyButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                if (!attacking)
                {
                    if (charAttack != 99)
                    {
                        enemyIndex = 1;
                        int hasil = Attack(player1char[charAttack], player2char[enemyIndex]);
                        if (hasil == 1)
                        {
                            MessageBox.Show("Win");
                        }
                        else if (hasil == 2)
                        {
                            MessageBox.Show("lose");
                        }
                        else if (hasil == 0)
                        {
                            MessageBox.Show("draw");
                        }
                    }
                    else
                    {
                        Notification not = new Notification("pilih penyerang dulu");
                        not.ShowDialog();
                    }
                }
                else
                {
                    Notification not = new Notification("kamu sudah menyerang");
                    not.ShowDialog();
                }
            }
		}

		private void char3enemyButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            if (phase == 1)
            {
                if (!attacking)
                {
                    if (charAttack != 99)
                    {
                        enemyIndex = 2;
                        int hasil = Attack(player1char[charAttack], player2char[enemyIndex]);
                        if (hasil == 1)
                        {
                            MessageBox.Show("Win");
                        }
                        else if (hasil == 2)
                        {
                            MessageBox.Show("lose");
                        }
                        else if (hasil == 0)
                        {
                            MessageBox.Show("draw");
                        }
                    }
                    else
                    {
                        Notification not = new Notification("pilih penyerang dulu");
                        not.ShowDialog();
                    }
                }
                else
                {
                    Notification not = new Notification("kamu sudah menyerang");
                    not.ShowDialog();
                }
            }
		}

        private void char4enemyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (phase == 1)
            {
                if (!attacking)
                {
                    if (charAttack != 99)
                    {
                        enemyIndex = 3;
                        int hasil = Attack(player1char[charAttack], player2char[enemyIndex]);
                        if (hasil == 1)
                        {
                            MessageBox.Show("Win");
                        }
                        else if (hasil == 2)
                        {
                            MessageBox.Show("lose");
                        }
                        else if (hasil == 0)
                        {
                            MessageBox.Show("draw");
                        }
                    }
                    else
                    {
                        Notification not = new Notification("pilih penyerang dulu");
                        not.ShowDialog();
                    }
                }
                else
                {
                    Notification not = new Notification("kamu sudah menyerang");
                    not.ShowDialog();
                }
            }
        }

        private void char5enemyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (phase == 1)
            {
                if (!attacking)
                {
                    if (charAttack != 99)
                    {
                        enemyIndex = 4;
                        int hasil = Attack(player1char[charAttack], player2char[enemyIndex]);
                        if (hasil == 1)
                        {
                            MessageBox.Show("Win");
                        }
                        else if (hasil == 2)
                        {
                            MessageBox.Show("lose");
                        }
                        else if (hasil == 0)
                        {
                            MessageBox.Show("draw");
                        }
                    }
                    else
                    {
                        Notification not = new Notification("pilih penyerang dulu");
                        not.ShowDialog();
                    }
                }
                else
                {
                    Notification not = new Notification("kamu sudah menyerang");
                    not.ShowDialog();
                }
            }
        }
	}
}