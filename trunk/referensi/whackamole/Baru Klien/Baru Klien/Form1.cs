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

namespace Baru_Klien
{
    public partial class Form1 : Form
    {
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

        private bool _working;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            _tcpClient = new TcpClient();
            _formatter = new BinaryFormatter();
            _thread = new Thread(Work);
        }

        private void WriteOutput(string message)
        {
            richTextBoxOutput.AppendText(message+"\r\n");
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _tcpClient.Connect(IPAddress.Parse(textBoxServer.Text), 9999);
                _networkStream = _tcpClient.GetStream();
            }
            catch (Exception)
            {
                WriteOutput("Chuck Norris : You are not welcomed here");
                return;
            }
            _userName = textBoxUserName.Text;
            _password = textBoxPassword.Text;
            _point = 0;

            Data data = new Data();
            data.GameData = new Game("", _point);
            data.UserData = new User(_userName, _password);
            Send(data);

            _firstTime = true;
            _working = true;
            _thread.Start();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.Play = _play;
            data.ServerMessage = "end";
            data.UserData = new User(_userName, _password);
            data.GameData = new Game(textBoxSet.Text, _point);
            Send(data);

            _working = false;
            _thread.Abort();
            _networkStream.Close();
            _tcpClient.Close();

            WriteOutput("Game End");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(!_firstTime)
                CekPuzzle();

            Data data = new Data();
            data.Play = _play;
            data.UserData = new User(_userName, _password);
            data.GameData = new Game(textBoxSet.Text, _point);
            Send(data);
            _firstTime = false;
        }

        private void Send(Data data)
        {
            _formatter.Serialize(_networkStream, data);
        }

        private Data Read()
        {
            Data data = (Data) _formatter.Deserialize(_networkStream);
            return data;
        }

        private void CekPuzzle()
        {
            char[] question = _puzzleSolve.ToCharArray();
            char[] answer = textBoxSolve.Text.ToCharArray();

            int limit;
            if (_puzzleSolve.Length > textBoxSolve.Text.Length)
            {
                limit = textBoxSolve.Text.Length;
                _point -= (_puzzleSolve.Length - textBoxSolve.Text.Length);
            }
            else
            {
                limit = _puzzleSolve.Length;
                _point -= (textBoxSolve.Text.Length - _puzzleSolve.Length);
            }

            for (int i = 0; i < limit; i++)
            {
                if (question[i] == answer[i])
                    _point++;
                else
                    _point--;
            }
    }

        private void Work()
        {
            Data data;
            
            while (_working)
            {
                if(_networkStream.DataAvailable)
                {
                    data = Read();
                    _play = data.Play;
                    if(data.ServerMessage != null)
                        WriteOutput("Chuck Norris : "+data.ServerMessage);
                    if(data.UserData != null && data.GameData != null)
                    {
                        _puzzleSolve = data.GameData.Puzzle;
                        WriteOutput(_puzzleSolve);
                    }
                }
            }
        }
    }
}
