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
using GameAdmin.Mapping;

namespace GameAdmin
{
	/// <summary>
	/// Interaction logic for addCard.xaml
	/// </summary>
	public partial class addCard : Window
	{
        private List<Tipe> tipes = new List<Tipe>();
        public login parent;
		public addCard(login _parent)
		{
			this.InitializeComponent();
			loadTipe();
            this.InitializeComponent();
            this.parent = _parent;
			MouseDown += delegate { DragMove(); };
			
			// Insert code required on object creation below this point.
            cardStrength.IsEnabled = false;
            cardDefense.IsEnabled = false;
            cardHp.IsEnabled = false;
            cardLevel.IsEnabled = false;
            enchantStrength.IsEnabled = false;
			enchantDefense.IsEnabled = false;
			enchantHp.IsEnabled = false;
			cardPrice.IsEnabled = false;
            
		
        }
		
		
        private void loadTipe()
        {
            ModelTipe mt = new ModelTipe();
            tipes = mt.loadTipe();
            for (int i = 0; i < tipes.Count; i++)
            {
                tipeKombo.Items.Add(tipes[i]);
            }
        }

        private void OkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			
			namaKartu.IsEnabled = false;
			deskripsiKartu.IsEnabled = false;
			
            if (tipes[tipeKombo.SelectedIndex].TIPE_ID == 1) { 
                cardStrength.IsEnabled = true;
				cardDefense.IsEnabled = true;
				cardLevel.IsEnabled = true;
				cardPrice.IsEnabled = true;

            }
			else if (tipes[tipeKombo.SelectedIndex].TIPE_ID == 2){
				cardHp.IsEnabled = true;
				cardPrice.IsEnabled = true;
			}
			else if (tipes[tipeKombo.SelectedIndex].TIPE_ID == 3){
				enchantDefense.IsEnabled = true;
				enchantStrength.IsEnabled = true;
				enchantHp.IsEnabled = true;
				cardPrice.IsEnabled = true;
			}
			else if (tipes[tipeKombo.SelectedIndex].TIPE_ID == 4){
				enchantDefense.IsEnabled = true;
				enchantStrength.IsEnabled = true;
				enchantHp.IsEnabled = true;
				cardPrice.IsEnabled = true;
			}
            
        }

        private void CommitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            ModelCard mp = new ModelCard();

            Card card = new Card
            {

                CARD_NAME = namaKartu.Text,
                CARD_DESCRIPTION = deskripsiKartu.Text,
                CARD_STRENGTH = Convert.ToInt32(cardStrength.Text),
                CARD_DEFENSE = Convert.ToInt32(cardDefense.Text),
                CARD_HP = Convert.ToInt32(cardHp.Text),
                CARD_LEVEL = Convert.ToInt32(cardLevel.Text),
                Tipe = tipes[tipeKombo.SelectedIndex],
                CARD_MAGIC_NUMBER = 0,
                ENCHANT_STRENGTH = Convert.ToInt32(enchantStrength.Text),
                ENCHANT_DEFENSE = Convert.ToInt32(enchantDefense.Text),
                ENCHANT_HP = Convert.ToInt32(enchantHp.Text),
                CARD_PRICE = Convert.ToInt32(cardPrice.Text)
            };
            mp.Process("save", card);
            MessageBox.Show("berhasil menambahkan kartu");
        }

        private void exitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.'
			parent.Show();
			this.Close();
        }

       

        
	}


   
}