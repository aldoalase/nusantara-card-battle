using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Baru_Server.Handler;

namespace Baru_Server
{
    public partial class Form1 : Form
    {
        private Server _server;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        public void WriteOutput(String message)
        {
            rTBOutputBox.AppendText(message + "\n");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _server.Shutdown();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _server = new Server(this);
            _server.StartListening();
        }
    }
}         
