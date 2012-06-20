using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Baru_Server.Database;
using Oracle.DataAccess.Client;
using WhackAMole.Object;

namespace Baru_Server.Handler
{
    class Server
    {
        private Form1 _form;

        //private ConnectionManager _koneksi;

        private readonly TcpListener _tcpListener;
        private bool _isListening;
        private bool _play;
        private Thread _threadListener;

        private int _clientCount;
        private int _endCount;
        private Hashtable _hashtable;
        private string[] _userNames;

        public Server(Form1 form)
        {
            _form = form;

            _tcpListener = new TcpListener(IPAddress.Parse("10.151.36.36"), 9999);
            _isListening = false;
            _play = false;

            _clientCount = 0;
            _endCount = 0;
            _hashtable = new Hashtable(2);
            _userNames = new string[2];
            //_koneksi = new ConnectionManager();
        }

        public void Shutdown()
        {
            _form.buttonStop.Enabled = false;
            _form.buttonStart.Enabled = true;
            _form.WriteOutput("game stopped");

            if(_isListening)
                StopListening();

            if(_clientCount != 0)
            {
                for (int i = 0; i < _clientCount; i++)
                {
                    Connection connection = (Connection)_hashtable[_userNames[i]];
                    _form.WriteOutput(_userNames[i] + " = " + connection.Point);
                    connection.CloseConnection();
                }
            }
        }

        public void StartListening()
        {
            _form.buttonStart.Enabled = false;
            _form.buttonStop.Enabled = true;
            _form.WriteOutput("server start listening");
            _tcpListener.Start();
            _isListening = true;

            _threadListener = new Thread(Listening);
            _threadListener.Start();
        }

        private void Listening()
        {
            while (_isListening)
            {
                if (_clientCount < 2)
                {
                    AddClient();
                }
                else
                {
                    _play = true;
                    Data data = new Data();
                    data.UserData = new User("chuck", "");
                    data.ServerMessage = "Have fun boys";
                    Proccess(data);
                    StopListening();
                }
            }
        }

        private void StopListening()
        {
            _tcpListener.Stop();
            _isListening = false;
            _threadListener.Abort();
            _form.WriteOutput("server stop listening");
        }

        private bool CekLogin(Data data)
        {
            string username = data.UserData.UserName;
            string password = data.UserData.Password;
            string usrpass = "";
            try
            {
                MessageBox.Show("berhasil login");
                return true;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }

        private void AddClient()
        {
            TcpClient tcpClient = _tcpListener.AcceptTcpClient();
            Connection connection = new Connection(tcpClient, this);
            Data data = connection.Read();

            if(true)
            {
                _hashtable.Add(data.UserData.UserName, connection);
                _clientCount = _hashtable.Count;
                _userNames[_clientCount - 1] = data.UserData.UserName;

                _form.WriteOutput("client " + data.UserData.UserName + " joined");

                data = new Data();
                data.ServerMessage = "Welcome to the club";
                connection.Send(data);
                connection.StartConnection();
            }
            else
            {
                data = new Data();
                data.ServerMessage = "You are not welcomed here";
                connection.Send(data);
                tcpClient.Close();
            }
        }

        public void Proccess(Data data)
        {
            if(!_play)
            {
                data.UserData.UserName = "chuck";
                data.GameData = null;
                data.ServerMessage = "Wait for other player to connect";
            }

            if (data.ServerMessage == "end")
                _endCount++;
            else
            {
                for (int i = 0; i < _clientCount; i++)
                {
                    if (data.UserData.UserName != _userNames[i])
                    {
                        Connection connection = (Connection)_hashtable[_userNames[i]];
                        connection.Send(data);
                        if (data.GameData != null)
                            _form.WriteOutput(data.UserData.UserName + " (" + connection.Point + ") sent message to " + _userNames[i]);
                    }
                }
            }

            if (_endCount > 2)
            {
                Shutdown();
            }
        }
    }
}
