using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using WhackAMole.Object;

namespace Baru_Server.Handler
{
    class Connection
    {
        private Server _server;

        public int Point;

        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private BinaryFormatter _formatter;

        private bool _active;
        private Thread _thread;

        public Connection(TcpClient tcpClient, Server server)
        {
            _server = server;

            Point = 10;

            _tcpClient = tcpClient;
            _stream = _tcpClient.GetStream();
            _formatter = new BinaryFormatter();
        }

        public void StartConnection()
        {
            _thread = new Thread(Work);
            _active = true;
            _thread.Start();
        }

        public void CloseConnection()
        {
            _active = false;
            _thread.Abort();
            _stream.Close();
            _tcpClient.Close();
        }

        public void Send(Data data)
        {
            _formatter.Serialize(_stream, data);
        }

        public Data Read()
        {
            Data data = (Data)_formatter.Deserialize(_stream);
            if (data.GameData != null)
                CountPoints(data);
            return data;
        }

        private void Work()
        {
            while (_active)
            {
                try
                {
                    if (_stream.DataAvailable)
                    {
                        _server.Proccess(Read());
                    }
                }
                catch (Exception)
                {
                    _server.Shutdown();
                }
            }
        }

        private void CountPoints(Data data)
        {
            Point += data.GameData.Point;
        }
    }
}
