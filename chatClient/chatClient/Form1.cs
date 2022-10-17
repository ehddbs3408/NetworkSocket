using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatClient
{
    public partial class Form1 : Form
    {
        TcpClient clientsocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        bool stopRunning = false;

        private void msg()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(msg));
            }
            else textBox2.Text = textBox2.Text + Environment.NewLine
                    + " >> " + readData;
        }

        private void getMessage()
        {
            byte[] inStream = new byte[1024];
            string returnData = "";

            try
            {
                while (!stopRunning)
                {
                    serverStream = clientsocket.GetStream();
                    int buffsize = 0;
                    buffsize = clientsocket.ReceiveBufferSize;
                    int numBytesRead;

                    if (serverStream.DataAvailable)
                    {
                        returnData = "";
                        while (serverStream.DataAvailable)
                        {
                            numBytesRead = serverStream.Read(inStream, 0, inStream.Length);
                            returnData += Encoding.UTF8.GetString(inStream, 0, numBytesRead);
                        }
                        readData = returnData;
                        msg();
                    }
                }
            }
            catch (Exception ex)
            {
                stopRunning = true;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            readData = "Connected to Chat Server...";
            msg();
            clientsocket.Connect("localhost", 8888);
            serverStream = clientsocket.GetStream();

            byte[] outStream = Encoding.UTF8.GetBytes(textBox1.Text + '$');
            serverStream.Write(outStream, 0, outStream.Length); //send
            serverStream.Flush();

            Thread ctThread = new Thread(getMessage);
            ctThread.Start();

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.UTF8.GetBytes(textBox3.Text + '$');
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopRunning = true;
            serverStream.Close();
            clientsocket.Close();
        }
    }
}
