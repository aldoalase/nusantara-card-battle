using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NCB.Object;

namespace NCB
{
	/// <summary>
	/// Interaction logic for waitingRoomWindow.xaml
	/// </summary>
	public partial class WaitingRoomWindow : Window
	{
        public MenuWindow parent;
        public Player player;
	    
	    /*public TcpClient tcpClient;
	    public NetworkStream networkStream;
	    public BinaryFormatter formatter;
        public Thread thread;
        public bool working;*/

		public WaitingRoomWindow(MenuWindow _parent, Player _player)
		{
			this.InitializeComponent();
            this.parent = _parent;
            this.player = _player;
            MouseDown += delegate { DragMove(); };
 
            /*tcpClient = new TcpClient();
		    thread = new Thread(Work);*/
		}

        /*public void Work()
        {
            Data data = new Data();
            while(working)
            {
                if(networkStream.DataAvailable)
                {
                    data = (Data) formatter.Deserialize(networkStream);
                }
            }
        }*/

		private void doBack(object sender, System.Windows.RoutedEventArgs e)
		{
            this.parent.Show();
			this.Close();
		}

		private void doPlay(object sender, System.Windows.RoutedEventArgs e)
		{
			Window play = new PlayWindow(this, this.player, this.player);
            play.Show();
            this.Hide();
		}
	}
}