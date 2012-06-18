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
using GameAdmin.Model;
using GameAdmin.Library;
using GameAdmin.Mapping;

namespace GameAdmin
{
	/// <summary>
	/// Interaction logic for editCard.xaml
	/// </summary>
	public partial class editCard : Window
	{
        /*public ModelCard model = new ModelCard();
        public List<Card> cards = new List<Card>();
        public List<Tipe> tipes = new List<Tipe>();
        public int selectedCard = 0;*/
        private List<Tipe> tipes = new List<Tipe>();
        private List<Card> daftar = new List<Card>();
        int id;
        public editCard()
		{
			this.InitializeComponent();
            loadTipe();
            //this.init();
			// Insert code required on object creation below this point.
		}

        /*private void init()
        {
            this.cards = model.loadCards();
            this.loadCards();
            this.loadTipe();
           // playerMoneyText.Text = player.PLAYER_MONEY.ToString();
        }*/

        private void loadTipe()
        {
            ModelTipe mt = new ModelTipe();
            tipes = mt.loadTipe();
            for (int i = 0; i < tipes.Count; i++)
            {
                tipeKartu.Items.Add(tipes[i]);
            }
        }

        private void loadCards(int id)
        {  
            ModelCard mc = new ModelCard();
            daftar = mc.getTipeCard(id);
            daftarKartu.Items.Clear();
            for (int i = 0; i < daftar.Count; i++)
            {
                daftarKartu.Items.Add(daftar[i]);
            }
 
        }


       

        private void tipeKartu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void selectButton_Click_1(object sender, RoutedEventArgs e)
        {
            loadCards(tipes[tipeKartu.SelectedIndex].TIPE_ID);
        }

        private void pickButton_Click(object sender, RoutedEventArgs e)
        {
            namaKartu.Text = daftar[daftarKartu.SelectedIndex].CARD_NAME.ToString();
            deskripsiKartu.Text = daftar[daftarKartu.SelectedIndex].CARD_DESCRIPTION.ToString();
            cardStrength.Text = daftar[daftarKartu.SelectedIndex].CARD_STRENGTH.ToString();
            cardDefense.Text = daftar[daftarKartu.SelectedIndex].CARD_DEFENSE.ToString();
            cardHp.Text = daftar[daftarKartu.SelectedIndex].CARD_HP.ToString();
            cardLevel.Text = daftar[daftarKartu.SelectedIndex].CARD_LEVEL.ToString();
            enchantStrength.Text = daftar[daftarKartu.SelectedIndex].ENCHANT_STRENGTH.ToString();
            enchantDefense.Text = daftar[daftarKartu.SelectedIndex].ENCHANT_DEFENSE.ToString();
            enchantHp.Text = daftar[daftarKartu.SelectedIndex].ENCHANT_HP.ToString();
            cardPrice.Text = daftar[daftarKartu.SelectedIndex].CARD_PRICE.ToString();

        }

        private void deskripsiKartu_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CommitButton_Click_1(object sender, RoutedEventArgs e)
        {
            ModelCard mp = new ModelCard();

            Card card = new Card
            {
                CARD_ID = daftar[daftarKartu.SelectedIndex].CARD_ID,
                CARD_NAME = namaKartu.Text,
                CARD_DESCRIPTION = deskripsiKartu.Text,
                CARD_STRENGTH = Convert.ToInt32(cardStrength.Text),
                CARD_DEFENSE = Convert.ToInt32(cardDefense.Text),
                CARD_HP = Convert.ToInt32(cardHp.Text),
                CARD_LEVEL = Convert.ToInt32(cardLevel.Text),
                Tipe = tipes[tipeKartu.SelectedIndex],
                CARD_MAGIC_NUMBER = 0,
                ENCHANT_STRENGTH = Convert.ToInt32(enchantStrength.Text),
                ENCHANT_DEFENSE = Convert.ToInt32(enchantDefense.Text),
                ENCHANT_HP = Convert.ToInt32(enchantHp.Text),
                CARD_PRICE = Convert.ToInt32(cardPrice.Text)
            };
            mp.Process("update", card);
            MessageBox.Show("berhasil menambahkan kartu");
        }

       
	}
}