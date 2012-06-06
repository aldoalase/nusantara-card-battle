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

namespace NCB
{
	/// <summary>
	/// Interaction logic for playWindow.xaml
	/// </summary>
	public partial class PlayWindow : Window
	{
		public PlayWindow()
		{
			this.InitializeComponent();
            
			// Insert code required on object creation below this point.
            deckPlayerAnimated.IsEnabled = false;
            MouseDown += delegate { DragMove(); };
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

		private void Hand1_click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}
	}
}