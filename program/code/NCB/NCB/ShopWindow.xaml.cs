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
using NCB.Mapping;

namespace NCB
{
	/// <summary>
	/// Interaction logic for ShopWindow.xaml
	/// </summary>
	public partial class ShopWindow : Window
	{
        private MenuWindow parent;
        private Player player;
        private ModelCard model = new ModelCard();
        private List<Card> cards = new List<Card>();
        private List<Tipe> tipes = new List<Tipe>();
        private int selectedCard = 0;
        public ShopWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;
            this.init();
            MouseDown += delegate { DragMove(); };
		}

        private void init()
        {
            this.cards = model.loadCards();
            this.loadCards();
            this.loadTipe();
            playerMoneyText.Text = player.PLAYER_MONEY.ToString();
        }

        private void loadTipe()
        {
            ModelTipe mt = new ModelTipe();
            tipes = mt.loadTipe();
            for (int i = 0; i < tipes.Count; i++)
            {
                CategoryCombo.Items.Add(tipes[i]);
            }
        }

        private void loadCards()
        {
            String image, name, price = null;
            if (cards.Count == 0)
            {
                selectedCard = 0;
                image = "0";
                name = "(0/0)";
                price = "0";
            }
            else
            {
                image = cards[selectedCard].CARD_ID.ToString();
                name = cards[selectedCard].CARD_NAME + " (" + (selectedCard + 1).ToString() + "/" + cards.Count + ")";
                price = cards[selectedCard].CARD_PRICE.ToString();
            }
            ImageLibrary img = new ImageLibrary();
            cardPreviewBig.Source = img.Load("kartu/" + image + ".png");
            cardName.Text = name;
            HARGA_KARTU.Text = price;
        }

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

        private void UpButtonStock_Click(object sender, RoutedEventArgs e)
        {
            if(selectedCard -1 >= 0){
                selectedCard--;
                loadCards();
            }

        }

        private void DownButtonStock_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCard + 1 < cards.Count)
            {
                selectedCard++;
                loadCards();
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            this.cards.Clear();
            this.cards = model.getTipeCard(tipes[CategoryCombo.SelectedIndex].TIPE_ID);
            loadCards();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (cards.Count > 0)
            {
                String m = "uang tidak cukup";
                if (player.PLAYER_MONEY >= cards[selectedCard].CARD_PRICE)
                {
                    Player_Card pc = new Player_Card();
                    pc.Player = player;
                    pc.Card = cards[selectedCard];

                    ModelPlayer_Card mpc = new ModelPlayer_Card();
                    mpc.Process("save", pc);

                    this.player.PLAYER_MONEY -= cards[selectedCard].CARD_PRICE;
                    ModelPlayer mp = new ModelPlayer();
                    mp.Process("update", this.player);
                    playerMoneyText.Text = player.PLAYER_MONEY.ToString();

                    m = "berhasil";
                }

                Notification n = new Notification(m);
                n.Show();
            }
        }
	}
}