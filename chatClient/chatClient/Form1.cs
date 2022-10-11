using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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
            if(InvokeRequired)
            {
                Invoke(new MethodInvoker(msg));
            }
            else
            {
                textBox2.Text = textBox2.Text + Environment.NewLine + " >> " + readData;
            }
        }

        private void getMessage()
        {
            byte[] inStream = new byte[1024];
            string returnData = "";

            try
            {
                while(!stopRunning)
                {
                    serverStream = clientsocket.GetStream();
                    int buffsize = 0;
                    buffsize = clientsocket.ReceiveBufferSize;
                    int numBytesRead;

                    if(serverStream.DataAvailable)
                    {
                        readData = "";
                        while (serverStream.DataAvailable)
                        {
                            numBytesRead = serverStream.Read(inStream, 0, inStream.Length);
                            returnData += Encoding.UTF8.GetString(inStream, 0, numBytesRead);
                        }
                        readData += returnData;
                        msg();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
