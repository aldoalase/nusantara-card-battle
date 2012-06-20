using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WhackAMole.Object;

namespace progjar
{

    

    public partial class GAME : Form
    {
        int counter = 10;

        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private BinaryFormatter _formatter;

        private Thread _thread;

        private string _userName;
        private string _password;
        private int _point;
        private bool _play;
        private string _puzzleSolve;
        private bool _firstTime;
        private int _index;

        private bool _working;
        
        public GAME()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            textBox1.Select();
            hide_all();
            _index = 0;
            _tcpClient = new TcpClient();
            _formatter = new BinaryFormatter();
            _thread = new Thread(Work);
        }



        private void hide_all()
        {
            BT_mole1.Hide();
            BT_mole2.Hide();
            BT_mole3.Hide();
            BT_mole4.Hide();
            BT_mole5.Hide();
            BT_mole6.Hide();
            BT_mole7.Hide();
            BT_mole8.Hide();
            BT_mole9.Hide();
        }

        private void ShowMole(char c)
        {
            MessageBox.Show(c.ToString());
            hide_all();
            if (c == 'q')
                BT_mole7.Show();
            else if (c == 'w')
                BT_mole8.Show();
            else if (c == 'e')
                BT_mole9.Show();
            else if (c == 'a')
                BT_mole4.Show();
            else if (c == 's')
                BT_mole5.Show();
            else if (c == 'd')
                BT_mole6.Show();
            else if (c == 'z')
                BT_mole1.Show();
            else if (c == 'x')
                BT_mole2.Show();
            else if (c == 'c')
                BT_mole3.Show();
        }

        private void BT_test_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < 2)
                {
                    hide_all();
                    BT_mole1.Show();
                }
                else
                {
                    hide_all();
                    BT_mole3.Show();
                }

            }
        }

        private void keypressed(Object o, KeyPressEventArgs e)
        {
            // The keypressed method uses the KeyChar property to check 
            // whether the ENTER key is pressed. 

            // If the ENTER key is pressed, the Handled property is set to true, 
            // to indicate the event is handled.
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }

        private void GAME_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch;
            //ch = e.KeyChar;
            //char[] soal = new char[100];
            //char[] jawaban = new char[100];

            String dummy = textBox1.Text.Trim();
            for (int i = 0; i < dummy.Length; i++)
            {
                if (!char.IsNumber(dummy[i]))
                {
                    soal.Text = soal.Text + dummy;
                    textBox1.Text = "";
                    
                }
                else
                {
                    jawaban.Text = jawaban.Text + dummy;
                    textBox1.Text = "";
                    char c = ShowQuestion(_index);
                    _index++;
                    ShowMole(c);
                }
            }

            // textBox1.Text = "a" ;
        }

        public void startTimer(bool a)
        {
            if (a == true)
            {
                waktu.Start();
                _index = 0;
                ShowMole(ShowQuestion(_index));
                waktu.Interval = 1000;
                waktu.Enabled = true;
                //waktu.Tick += System.EventHandler(onTimerEvent);
                waktu.Tick += new System.EventHandler(OnTimerEvent);
                MessageBox.Show("start waktu");
            }
            else
            {
                waktu.Stop();
            }
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            
            countdown.Text = counter.ToString();
            if (counter == 0)
            {
                counter = 20;
                TimesUp();
                soal.Text = "";
                jawaban.Text = "";
                
            }
            else
            {
                counter--;
            }
        }

        private void waktu_Tick(object sender, EventArgs e)
        {
           // int counter = 10;
           // countdown.Text = counter.ToString();
           // if (counter == 0)
           // {
            //    counter = 10;
                //kirim pesan
            //}
            //else
            //{
             //   counter--;
           // }
            
        }

        private void life_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                _tcpClient.Connect(IPAddress.Parse(textBox3.Text), 9999);
                _networkStream = _tcpClient.GetStream();
            }
            catch (Exception)
            {
                MessageBox.Show("Chuck Norris : You are not welcomed here");
                return;
            }
            _userName = username.Text;
            _password = textBox2.Text;
            _point = 0;

            Data data = new Data();
            data.GameData = new Game("", _point);
            data.UserData = new User(_userName, _password);
            Send(data);

            _firstTime = true;
            _working = true;
            _thread.Start();
        }

        private void Send(Data data)
        {
            _formatter.Serialize(_networkStream, data);
        }

        private Data Read()
        {
            Data data = (Data)_formatter.Deserialize(_networkStream);
            return data;
        }

        private void Work()
        {
            Data data;

            while (_working)
            {
                if (_networkStream.DataAvailable)
                {
                    //startTimer(true);
                    data = Read();
                    _play = data.Play;
                    if(_play)
                    {
                        if (data.ServerMessage != null)
                            MessageBox.Show("Chuck Norris : " + data.ServerMessage);
                        if (data.UserData != null && data.GameData != null)
                        {
                            _puzzleSolve = data.GameData.Puzzle;
                            if(_firstTime)
                                ShowMole(ShowQuestion(_index));
                        }
                    }
                }
            }
        }

        private char ShowQuestion(int index)
        {
            if (_puzzleSolve == null)
                return '\0';
            char[] question = _puzzleSolve.ToLower().ToCharArray();
            return question[index];
        }

        private char[] ConvertAnswer(string answer)
        {
            char[] huruf = new char[answer.Length];
            char[] angka = answer.ToCharArray();

            for (int i = 0; i < answer.Length; i++ )
            {
                if (angka[i] == '7')
                    huruf[i] = 'q';
                else if (angka[i] == '8')
                    huruf[i] = 'w';
                else if (angka[i] == '9')
                    huruf[i] = 'e';
                else if (angka[i] == '4')
                    huruf[i] = 'a';
                else if (angka[i] == '5')
                    huruf[i] = 's';
                else if (angka[i] == '6')
                    huruf[i] = 'd';
                else if (angka[i] == '1')
                    huruf[i] = 'z';
                else if (angka[i] == '2')
                    huruf[i] = 'x';
                else if (angka[i] == '3')
                    huruf[i] = 'c';
            }

                return huruf;
        }

        private void CekPuzzle()
        {
            char[] question = _puzzleSolve.ToLower().ToCharArray();
            char[] answer = ConvertAnswer(jawaban.Text);

            int limit;
            if (_puzzleSolve.Length > jawaban.Text.Length)
            {
                limit = jawaban.Text.Length;
                _point -= (_puzzleSolve.Length - jawaban.Text.Length);
            }
            else
            {
                limit = _puzzleSolve.Length;
                _point -= (jawaban.Text.Length - _puzzleSolve.Length);
            }

            for (int i = 0; i < limit; i++)
            {
                if (question[i] == answer[i])
                    _point++;
                else
                    _point--;
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.Play = _play;
            data.ServerMessage = "end";
            data.UserData = new User(_userName, _password);
            data.GameData = new Game(soal.Text, _point);
            Send(data);

            _working = false;
            _thread.Abort();
            _networkStream.Close();
            _tcpClient.Close();

            MessageBox.Show("Game End");
        }

        private void TimesUp()
        {
            if (!_firstTime)
                CekPuzzle();

            Data data = new Data();
            data.Play = _play;
            data.UserData = new User(_userName, _password);
            data.GameData = new Game(soal.Text, _point);
            Send(data);
            _firstTime = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimesUp();
        }

    }
}
